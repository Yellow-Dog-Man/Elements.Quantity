# Elements.Quantity
Handful .NET library for working with various physical quantities, including conversions, formatting and parsing.

[![NuGet](https://img.shields.io/nuget/v/YellowDogMan.Elements.Quantity.svg)](https://www.nuget.org/packages/YellowDogMan.Elements.Quantity)

## Building
This library should be build-able using a standard Visual Studio setup. As there are no dependencies, it is usually quite fast.

## Publishing a New Nuget Version

Version releases are handled automatically by GitHub Actions. You do need to trigger a release though. To do this:
1. Git Tag a git commit with the new version number. Tags must be in the format: `version number` without any prefixes or suffixes. E.g.`1.0.0`
1. Push that Tag to Github however you'd like e.g. `git push --tags`
1. [Draft a new GitHub Release](https://github.com/Yellow-Dog-Man/Elements.Quantity/releases/new) using that tag in the "Choose a tag" drop down.
1. Write suitable release notes, If PRs were used the "Generate release notes" button will automatically populate them.
1. Publish the release.
