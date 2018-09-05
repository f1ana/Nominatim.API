# Nominatim API Forward and Reverse Geocoding C# 

The API returns latitude/longitude coordinates and normalized address information.  
This can be used to perform address validation, real time mapping of user-entered addresses, distance calculations, and much more.

## Installation

Install [via nuget](http://www.nuget.org/packages/Nominatim.API/):

```
Install-Package Nominatim.API
```

## Example Usage

### Simple Example

```csharp
 var geocoder = new ForwardGeocoder();
            var addresses = ForwardGeocoder.Geocode(new ForwardGeocodeRequest {
                queryString = "1600 Pennsylvania Avenue, Washington, DC",

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });
            addresses.Wait();
```
