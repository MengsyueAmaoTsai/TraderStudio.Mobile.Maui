var solution = "./RichillCapital.TraderStudio.Mobile.sln";

var buildConfiguration = Argument("configuration", "Release");
var targetFramework = "net8.0-android";
var publishDirectory = "./artifacts";

Task("Clean")
    .Does(() =>
    {
        DotNetClean(solution);
        CleanDirectory(publishDirectory);
    });

Task("Restore")
    .Does(() =>
    {
        DotNetRestore(solution);
    });

Task("Build")
    .Does(() =>
    {
        var settings = new DotNetPublishSettings
        {
            Configuration = buildConfiguration,
            NoRestore = true,
            Framework = targetFramework,
            OutputDirectory = publishDirectory,
        };

        DotNetPublish(solution, settings);
    });

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build");

var target = Argument("target", "Default");

RunTarget(target);