using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Eudwia.Server.Data.Contexts;
using Eudwia.Server.Data.Contexts.Extensions;
using Eudwia.Server.IntegrationTests.Fixtures;
using Eudwia.Shared.Enums;
using Eudwia.Shared.Features.Members.Details;
using Eudwia.Shared.Features.Members.Update;
using Shouldly;
using Xunit;

namespace Eudwia.Server.IntegrationTests.Features.Members.Update;

[Collection(DatabaseTestsCollection.CollectionName)]
public class MembersUpdateEndpointTests
{
    private readonly DatabaseFixture _databaseFixture;

    public MembersUpdateEndpointTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task UpdateShouldFailWhenUserIsNotAuthorized()
    {
        // Arrange
        var client = _databaseFixture.CreateClient();

        // Act
        var result = await client.PostAsJsonAsync($"api/members/{Guid.Empty}", new MembersUpdateCommand());

        // Assert
        result.StatusCode.ShouldBe(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task UpdateShouldSuccessWhenAllRequirementsAreMeet()
    {
        // Arrange
        var client = await _databaseFixture.CreateUserClient();
        await using var context = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var baseMember = context.Members.Add(ModelBuilderExtensions.CreateMember()).Entity;
        await context.SaveChangesAsync();

        // Act
        var memberUpdateCommand = new MembersUpdateCommand
        {
            FirstName = "NewFirstName",
            LastName = "NewLastName",
            StreetLine1 = "NewStreetLine1",
            StreetLine2 = "NewStreetLine2",
            HouseNumber = "New10",
            City = "NewCity",
            ZipCode = "New1004",
            State = "NewState",
            CountryId = Guid.Parse("50aa4ab0-3c14-4550-a87f-bdfca7d90638"), // Zimbabwe
            Email = "NewEmail@example.com",
            PhoneNumber = "00000000000000",
            BirthDate = DateTime.Now.AddYears(-20).Date,
            MemberSince = DateTime.Now.Date,
            Language = Language.French
        };

        var result = await client.PostAsJsonAsync($"api/members/{baseMember.Id}", memberUpdateCommand);
        var member = await client.GetFromJsonAsync<MembersDetailsViewModel>($"api/members/{baseMember.Id}");

        // Assert
        result.StatusCode.ShouldBe(HttpStatusCode.OK);
        member.ShouldNotBeNull();
        member.FirstName.ShouldBe(memberUpdateCommand.FirstName);
        member.LastName.ShouldBe(memberUpdateCommand.LastName);
        member.StreetLine1.ShouldBe(memberUpdateCommand.StreetLine1);
        member.StreetLine2.ShouldBe(memberUpdateCommand.StreetLine2);
        member.HouseNumber.ShouldBe(memberUpdateCommand.HouseNumber);
        member.City.ShouldBe(memberUpdateCommand.City);
        member.ZipCode.ShouldBe(memberUpdateCommand.ZipCode);
        member.State.ShouldBe(memberUpdateCommand.State);
        member.CountryId.ShouldBe(memberUpdateCommand.CountryId);
        member.Email.ShouldBe(memberUpdateCommand.Email);
        member.PhoneNumber.ShouldBe(memberUpdateCommand.PhoneNumber);
        member.BirthDate.ShouldBe(memberUpdateCommand.BirthDate);
        member.MemberSince.ShouldBe(memberUpdateCommand.MemberSince);
        member.Language.ShouldBe(memberUpdateCommand.Language);
    }

    [Fact]
    public async Task UpdateShouldFailWhenEmailIsMalformed()
    {
        // Arrange
        var client = await _databaseFixture.CreateUserClient();
        await using var context = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var baseMember = context.Members.Add(ModelBuilderExtensions.CreateMember()).Entity;
        await context.SaveChangesAsync();

        // Act
        var memberUpdateCommand = new MembersUpdateCommand
        {
            FirstName = "NewFirstName",
            LastName = "NewLastName",
            StreetLine1 = "NewStreetLine1",
            StreetLine2 = "NewStreetLine2",
            HouseNumber = "New10",
            City = "NewCity",
            ZipCode = "New1004",
            State = "NewState",
            CountryId = Guid.Parse("50aa4ab0-3c14-4550-a87f-bdfca7d90638"), // Zimbabwe
            Email = "NewEmailexample.com",
            PhoneNumber = "00000000000000",
            BirthDate = DateTime.Now.AddYears(-20).Date,
            MemberSince = DateTime.Now.Date,
            Language = Language.French
        };

        var result = await client.PostAsJsonAsync($"api/members/{baseMember.Id}", memberUpdateCommand);

        // Assert
        result.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        var problemDetails = await result.Content.ReadFromJsonAsync<ProblemDetails>();
        problemDetails.ShouldNotBeNull();
        problemDetails.Extensions.Count.ShouldBe(2);
        problemDetails.Title.ShouldBe("One or more validation errors occurred.");
        problemDetails.Status.ShouldBe(400);
        problemDetails.Extensions["errors"]!.ToString().ShouldBe("{\"Email\":[\"'Email' is not a valid email address.\"]}");
    }

    [Fact]
    public async Task UpdateShouldSucceedWhenEmailAndPhoneAreEmpty()
    {
        // Arrange
        var client = await _databaseFixture.CreateUserClient();
        await using var context = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var baseMember = context.Members.Add(ModelBuilderExtensions.CreateMember()).Entity;
        await context.SaveChangesAsync();

        // Act
        var memberUpdateCommand = new MembersUpdateCommand
        {
            FirstName = "NewFirstName",
            LastName = "NewLastName",
            StreetLine1 = "NewStreetLine1",
            StreetLine2 = "NewStreetLine2",
            HouseNumber = "New10",
            City = "NewCity",
            ZipCode = "New1004",
            State = "NewState",
            CountryId = Guid.Parse("50aa4ab0-3c14-4550-a87f-bdfca7d90638"), // Zimbabwe
            Email = string.Empty,
            PhoneNumber = string.Empty,
            BirthDate = DateTime.Now.AddYears(-20).Date,
            MemberSince = DateTime.Now.Date,
            Language = Language.French
        };

        var result = await client.PostAsJsonAsync($"api/members/{baseMember.Id}", memberUpdateCommand);

        // Assert
        result.StatusCode.ShouldBe(HttpStatusCode.OK);
    }

    [Fact]
    public async Task UpdateShouldSucceedWhenStreetLine2IsEmpty()
    {
        // Arrange
        var client = await _databaseFixture.CreateUserClient();
        await using var context = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var baseMember = context.Members.Add(ModelBuilderExtensions.CreateMember()).Entity;
        await context.SaveChangesAsync();

        // Act
        var memberUpdateCommand = new MembersUpdateCommand
        {
            FirstName = "NewFirstName",
            LastName = "NewLastName",
            StreetLine1 = "NewStreetLine1",
            HouseNumber = "New10",
            City = "NewCity",
            ZipCode = "New1004",
            State = "NewState",
            CountryId = Guid.Parse("50aa4ab0-3c14-4550-a87f-bdfca7d90638"), // Zimbabwe
            Email = "NewEmail@example.com",
            PhoneNumber = "00000000000000",
            BirthDate = DateTime.Now.AddYears(-20).Date,
            MemberSince = DateTime.Now.Date,
            Language = Language.French
        };

        var result = await client.PostAsJsonAsync($"api/members/{baseMember.Id}", memberUpdateCommand);
        var member = await client.GetFromJsonAsync<MembersDetailsViewModel>($"api/members/{baseMember.Id}");

        // Assert
        result.StatusCode.ShouldBe(HttpStatusCode.OK);
        member.ShouldNotBeNull();
        member.StreetLine2.ShouldBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task UpdateShouldFailWhenStreetLine2Is2CharsLong()
    {
        // Arrange
        var client = await _databaseFixture.CreateUserClient();
        await using var context = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var baseMember = context.Members.Add(ModelBuilderExtensions.CreateMember()).Entity;
        await context.SaveChangesAsync();

        // Act
        var memberUpdateCommand = new MembersUpdateCommand
        {
            FirstName = "NewFirstName",
            LastName = "NewLastName",
            StreetLine1 = "NewStreetLine1",
            StreetLine2 = "AA",
            HouseNumber = "New10",
            City = "NewCity",
            ZipCode = "New1004",
            State = "NewState",
            CountryId = Guid.Parse("50aa4ab0-3c14-4550-a87f-bdfca7d90638"), // Zimbabwe
            Email = "NewEmailexample.com",
            PhoneNumber = "00000000000000",
            BirthDate = DateTime.Now.AddYears(-20).Date,
            MemberSince = DateTime.Now.Date,
            Language = Language.French
        };

        var result = await client.PostAsJsonAsync($"api/members/{baseMember.Id}", memberUpdateCommand);
        var member = await client.GetFromJsonAsync<MembersDetailsViewModel>($"api/members/{baseMember.Id}");

        // Assert
        result.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        member.ShouldNotBeNull();
        member.StreetLine2.ShouldBe(baseMember.StreetLine2); // StreetLine2 is not updated
    }

    [Fact]
    public async Task UpdateShouldFailWhenStreetLine2Is201CharsLong()
    {
        // Arrange
        var client = await _databaseFixture.CreateUserClient();
        await using var context = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var baseMember = context.Members.Add(ModelBuilderExtensions.CreateMember()).Entity;
        await context.SaveChangesAsync();

        // Act
        var memberUpdateCommand = new MembersUpdateCommand
        {
            FirstName = "NewFirstName",
            LastName = "NewLastName",
            StreetLine1 = "NewStreetLine1",
            StreetLine2 = "aaaaabbbbbcccccdddddeeeeefffffggggghhhhhiiiiijjjjjkkkkklllllmmmmmnnnnnoooooooopppppqqqqqrrrrrssssstttttuuuuuvvvvvwwwwwwxxxxxxxxyyyyyyzzzzzz111112222233333444445555566666777778888899999000001234567890AA",
            HouseNumber = "New10",
            City = "NewCity",
            ZipCode = "New1004",
            State = "NewState",
            CountryId = Guid.Parse("50aa4ab0-3c14-4550-a87f-bdfca7d90638"), // Zimbabwe
            Email = "NewEmail@example.com",
            PhoneNumber = "00000000000000",
            BirthDate = DateTime.Now.AddYears(-20).Date,
            MemberSince = DateTime.Now.Date,
            Language = Language.French
        };

        var result = await client.PostAsJsonAsync($"api/members/{baseMember.Id}", memberUpdateCommand);
        var member = await client.GetFromJsonAsync<MembersDetailsViewModel>($"api/members/{baseMember.Id}");

        // Assert
        result.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        member.ShouldNotBeNull();
        var problemDetails = await result.Content.ReadFromJsonAsync<ProblemDetails>();
        problemDetails.ShouldNotBeNull();
        problemDetails.Extensions["errors"]!.ToString().ShouldBe("{\"StreetLine2\":[\"'Street Line2' must be between 3 and 200 characters. You entered 201 characters.\"]}");
        member.StreetLine2.ShouldBe(baseMember.StreetLine2); // StreetLine2 is not updated
    }
}