# Eudwia

An ASP.NET Core + Blazor WebAssembly application to manage an association in a very light way.

 - [x] Members management
 - [x] Management of membership fees
 - [x] Mail generation
 - [x] Dashboard
 - [x] Tenants
 - [x] Donations

## Coming soon :

 - [ ] Localization
 - [ ] Refresh token
 - [ ] Admin console

## Architecture

```
src/Eudwia.Client/
├── Features/
│   ├── FeatureA/
│       ├── FeatureAComponent.razor
│   ├── FeatureB/
│       ├── FeatureBComponent.razor
src/Eudwia.Server/
├── Features/
│   ├── FeatureA/
│       ├── FeatureAEndpoint.cs
│   ├── FeatureB/
│       ├── FeatureBEndpoint.cs
src/Eudwia.Server/
├── Features/
│   ├── FeatureA/
│       ├── FeatureARequest.cs
│       ├── FeatureAViewModel.cs
│   ├── FeatureB/
│       ├── FeatureBRequest.cs
│       ├── FeatureBViewModel.cs
tests/Eudwia.Server.IntegrationTests/
├── Features/
│   ├── FeatureA/
│       ├── FeatureAEndpointTests.cs
```
The architecture of the project is deliberately very (too?) simplistic.

Indeed, there is no separation of layers (N-Tiers, Onion, etc.) but rather a will to separate feature in slices ([Vertical Slice](https://jimmybogard.com/vertical-slice-architecture/)).

There are several reasons for this :

 1. Having fun 👀
 2. YAGNI
 3. Trying something different than what I do every day for my job as a software architect at Trianon (#WeAreHiring).

## Tests
The application being very simple, there are no unit tests (very little logic for the moment), there are only integration tests (excluding UI).

The idea is not to mock anything for the tests, a Docker container is used to launch a SQL Server instance, allowing to test in real conditions.

Stack : 
 - [xUnit](https://github.com/xunit/)
 - [.NET Testcontainers](https://github.com/HofmeisterAn/dotnet-testcontainers/) (which I highly recommend)
 - [Bogus](https://github.com/bchavez/Bogus)

## Demo

 - Url : https://dev-eudwia.hajruli.ch/
 - User : dev@example.ch
 - Pwd : Test1234!

