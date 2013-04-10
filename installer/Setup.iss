[_ISTool]
EnableISX=true

[Files]
Source: cycle.ico; DestDir: {app}
;Source: cycle_bike.png; DestDir: {app}
Source: EmpyrealNight.Core.dll; DestDir: {app}
;Source: endomondo32.png; DestDir: {app}
;Source: facebook32.png; DestDir: {app}
Source: failure-icon.png; DestDir: {app}
Source: FileHelpers.dll; DestDir: {app}
Source: Fit.dll; DestDir: {app}
;Source: garmin32.png; DestDir: {app}
;Source: garmin32_2.png; DestDir: {app}
Source: GarminConnectAPI.dll; DestDir: {app}
Source: HealthGraphNet.dll; DestDir: {app}
Source: log4net.dll; DestDir: {app}
Source: ListViewNF.dll; DestDir: {app}
Source: Moq.dll; DestDir: {app}
Source: Newtonsoft.Json.dll; DestDir: {app}
Source: Ninject.dll; DestDir: {app}
Source: Ninject.xml; DestDir: {app}
Source: nunit.core.dll; DestDir: {app}
Source: nunit.framework.dll; DestDir: {app}
Source: RestSharp.dll; DestDir: {app}
Source: RestSharp.xml; DestDir: {app}
;Source: ridewithgps.png; DestDir: {app}
;Source: ridewithgps32.png; DestDir: {app}
Source: runkeeper.html; DestDir: {app}
;Source: runkeeper.jpg; DestDir: {app}
;Source: runkeeper_icon.png; DestDir: {app}
;Source: runkeeper32.png; DestDir: {app}
;Source: runkeeper-disabled32.png; DestDir: {app}
;Source: runkeeperElite.png; DestDir: {app}
;Source: runkeeper-icon-2001.png; DestDir: {app}
;Source: strava_icon175-48x48.png; DestDir: {app}
;Source: strava_icon175-150x150.png; DestDir: {app}
;Source: strava32.png; DestDir: {app}
Source: Stravan.dll; DestDir: {app}
Source: success-icon.png; DestDir: {app}
Source: System.Json.dll; DestDir: {app}
Source: System.Json.xml; DestDir: {app}
Source: CycleUploader.exe; DestDir: {app}; DestName: CycleUploader.exe; Flags: 32bit
Source: ZedGraph.dll; DestDir: {app}
Source: CycleUploader.exe.config; DestDir: {app}
Source: Stravan.dll.config; DestDir: {app}
Source: System.Data.SQLite.dll; DestDir: {app}
Source: cycleuploader-empty.sqlite; DestDir: {app}; DestName: cycleuploader.sqlite; Flags: onlyifdoesntexist
Source: ListViewExtended.dll; DestDir: {app}
Source: isxdl.dll; Flags: dontcopy

