# Nominatim.API

**What does this do?**

This library can be used for utilizing geocoding (forward and reverse), in addition to address lookups, with the Nominatim HTTP API. Targets .NET 6 and .NET Standard 2.0. 
\
\
\
**Why would I use this?**

This provides a simple method for common tasks within the [Nominatim](https://nominatim.org/) service.  While Nominatim's API is simple to use, setting up the correct query parameters for a given action can be redundant and error-prone.  My goal is to have a library with a set of services with which you can pass strongly-typed requests to, and receive strongly-typed responses.
\
\
\
**How to use**

_Major changes in usage with the release of 2.0.0, read carefully!_

Nominatim.API now targets .NET Standard 2.0 and .NET 6, which should mean that we can target a wide range of .NET applications, theoretically even down to 4.6.2.

With Nominatim.API 2.0.0, it is more straightforward to support codebases that rely on dependency injection.  Furthermore, we are now using modern methods to facilitate web requests, such as `HttpClientFactory` and `HttpClient`.  This library does not register any interfaces and implementations, and expects you to do so in a manner that you find to be appropriate.  This is also done to allow the developer to register and customize how the `HttpClient` is used to their liking.

To add a service call `.AddNoninatimServices()` to your `ServiceCollection`.

Finally, be sure to call `.AddHttpClient()` to your `ServiceCollection` for a vanilla `HttpClient` implementation.  Customize as needed for your respective DI library or use case.

The code surface is very simple - using the `INominatimWebInterface` interface, here are the available methods:

`Task<AddressLookupResponse[]> Lookup(AddressSearchRequest req)`

`Task<GeocodeResponse[]> Geocode(ForwardGeocodeRequest req)`

`Task<GeocodeResponse> ReverseGeocode(ReverseGeocodeRequest req)`

Also you can change the `BaseURL` and `ApiKey` through the corresponding properties.

**Contributions**

I welcome any and all suggestions or improvements to the codebase.  Thanks for dropping by and hope you find a good use for this library!
