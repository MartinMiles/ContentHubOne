# My scotch whisky collection

A real life showcase built with Content Hub ONE.

As you may know, Content Hub ONE is a pure headless CMS. 
In order to build head application I chose ASP.NET Core rendering built with .NET 7

The deployed application is [here](https://whisky.martinmiles.net/).

> Please keep in mind, that is not a production-ready quality, the code was built for PoC with a maximum simplicity in mind. Use it on your own risk.

## Setting up Content Hub One

Make sure you set your own API Token for GraphQL. You can do that at `appsettings.json` file:
```
"ApiToken": { "Value": "PUT YOUR OWN API TOKEN" }
```
You can generate new token from the Settings menu of Content Hub ONE.