[Setup]
VersionInfoVersion=1.0.25.5
VersionInfoDescription=Cycle Uploader
VersionInfoCopyright=Copyright © 2013
VersionInfoProductName=Cycle Uploader
VersionInfoProductVersion=1.0.25.5
AppCopyright=© 2013 Steven Saunders
AppName=Cycle Uploader
AppVerName=Cycle Uploader v1.0.25.5
SetupIconFile=cycle.ico
DefaultDirName={pf}\CycleUploader
OutputBaseFilename=CycleUploaderSetup
DefaultGroupName=Cycling
AppID={{8BB98761-E099-4479-B4E5-FFF5B76A2ADD}
AppContact=steven.n.saunders@gmail.com
UninstallDisplayIcon={app}\cycle.ico
[Icons]
Name: {group}\CycleUploader; Filename: {app}\CycleUploader.exe; WorkingDir: {app}; Comment: CycleUploader; Flags: createonlyiffileexists
[Run]
Filename: {app}\CycleUploader.exe; WorkingDir: {app}; Flags: postinstall 32bit nowait
[Registry]
Root: HKCU; Subkey: Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION; ValueType: dword; ValueName: CycleUploader.exe; ValueData: 9000; Flags: uninsdeletevalue createvalueifdoesntexist; Permissions: users-read
Root: HKLM; Subkey: Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION; ValueType: dword; ValueName: CycleUploader.exe; ValueData: 9000; Flags: uninsdeletevalue createvalueifdoesntexist; Permissions: users-read
[Dirs]
Name: {app}\; Permissions: users-modify

;Code to check for existance of .NET Framework 4.0
[Code]
var
dotnetRedistPath: string;
downloadNeeded: boolean;
dotNetNeeded: boolean;
memoDependenciesNeeded: string;

procedure isxdl_AddFile(URL, Filename: PChar);
external 'isxdl_AddFile@files:isxdl.dll stdcall';
function isxdl_DownloadFiles(hWnd: Integer): Integer;
external 'isxdl_DownloadFiles@files:isxdl.dll stdcall';
function isxdl_SetOption(Option, Value: PChar): Integer;
external 'isxdl_SetOption@files:isxdl.dll stdcall';

const
dotnetRedistURL = 'http://download.microsoft.com/download/9/5/A/95A9616B-7A37-4AF6-BC36-D6EA96C8DAAE/dotNetFx40_Full_x86_x64.exe';

function InitializeSetup(): Boolean;

begin
	Result := true;
	dotNetNeeded := false;

	// Check for required netfx installation
	if (not RegKeyExists(HKLM, 'Software\Microsoft\.NETFramework\policy\v4.0')) then begin
	dotNetNeeded := true;
	if (not IsAdminLoggedOn()) then begin
	MsgBox('This application needs the Microsoft .NET Framework v4.0 to be installed by an Administrator', mbInformation, MB_OK);
	Result := false;
	end else begin
	memoDependenciesNeeded := memoDependenciesNeeded + ' .NET Framework v4.0' #13;
	dotnetRedistPath := ExpandConstant('{src}\dotnetfx.exe');
	if not FileExists(dotnetRedistPath) then begin
	dotnetRedistPath := ExpandConstant('{tmp}\dotnetfx.exe');
	if not FileExists(dotnetRedistPath) then begin
	isxdl_AddFile(dotnetRedistURL, dotnetRedistPath);
	downloadNeeded := true;
	end;
	end;
	SetIniString('install', 'dotnetRedist', dotnetRedistPath, ExpandConstant('{tmp}\dep.ini'));
	end;
	end;

end;

function NextButtonClick(CurPage: Integer): Boolean;
var
hWnd: Integer;
ResultCode: Integer;

begin
Result := true;

if CurPage = wpReady then begin

hWnd := StrToInt(ExpandConstant('{wizardhwnd}'));

// don't try to init isxdl if it's not needed because it will error on < ie 3
if downloadNeeded then begin

isxdl_SetOption('label', 'Downloading Microsoft .NET Framework v4.0');
isxdl_SetOption('description', 'This application needs to install the Microsoft .NET Framework v4.0. Please wait while Setup is downloading extra files to your computer.');
if isxdl_DownloadFiles(hWnd) = 0 then Result := false;
end;
if (Result = true) and (dotNetNeeded = true) then begin
if Exec(ExpandConstant(dotnetRedistPath), '', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then begin
// handle success if necessary; ResultCode contains the exit code
if not (ResultCode = 0) then begin
Result := false;
end;
end else begin
// handle failure if necessary; ResultCode contains the error code
Result := false;
end;
end;
end;
end;

function UpdateReadyMemo(Space, NewLine, MemoUserInfoInfo, MemoDirInfo, MemoTypeInfo, MemoComponentsInfo, MemoGroupInfo, MemoTasksInfo: String): String;
var
s: string;

begin
if memoDependenciesNeeded <> '' then s := s + 'Dependencies to install:' + NewLine + memoDependenciesNeeded + NewLine;
s := s + MemoDirInfo + NewLine + NewLine;

Result := s
end;
