# JsonPatch.Restrict

<a href="https://www.nuget.org/packages/JsonPatch.Restrict"><img alt="Nuget" src="https://img.shields.io/nuget/v/JsonPatch.Restrict"></a> <a href="https://www.nuget.org/packages/JsonPatch.Restrict"><img alt="Nuget" src="https://img.shields.io/nuget/dt/JsonPatch.Restrict"></a> <a href="https://github.com/TwentyFourMinutes/JsonPatch.Restrict/issues"><img alt="GitHub issues" src="https://img.shields.io/github/issues-raw/TwentyFourMinutes/JsonPatch.Restrict"></a> <a href="https://github.com/TwentyFourMinutes/JsonPatch.Restrict/blob/master/LICENSE"><img alt="GitHub" src="https://img.shields.io/github/license/TwentyFourMinutes/JsonPatch.Restrict"></a> <a href="https://discordapp.com/invite/EYKxkce"><img alt="Discord" src="https://discordapp.com/api/guilds/275377268728135680/widget.png"></a>

Provides an option to restrict the properties which are allowed to be modified by a JSON PATCH operation.

## Installation

You can either get this package by downloading it from the NuGet Package Manager built in Visual Studio, in the [releases](https://github.com/TwentyFourMinutes/JsonPatch.Restrict/releases) tab or from the official [nuget.org](https://www.nuget.org/packages/JsonPatch.Restrict) website. 

Also you can install it via the **P**ackage **M**anager **C**onsole:

```
Install-Package JsonPatch.Restrict
```

### Basic example

```c#
public class DummyModel
{
    public int Id { get; set; }
    public string Value { get; set; }
}

var patchDocument = new JsonPatchDocument();
patchDocument.Replace("/Value", "newValue");

patchDocument.ApplyToWithRestrictions(dummy, "Value"); // Allows the Patch to only modify the Value property. This argument takes an array.
```
### Disclaimer

Every method has a `Try` implementation which wraps around the error lambda, which ussually has to be passed. Also do Note this doesn't work for nested objects. If needed let me know in an issue.  

### Acknowledgements

I also want to mention the [`JsonPatch.Patchable`](https://github.com/Labradoratory/JsonPatch.Patchable) package, from which this library is heavily insipred. The reason for this package to exist, is due to the fact that `JsonPatch.Patachable` enforces DDD violations by applying attributes on your domain entities.

## Notes

If you feel like something is not working as intended or you are experiencing issues, feel free to create an issue. Also for feature requests just create an issue. For further information feel free to send me a [mail](mailto:office@twenty-four.dev) to `office@twenty-four.dev` or message me on Discord `24_minutes#7496`.
