# Nominatim.API

**What does this do?**

This library can be used for utilizing geocoding (forward and reverse), in addition to address lookups, with the Nominatim HTTP API. Targets .NET 8 and .NET Standard 2.0.
\
\
\
**Why would I use this?**

This provides a simple method for common tasks within the [Nominatim](https://nominatim.org/) service. While Nominatim's API is simple to use, setting up the correct query parameters for a given action can be redundant and error-prone. My goal is to have a library with a set of services with which you can pass strongly-typed requests to, and receive strongly-typed responses.
\
\
\
**How to use**

_Major changes in usage with the release of 2.0.0, read carefully!_

Nominatim.API now targets .NET Standard 2.0 and .NET 8, which should mean that we can target a wide range of .NET applications, theoretically even down to 4.6.2. We plan to support .NET Standard 2.0 and the latest .NET LTS.

With Nominatim.API 2.0.0, it is more straightforward to support codebases that rely on dependency injection. Furthermore, we are now using modern methods to facilitate web requests, such as `HttpClientFactory` and `HttpClient`. This library does not register any interfaces and implementations automatically, and expects you to do so in a manner that you find to be appropriate. This is also done to allow the developer to register and customize how the `HttpClient` is used to their liking.

To register the Nominatim.API services in your dependencies, use the `AddNominatim` extension method.
Register your desired services via the `Add...` methods, e.g.

```csharp
builder.Services.AddNominatim()
    .WithAddressSearch()
    .WithForwardGeocoder()
    .WitReverseGeocoder();
```

or, as a shortcut for all services

```csharp
builder.Services.AddNominatim().WithAllGeocoders();
```

If you don't use Microsoft DI, you can register the services manually:

`INominatimWebInterface` -> `NominatimWebInterface`

`IAddressSearcher` -> `AddressSearcher`

`IReverseGeocoder` -> `ReverseGeocoder`

`IForwardGeocoder` -> `ForwardGeocoder`

Finally, be sure to call `.AddHttpClient()` to your `ServiceCollection` for a vanilla `HttpClient` implementation. Customize as needed for your respective DI library or use case.

Code surface is very simple, here are the methods exposed by interfaces:

`IAddressSearcher`:

`Task<AddressLookupResponse[]> Lookup(AddressSearchRequest req);`
\
\
`IForwardGeocoder`:

`Task<GeocodeResponse[]> Geocode(ForwardGeocodeRequest req)`
\
\
`IReverseGeocoder`:

`Task<GeocodeResponse> ReverseGeocode(ReverseGeocodeRequest req);`
\
\
\
**Contributions**

I welcome any and all suggestions or improvements to the codebase. Thanks for dropping by and hope you find a good use for this library!
