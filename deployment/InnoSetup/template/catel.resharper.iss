#define AppName "Catel.ReSharper"
#define SourceDirectory ""
;#define AppVersion "1.0"
#define AppVersion "[VERSION]"
;#define AppDisplayVersion "1.0"
#define AppDisplayVersion "[VERSION_DISPLAY]"
#define AppNameWithDisplayVersion AppName + " " + AppDisplayVersion
#define AppNameWithVersion AppName + " " + AppVersion
#define Website "http://www.catelproject.com"
#define OutputPrefix "catel.resharper"
#define Company "CatenaLogic"

#define OutputFileWithSpaces OutputPrefix + "_" + AppDisplayVersion
#define OutputFile StringChange(OutputFileWithSpaces, " ", "_")

#define ReSharper60RegistryRoot "Software\JetBrains\ReSharper\v6.0\"
#define ReSharper61RegistryRoot "Software\JetBrains\ReSharper\v6.1\"
#define ReSharper70RegistryRoot "Software\JetBrains\ReSharper\v7.0\"
#define ReSharper71RegistryRoot "Software\JetBrains\ReSharper\v7.1\"
#define ReSharper80RegistryRoot "Software\JetBrains\ReSharper\v8.0\"
;#define ReSharper81RegistryRoot "Software\JetBrains\ReSharper\v8.1\"

#define ReSharper60InstallDir ReadReg(HKEY_LOCAL_MACHINE, ReSharper60RegistryRoot, "InstallDir", "")
#define ReSharper61InstallDir ReadReg(HKEY_LOCAL_MACHINE, ReSharper61RegistryRoot, "InstallDir", "")
#define ReSharper70InstallDir ReadReg(HKEY_LOCAL_MACHINE, ReSharper70RegistryRoot, "InstallDir", "")
#define ReSharper71InstallDir ReadReg(HKEY_LOCAL_MACHINE, ReSharper71RegistryRoot, "InstallDir", "")
#define ReSharper80InstallDir ReadReg(HKEY_LOCAL_MACHINE, ReSharper80RegistryRoot, "InstallDir", "")
;#define ReSharper81InstallDir ReadReg(HKEY_LOCAL_MACHINE, ReSharper81RegistryRoot, "InstallDir", "")

[_ISTool]
EnableISX=false
Use7zip=false

