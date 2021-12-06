using Bogus;
using Microsoft.EntityFrameworkCore;

namespace MosqueLife.Data.Contexts.Extensions;

public static class ModelBuilderExtensions
{
    private const int Amount = 10;
    private static readonly Faker Faker = new();

    public static void Seed(this ModelBuilder modelBuilder)
        => modelBuilder.SeedPersons();

    private static void SeedPersons(this ModelBuilder modelBuilder) =>
        modelBuilder
            .Entity<Member>()
            .HasData(Enumerable
                .Range(0, 0)
                .Select(_ => new Member
                {
                    Id = Guid.NewGuid(),
                    

                }));
}
