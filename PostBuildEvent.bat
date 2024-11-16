REM Ligne de commande Visual studio :
REM $(SolutionDir)\PostBuildEvent.bat $(ConfigurationName) $(SolutionDir) $(TargetDir) $(TargetName) $(ProjectName)

SET ConfigurationName=%1
SET SolutionDir=%2
SET TargetDir=%3
SET TargetName=%4
SET ProjectName=%5
SET OutDir=%6


SET LogFilePath=%TargetDir%%TargetName%.postbuildevent.Log

REM If Configuration is not Debug go out of this script
IF NOT %ConfigurationName% == Debug (
	ECHO not running in Debug skip this script. >> %LogFilePath%
	GOTO EndOfScript
)

REM Check if ..\ServiceDesk\Binaries\SimplyDesk.Framework\ is usable
SET SDBinariesDirPath=%SolutionDir%..\ServiceDesk\Binaries\
IF EXIST %SDBinariesDirPath%SimplyDesk.Framework\ (
	ECHO Le dossier Binaries Framework de ServiceDesk Existe bien >> %LogFilePath%
	SET SDServiceDeskDependenciesDirPath=%SDBinariesDirPath%SimplyDesk.Framework\
)


REM Check if ..\TenantManager\Binaries\SimplyDesk.Framework\ is usable
SET TMBinariesDirPath=%SolutionDir%..\TenantManager\Binaries\
IF EXIST %TMBinariesDirPath%SimplyDesk.Framework\ (
	ECHO Le dossier Binaries Framework de TenantManager Existe bien >> %LogFilePath%
	SET TMServiceDeskDependenciesDirPath=%TMBinariesDirPath%SimplyDesk.Framework\
)




SET TargetFilePath=%TargetDir%%TargetName%.dll
SET TargetFileName=%TargetName%.dll
SET ConfigFileName=%TargetFileName%.config
SET ConfigFilePath=%TargetFilePath%.config




IF EXIST %TargetFilePath% (
	ECHO La sortie de ce projet est une DLL >> %LogFilePath%
) ELSE (
	ECHO La sortie de ce projet est un EXE >> %LogFilePath%
	SET TargetFilePath=%TargetDir%%TargetName%.exe
	SET TargetFileName=%TargetName%.exe
	SET ConfigFileName=%TargetFileName%.config
	SET ConfigFilePath=%TargetFilePath%.config
)


REM Show PostBuildEvent.bat parameters
ECHO "param1 => ConfigurationName => %ConfigurationName%" >> %LogFilePath%
ECHO "param2 => SolutionDir => %SolutionDir%" >> %LogFilePath%
ECHO "param3 => TargetDir => %TargetDir%" >> %LogFilePath%
ECHO "param4 => TargetName => %TargetName%" >> %LogFilePath%
ECHO "param5 => ProjectName => %ProjectName%" >> %LogFilePath%
ECHO "param6 => OutDir => %OutDir%" >> %LogFilePath%
ECHO "TargetFilePath => %TargetFilePath%" >> %LogFilePath%
ECHO "TargetFileName => %TargetFileName%" >> %LogFilePath%
ECHO "ConfigFileName => %ConfigFileName%" >> %LogFilePath%
ECHO "ConfigFilePath => %ConfigFilePath%" >> %LogFilePath%


IF NOT EXIST %SolutionDir%..\Binaries\ (
	ECHO MKDIR %SolutionDir%..\Binaries >> %LogFilePath%
	MKDIR %SolutionDir%..\Binaries
)

IF NOT EXIST %SolutionDir%..\Binaries\SimplyDesk.Framework\ (
	ECHO MKDIR %SolutionDir%..\Binaries\SimplyDesk.Framework >> %LogFilePath%
	MKDIR %SolutionDir%..\Binaries\SimplyDesk.Framework
)


REM copy TargetFile   --------------------------------

ECHO Copy TargetFilePath File To "%SolutionDir%..\Binaries\SimplyDesk.Framework\%TargetFileName%" >> %LogFilePath%
COPY "%TargetFilePath%" "%SolutionDir%..\Binaries\SimplyDesk.Framework\%TargetFileName%" /Y >> %LogFilePath%
IF DEFINED SDServiceDeskDependenciesDirPath (
	ECHO Copy "%TargetFilePath%" File To "%SDServiceDeskDependenciesDirPath%%TargetFileName%" >> %LogFilePath%
	Copy "%TargetFilePath%" "%SDServiceDeskDependenciesDirPath%%TargetFileName%" /Y >> %LogFilePath%
)
IF DEFINED TMServiceDeskDependenciesDirPath (
	ECHO Copy "%TargetFilePath%" File To "%TMServiceDeskDependenciesDirPath%%TargetFileName%" >> %LogFilePath%
	Copy "%TargetFilePath%" "%TMServiceDeskDependenciesDirPath%%TargetFileName%" /Y >> %LogFilePath%
)


