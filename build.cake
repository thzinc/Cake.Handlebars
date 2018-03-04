#tool nuget:?package=GitVersion.CommandLine&version=4.0.0-beta0012

var version = "";
var target = Argument("target", "Default");

Task("GetVersion")
    .Does(() =>
    {
        var result = GitVersion(new GitVersionSettings
        {
            UpdateAssemblyInfo = false
        });

        version = result.NuGetVersionV2;
        Information($"Version = '{version}'");
    });

Task("Build")
	.IsDependentOn("GetVersion")
	.Does (() =>
	{
		DotNetCoreRestore("./Cake.Handlebars.sln");
		DotNetCoreBuild("./Cake.Handlebars.sln", new DotNetCoreBuildSettings
		{
			Configuration = "Release",
			ArgumentCustomization = args => args.Append($"/property:Version={version}"),
			NoRestore = true,
		});
	});

Task("UnitTest")
	.IsDependentOn("Build")
	.Does(() =>
	{
		DotNetCoreTest("./src/Cake.Handlebars.Tests");
	});

Task("NuGetPack")
	.IsDependentOn("Default")
	.IsDependentOn("UnitTest")
	.Does (() =>
	{
		DotNetCorePack("./src/Cake.Handlebars", new DotNetCorePackSettings
		{
			Configuration = "Release",
			OutputDirectory = "./artifacts",
			ArgumentCustomization = args => args.Append($"/property:Version={version}"),
			NoBuild = true,
			NoRestore = true,
		});
	});

Task("NuGetPush")
	.IsDependentOn("NuGetPack")
	.Does(() => 
	{
        var settings = new DotNetCoreNuGetPushSettings
        {
            Source = "https://www.nuget.org/api/v2/package",
            ApiKey = EnvironmentVariable("NUGET_API_KEY"),
        };

        DotNetCoreNuGetPush($"./artifacts/Cake.Handlebars.{version}.nupkg", settings);
	});

Task("Default")
	.IsDependentOn("Build")
	.IsDependentOn("UnitTest");

Task("Pack")
	.IsDependentOn("Default")
	.IsDependentOn("NuGetPack");

Task("Ship")
	.IsDependentOn("Pack")
	.IsDependentOn("NuGetPush");

RunTarget(target);
