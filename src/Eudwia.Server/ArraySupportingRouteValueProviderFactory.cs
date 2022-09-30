using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Eudwia.Server;

/// <summary>
/// Based on: https://github.com/dotnet/aspnetcore/blob/main/src/Mvc/Mvc.Core/src/ModelBinding/RouteValueProviderFactory.cs
/// </summary>
public class ArraySupportingRouteValueProviderFactory : IValueProviderFactory
{
    public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var valueProvider = new ArraySupportingRouteValueProvider(
            BindingSource.Path,
            context.ActionContext.RouteData.Values,
            context.ActionContext.ActionDescriptor);

        context.ValueProviders.Add(valueProvider);

        return Task.CompletedTask;
    }
}