[Setup]
AppName={#AppNameWithVersion}
AppVerName={#AppNameWithDisplayVersion}
AppID={#AppNameWithVersion}
AppPublisher={#Company}
AppCopyright={#Company}
DefaultDirName={pf32}\{#AppNameWithVersion}
DefaultGroupName={#AppNameWithVersion}
UsePreviousSetupType=true
OutputDir=..\output
OutputBaseFilename={#OutputFile}
UninstallDisplayName={#AppNameWithVersion}
Compression=lzma2/Ultra64
UseSetupLdr=true
SolidCompression=true
ShowLanguageDialog=yes
VersionInfoVersion={#AppVersion}
AppVersion={#AppVersion}
InternalCompressLevel=Ultra64
AppPublisherURL={#Website}
AppSupportURL={#Website}
AppUpdatesURL={#Website}
AppContact={#Website}
VersionInfoCompany={#Company}
AppMutex={#AppNameWithVersion}
LanguageDetectionMethod=none
DisableStartupPrompt=True
;WizardImageFile=resources\[WIZARDIMAGEFILE].bmp
WizardImageFile=resources\logo_large.bmp
;WizardImageFile=resources\logo_large_beta.bmp
;WizardImageFile=resources\logo_large_rc.bmp
WizardSmallImageFile=resources\logo_small.bmp
SetupIconFile=resources\catel.ico
UninstallDisplayIcon={app}\resources\catel.ico
SetupLogging=true
; For signing, the following sign tool must be configured
; Name: Signtool
; Command: "C:\Source\CatenaLogic_Certificates\Tools\signtool.exe" sign /t "http://timestamp.comodoca.com/authenticode" /f "C:\Source\CatenaLogic_Certificates\CodeSigning\current.pfx" "$f"
; SignTool=Signtool

[InnoIDE_Settings]
UseRelativePaths=true

[Dirs]
Name: "{app}\doc"
Name: "{app}\resources"

Name: "{#ReSharper60InstallDir}\Plugins"; Components: ReSharper60
Name: "{#ReSharper61InstallDir}\Plugins"; Components: ReSharper61
Name: "{#ReSharper70InstallDir}\Plugins"; Components: ReSharper70
Name: "{#ReSharper71InstallDir}\Plugins"; Components: ReSharper71
Name: "{#ReSharper80InstallDir}\Plugins"; Components: ReSharper80
;Name: "{#ReSharper81InstallDir}\Plugins"; Components: ReSharper81

[Files]
Source: readme.txt; DestDir: {app};
Source: resources\*; DestDir: {app}\resources;
Source: resources\catel.ico; DestDir: {app}\resources;

Source: plugins\v6.0\*; DestDir: {#ReSharper60InstallDir}\Plugins; Flags: createallsubdirs recursesubdirs; Components: ReSharper60
Source: plugins\v6.1\*; DestDir: {#ReSharper61InstallDir}\Plugins; Flags: createallsubdirs recursesubdirs; Components: ReSharper61
Source: plugins\v7.0\*; DestDir: {#ReSharper70InstallDir}\Plugins; Flags: createallsubdirs recursesubdirs; Components: ReSharper70
Source: plugins\v7.1\*; DestDir: {#ReSharper71InstallDir}\Plugins; Flags: createallsubdirs recursesubdirs; Components: ReSharper71
Source: plugins\v8.0\*; DestDir: {#ReSharper80InstallDir}\Plugins; Flags: createallsubdirs recursesubdirs; Components: ReSharper80
;Source: plugins\v8.1\*; DestDir: {#ReSharper81InstallDir}\Plugins; Flags: createallsubdirs recursesubdirs; Components: ReSharper81

[CustomMessages]
DotNetMissing=This setup requires the .NET Framework. Please download and install the .NET Framework and run this setup again. Do you want to download the framework now?
ResharperMissing=This setup requires ReSharper which is not found on this machine.

[ThirdPartySettings]
CompileLogMethod=append

[UninstallDelete]
Name: {app}; Type: filesandordirs

[Icons]
Name: "{group}\Go to Catel website"; Filename: http://www.catelproject.com;
Name: "{group}\Documentation (online)"; Filename: http://www.catelproject.com/support/documentation;
Name: "{group}\Uninstall {#AppName}"; Filename: {app}\unins000.exe; WorkingDir: {app}; IconFilename: {app}\resources\catel.ico; 

[Languages]
Name: "English"; MessagesFile: "compiler:Default.isl"
Name: "Czech"; MessagesFile: "compiler:Languages\Czech.isl"
Name: "Danish"; MessagesFile: "compiler:Languages\Danish.isl"
Name: "Dutch"; MessagesFile: "compiler:Languages\Dutch.isl"
Name: "Finnish"; MessagesFile: "compiler:Languages\Finnish.isl"
Name: "French"; MessagesFile: "compiler:Languages\French.isl"
Name: "German"; MessagesFile: "compiler:Languages\German.isl"
Name: "Hungarian"; MessagesFile: "compiler:Languages\Hungarian.isl"
Name: "Italian"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "Japanese"; MessagesFile: "compiler:Languages\Japanese.isl"
Name: "Norwegian"; MessagesFile: "compiler:Languages\Norwegian.isl"
Name: "Polish"; MessagesFile: "compiler:Languages\Polish.isl"
Name: "Portuguese"; MessagesFile: "compiler:Languages\Portuguese.isl"
Name: "Russian"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "Spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[ThirdParty]
CompileLogMethod=append

[Components]
Name: "ReSharper60"; Description: "ReSharper 6.0"; Types: full compact custom; Check: IsReSharper60Installed
Name: "ReSharper61"; Description: "ReSharper 6.1"; Types: full compact custom; Check: IsReSharper61Installed
Name: "ReSharper70"; Description: "ReSharper 7.0"; Types: full compact custom; Check: IsReSharper70Installed
Name: "ReSharper71"; Description: "ReSharper 7.1"; Types: full compact custom; Check: IsReSharper71Installed
Name: "ReSharper80"; Description: "ReSharper 8.0"; Types: full compact custom; Check: IsReSharper80Installed
;Name: "ReSharper81"; Description: "ReSharper 8.1"; Types: full compact custom; Check: IsReSharper81Installed

[Code]
//=========================================================================
// IsDotNetFrameworkInstalled
//=========================================================================
{
	Checks whether the right version of the .NET framework is installed
}

function IsDotNetFrameworkInstalled : Boolean;
var
    ErrorCode: Integer;
    NetFrameWorkInstalled : Boolean;
begin
	// Check if the .NET framework is installed
	//NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727'); 	// 2.0
	//NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.0'); 		// 3.0
	//NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5'); 			// 3.5
	NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4'); 			// 4.0

	// If the .NET framework is not installed, show message to user to download the framework
	if NetFrameWorkInstalled = false then
	begin
		if MsgBox(ExpandConstant('{cm:DotNetMissing}'), mbConfirmation, MB_YESNO) = idYes then
		begin
			ShellExec('open',
				//'http://www.microsoft.com/downloads/details.aspx?FamilyID=0856eacb-4362-4b0d-8edd-aab15c5e04f5&displaylang=en', // 2.0
				//'http://www.microsoft.com/downloads/details.aspx?FamilyID=10cc340b-f857-4a14-83f5-25634c3bf043&displaylang=en', // 3.0
				//'http://www.microsoft.com/downloads/details.aspx?FamilyId=333325fd-ae52-4e35-b531-508d977d32a6&displaylang=en', // 3.5
				'http://www.microsoft.com/downloads/details.aspx?familyid=9CFB2D51-5FF4-4491-B0E5-B386F32C0992&displaylang=en', // 4.0
				'','',SW_SHOWNORMAL,ewNoWait,ErrorCode);
		end;
	end;

	// Return result
	Result := NetFrameWorkInstalled;
end;

//=========================================================================
// IsReSharperInstalled
//=========================================================================
{
	Checks whether ReSharper is installed
}

function IsReSharper60Installed : Boolean;
begin
	Result := RegKeyExists(HKLM,'{#ReSharper60RegistryRoot}');
end;

function IsReSharper61Installed : Boolean;
begin
	Result := RegKeyExists(HKLM,'{#ReSharper61RegistryRoot}');
end;

function IsReSharper70Installed : Boolean;
begin
	Result := RegKeyExists(HKLM,'{#ReSharper70RegistryRoot}');
end;

function IsReSharper71Installed : Boolean;
begin
	Result := RegKeyExists(HKLM,'{#ReSharper71RegistryRoot}');
end;

function IsReSharper80Installed : Boolean;
begin
	Result := RegKeyExists(HKLM,'{#ReSharper80RegistryRoot}');
end;

function IsReSharper81Installed : Boolean;
begin
	Result := RegKeyExists(HKLM,'{#ReSharper81RegistryRoot}');
end;

function IsReSharperInstalled : Boolean;
var
    ReSharperInstalled : Boolean;
begin
  ReSharperInstalled := IsReSharper60Installed() Or 
                        IsReSharper61Installed() Or  
                        IsReSharper70Installed() Or 
                        IsReSharper71Installed() Or  
                        IsReSharper80Installed() Or  
                        IsReSharper81Installed();

	if ReSharperInstalled = false then
	begin
		MsgBox(ExpandConstant('{cm:ResharperMissing}'), mbConfirmation, MB_OK);
	end;

	// Return result
	Result := ReSharperInstalled;
end;

//=========================================================================
// INITIALIZESETUP
//=========================================================================
{
	This function initializes the setup.
}

function InitializeSetup(): Boolean;
var
  sPrevPath: String;
begin
  // Check .NET framework
  if (IsDotNetFrameworkInstalled() = false) then
  begin
	  Result := false;
	  exit;
  end;

  // Check ReSharper
  if (IsReSharperInstalled() = false) then
  begin
	  Result := false;
	  exit;
  end;

  Result := true;
end;

