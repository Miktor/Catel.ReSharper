#define AppName "Catel.Resharper"
#define SourceDirectory ""
#define AppVersion "1.1"
#define AppVersionAsText "1.1"
#define Website "http://catel.codeplex.com"
#define OutputPrefix "catel.resharper"
#define Company "CatenaLogic"

#define ResharperRoot ReadReg(HKEY_LOCAL_MACHINE, "Software\JetBrains\ReSharper\v7.0\", "InstallDir", "")
#define OutputFileWithSpaces OutputPrefix + "_" + AppVersionAsText
#define OutputFile StringChange(OutputFileWithSpaces, " ", "_")

[_ISTool]
EnableISX=false
Use7zip=false

[Setup]
AppName={#AppName}
AppVerName={#AppName} {#AppVersionAsText}
AppID={#AppName}
AppPublisher={#Company}
AppCopyright={#Company}
DefaultDirName={pf32}\{#AppName} {#AppVersion}
DefaultGroupName={#AppName}
UsePreviousSetupType=true
OutputDir=..\output
OutputBaseFilename={#OutputFile}
UninstallDisplayName={#AppName}
Compression=lzma2/Ultra64
UseSetupLdr=true
SolidCompression=true
ShowLanguageDialog=yes
VersionInfoVersion={#AppVersion}
AppVersion={#AppVersionAsText}
InternalCompressLevel=Ultra64
AppPublisherURL={#Website}
AppSupportURL={#Website}
AppUpdatesURL={#Website}
AppContact={#Website}
VersionInfoCompany={#Company}
AppMutex={#AppName}
LanguageDetectionMethod=none
DisableStartupPrompt=True
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
SignTool=Signtool

[InnoIDE_Settings]
UseRelativePaths=true

[Dirs]
Name: {app}\doc;  
Name: {app}\resources;

Name: {#ResharperRoot}\Plugins; 

[Files]
Source: readme.txt; DestDir: {app};
Source: resources\*; DestDir: {app}\resources;
Source: resources\catel.ico; DestDir: {app}\resources;

Source: plugins\*; DestDir: {#ResharperRoot}\Plugins; Flags: createallsubdirs recursesubdirs;

[CustomMessages]
DotNetMissing=This setup requires the .NET Framework. Please download and install the .NET Framework and run this setup again. Do you want to download the framework now?
ResharperMissing=This setup requires ReSharper which is not found on this machine.

[ThirdPartySettings]
CompileLogMethod=append

[UninstallDelete]
Name: {app}; Type: filesandordirs

[Icons]
Name: "{group}\Go to Catel homepage"; Filename: http://catel.codeplex.com;
Name: "{group}\Documentation (online)"; Filename: http://catel.catenalogic.com;
Name: "{group}\Uninstall Catel.Resharper"; Filename: {app}\unins000.exe; WorkingDir: {app}; IconFilename: {app}\resources\catel.ico; 

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
	NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5'); 			// 3.5
	//NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4'); 			// 4.0

	// If the .NET framework is not installed, show message to user to download the framework
	if NetFrameWorkInstalled = false then
	begin
		if MsgBox(ExpandConstant('{cm:DotNetMissing}'), mbConfirmation, MB_YESNO) = idYes then
		begin
			ShellExec('open',
				//'http://www.microsoft.com/downloads/details.aspx?FamilyID=0856eacb-4362-4b0d-8edd-aab15c5e04f5&displaylang=en', // 2.0
				//'http://www.microsoft.com/downloads/details.aspx?FamilyID=10cc340b-f857-4a14-83f5-25634c3bf043&displaylang=en', // 3.0
				'http://www.microsoft.com/downloads/details.aspx?FamilyId=333325fd-ae52-4e35-b531-508d977d32a6&displaylang=en', // 3.5
				//'http://www.microsoft.com/downloads/details.aspx?familyid=9CFB2D51-5FF4-4491-B0E5-B386F32C0992&displaylang=en', // 4.0
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

function IsReSharperInstalled : Boolean;
var
    ErrorCode: Integer;
    ReSharperInstalled : Boolean;
begin
	ReSharperInstalled := RegKeyExists(HKLM,'Software\JetBrains\ReSharper\v7.0\');

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

