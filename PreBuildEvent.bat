REM this comand used to generate  the following files in the build obj folder : project.assets.json / {projectName}.projectFileExtension.nuget.g.props / {projectName}.projectFileExtension.nuget.g.targets 
REM this comand to be used only for .netStandard projects

SET ProjectPath=%1
dotnet restore  %ProjectPath%

