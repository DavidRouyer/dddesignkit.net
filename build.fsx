#r @"tools\FAKE.Core\tools\FakeLib.dll"
#load "tools/SourceLink.Fake/tools/SourceLink.fsx"
open Fake 
open System
open SourceLink

let authors = ["David Rouyer"]

// project name and description
let projectName = "Dddesignkit"
let projectDescription = "An async-based Dribbble API client library for .NET"
let projectSummary = projectDescription // TODO: write a summary

// directories
let buildDir = "./Dddesignkit/bin"
let testResultsDir = "./testresults"
let packagingRoot = "./packaging/"
let packagingDir = packagingRoot @@ "Dddesignkit"

let releaseNotes = 
    ReadFile "ReleaseNotes.md"
    |> ReleaseNotesHelper.parseReleaseNotes

let buildMode = getBuildParamOrDefault "buildMode" "Release"

MSBuildDefaults <- { MSBuildDefaults with Verbosity = Some MSBuildVerbosity.Minimal }

Target "Clean" (fun _ ->
    CleanDirs [buildDir; testResultsDir; packagingRoot; packagingDir]
)

open Fake.AssemblyInfoFile
open Fake.Testing

Target "AssemblyInfo" (fun _ ->
    CreateCSharpAssemblyInfo "./SolutionInfo.cs"
      [ Attribute.Product projectName
        Attribute.Version releaseNotes.AssemblyVersion
        Attribute.FileVersion releaseNotes.AssemblyVersion
        Attribute.ComVisible false ]
)

Target "CheckProjects" (fun _ ->
    !! "./Dddesignkit/Dddesignkit*.csproj"
    |> Fake.MSBuild.ProjectSystem.CompareProjectsTo "./Dddesignkit/Dddesignkit.csproj"
)

Target "FixProjects" (fun _ ->
    !! "./Dddesignkit/Dddesignkit*.csproj"
    |> Fake.MSBuild.ProjectSystem.FixProjectFiles "./Dddesignkit/Dddesignkit.csproj"
)

Target "BuildApp" (fun _ ->
    MSBuild null "Build" ["Configuration", buildMode] ["./Dddesignkit.sln"]
    |> Log "AppBuild-Output: "
)

Target "UnitTests" (fun _ ->
    !! (sprintf "./Dddesignkit.Tests/bin/%s/**/Dddesignkit.Tests*.dll" buildMode)
    |> xUnit2 (fun p -> 
            {p with
                HtmlOutputPath = Some (testResultsDir @@ "xunit.html") })
)

Target "IntegrationTests" (fun _ ->
    if hasBuildParam "DDDESIGNKIT_OAUTHTOKEN" then
        !! (sprintf "./Dddesignkit.Tests.Integration/bin/%s/**/Dddesignkit.Tests.Integration.dll" buildMode)
        |> xUnit2 (fun p -> 
                {p with 
                    HtmlOutputPath = Some (testResultsDir @@ "xunit.html")
                    TimeOut = TimeSpan.FromMinutes 10.0  })
    else
        "The integration tests were skipped because the DDDESIGNKIT_OAUTHTOKEN environment variables are not set. " +
        "Please configure these environment variables for a Dribbble test account (DO NOT USE A \"REAL\" ACCOUNT)."
        |> traceImportant 
)

Target "Default" DoNothing

Target "CreatePackages" DoNothing

"Clean"
   ==> "AssemblyInfo"
   ==> "CheckProjects"
   ==> "BuildApp"

"UnitTests"
   ==> "Default"

"IntegrationTests"
   ==> "Default"



RunTargetOrDefault "Default"
