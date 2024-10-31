var solution = "./RichillCapital.TraderStudio.Mobile.sln";
var buildConfiguration = Argument("configuration", "Release");

Task("Clean")
    .Does(() =>
    {
        DotNetClean(solution);
    });

Task("Default")
    .IsDependentOn("Clean");

Task("Build")
    .Does(() =>
    {
        var settings = new DotNetBuildSettings
        {
            Configuration = buildConfiguration,
            NoRestore = true,
        };

        DotNetBuild(solution, settings);
    });

var target = Argument("target", "Default");
RunTarget(target);