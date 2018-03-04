# Cake.HandlebarsDotNet

Cake addin for working with Handlebars templates

(This is very close in functionality to https://github.com/agc93/Cake.Handlebars. At some point, these should probably be merged.)

## Quickstart

Add the `Cake.HandlebarsDotNet` package to your Cake script:

```csharp
#addin nuget:?package=Cake.HandlebarsDotNet&loaddependencies=true
```

Then use it in your script

```csharp
Task("RenderTemplate")
    .Does(() =>
    {
        var rendered = HandlebarsRenderText("Hello, {{Name}}!", new { Name = "World" });
        Information($"Result: {rendered}");
    });

Task("RenderTemplateFromFile")
    .Does(() =>
    {
        var rendered = HandlebarsRenderTextFile("./template.handlebars", new { Name = "World" });
        Information($"Result: {rendered}");
    });

Task("RenderTemplateFromFileToFile")
    .Does(() =>
    {
        HandlebarsRenderTextFile("./template.handlebars", "./rendered.txt", new { Name = "World" });
    });
```


## Building

[![AppVeyor CI](https://img.shields.io/appveyor/ci/thzinc/cake-handlebars.svg)](https://ci.appveyor.com/project/thzinc/cake-handlebars)
[![AppVeyor Tests](https://img.shields.io/appveyor/tests/thzinc/cake-handlebars.svg)](https://ci.appveyor.com/project/thzinc/cake-handlebars/build/tests)
[![NuGet](https://img.shields.io/nuget/v/Cake.HandlebarsDotNet.svg)](https://www.nuget.org/packages/Cake.HandlebarsDotNet/)
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/Cake.HandlebarsDotNet.svg)](https://www.nuget.org/packages/Cake.HandlebarsDotNet/)

This project is built using Cake. Because this Cake addin targets net46 for compatibility with Cake 0.25.0, it does require being built in an environment where net46 is available. (Generally Windows) Development and testing is possible on macOS/Linux, but packaging for use with Cake will require building against net46.

On macOS/Linux:

```bash
./build.sh
```

On Windows:

```powershell
.\build.ps1
```

## Code of Conduct

We are committed to fostering an open and welcoming environment. Please read our [code of conduct](CODE_OF_CONDUCT.md) before participating in or contributing to this project.

## Contributing

We welcome contributions and collaboration on this project. Please read our [contributor's guide](CONTRIBUTING.md) to understand how best to work with us.

## License and Authors

[![Daniel James logo](https://secure.gravatar.com/avatar/eaeac922b9f3cc9fd18cb9629b9e79f6.png?size=16) Daniel James](https://github.com/thzinc)

[![license](https://img.shields.io/github/license/thzinc/Cake.HandlebarsDotNet.svg)](https://github.com/thzinc/Cake.HandlebarsDotNet/blob/master/LICENSE)
[![GitHub contributors](https://img.shields.io/github/contributors/thzinc/Cake.HandlebarsDotNet.svg)](https://github.com/thzinc/Cake.HandlebarsDotNet/graphs/contributors)

This software is made available by Daniel James under the MIT license.