REM copy PDB File --------------------------------

ECHO copy PDB File To "%SolutionDir%..\Binaries\SimplyDesk.Framework\%TargetName%.pdb" >> %LogFilePath%
COPY "%TargetDir%%TargetName%.pdb" "%SolutionDir%..\Binaries\SimplyDesk.Framework\%TargetName%.pdb" /Y >> %LogFilePath%
IF DEFINED SDServiceDeskDependenciesDirPath (
	ECHO Copy PDB File To "%SDServiceDeskDependenciesDirPath%%TargetName%.pd" >> %LogFilePath%
	Copy "%TargetDir%%TargetName%.pdb" "%SDServiceDeskDependenciesDirPath%%TargetName%.pdb" /Y >> %LogFilePath%
)
IF DEFINED TMServiceDeskDependenciesDirPath (
	ECHO Copy PDB File To "%TMServiceDeskDependenciesDirPath%%TargetName%.pd" >> %LogFilePath%
	Copy "%TargetDir%%TargetName%.pdb" "%TMServiceDeskDependenciesDirPath%%TargetName%.pdb" /Y >> %LogFilePath%
)

REM copy XML Documentation --------------------------------

ECHO copy XML Documentation File To "%SolutionDir%..\Binaries\SimplyDesk.Framework\%TargetName%.xml" >> %LogFilePath%
COPY "%TargetDir%%TargetName%.xml" "%SolutionDir%..\Binaries\SimplyDesk.Framework\%TargetName%.xml" /Y >> %LogFilePath%
IF DEFINED SDServiceDeskDependenciesDirPath (
	ECHO Copy XML Documentation File To "%SDServiceDeskDependenciesDirPath%%TargetName%.xml" >> %LogFilePath%
	Copy "%TargetDir%%TargetName%.xml" "%SDServiceDeskDependenciesDirPath%%TargetName%.xml" /Y >> %LogFilePath%
)
IF DEFINED TMServiceDeskDependenciesDirPath (
	ECHO Copy XML Documentation File To "%TMServiceDeskDependenciesDirPath%%TargetName%.xml" >> %LogFilePath%
	Copy "%TargetDir%%TargetName%.xml" "%TMServiceDeskDependenciesDirPath%%TargetName%.xml" /Y >> %LogFilePath%
)

REM copy ConfigFile--------------------------------

IF EXIST %ConfigFilePath% (
	ECHO copy ConfigFilePath File To "%SolutionDir%..\Binaries\SimplyDesk.Framework\%ConfigFileName%" >> %LogFilePath%
	COPY "%ConfigFilePath%" "%SolutionDir%..\Binaries\SimplyDesk.Framework\%ConfigFileName%" /Y >> %LogFilePath%
)

if NOT "%OutDir%"=="" (
 ECHO copy Folder "%TargetDir%*" Vers  "%SolutionDir%SimplyDesk.Framework.UnitTests\%OutDir%" >> %LogFilePath%
  xcopy /y "%TargetDir%*"  "%SolutionDir%SimplyDesk.Framework.UnitTests\%OutDir%"  >> %LogFilePath%

   ECHO copy Folder "%TargetDir%*" Vers  "%SolutionDir%..\SimplyDesk.ServiceDesk.BusinessComponents.Tests\%OutDir%" >> %LogFilePath%
  xcopy /y "%TargetDir%*"  "%SolutionDir%..\SimplyDesk.ServiceDesk.BusinessComponents.Tests\%OutDir%"  >> %LogFilePath%
 )

 if %ProjectName%==SimplyDesk.Framework.UnitTests (
     	
	 ECHO copy File "%TargetDir%\..\..\NLog.config" Vers "%TargetDir%\NLog.config" >> %LogFilePath%
     copy "%TargetDir%\..\..\NLog.config" "%TargetDir%\NLog.config" /Y >> %LogFilePath%
	 
	 ECHO copy File "%TargetDir%\..\..\log4net.config" Vers "%TargetDir%\log4net.config" >> %LogFilePath%
     copy "%TargetDir%\..\..\log4net.config" "%TargetDir%\log4net.config" /Y >> %LogFilePath%

)

REM SimplyDesk.Framework.BuildTool contain all nuget in the framework solution (For that we copy the result of the build of this project to SimplyDesk.Framework folder)
if %ProjectName%==SimplyDesk.Framework.BuildTool (
  ECHO copy folder "%TargetDir%*" vers "%SolutionDir%..\Binaries\SimplyDesk.Framework">> %LogFilePath%
  xcopy /y "%TargetDir%*" "%SolutionDir%..\Binaries\SimplyDesk.Framework" >> %LogFilePath%
)







:EndOfScript



