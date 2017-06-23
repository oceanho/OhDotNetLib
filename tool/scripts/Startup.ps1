Import-Module .\NugetPackTask.ps1 -Force -Verbose
Set-Location -Path $(Split-Path -Parent $MyInvocation.MyCommand.Definition)
Clear
$cmdList = "Command List:`n
1. BuildProj
2. CreateBetaPack
3. CreateAlphaPack
4. CreateReleasePack
5. ClearNugetPack
6. PublishNugetPack
7. Exited
"
Write-Host "
=====================================================
OceanHo's nuget tools for dotnet writed by PowerShell
====================================================="
While ($true) {
	Write-Host $cmdList
	$cmd = Read-Host "Input Command Index£¨1-7£©or PowerShell Command"
	If ($cmd -eq "1"){
		BuildProj
		Continue
	}
	ElseIf ($cmd -eq "2"){
		CreateBetaPack
		Continue
	}
	ElseIf ($cmd -eq "3"){
		CreateAlphaPack
		Continue
	}
	ElseIf ($cmd -eq "4"){
		CreateReleasePack
		Continue
	}
	ElseIf ($cmd -eq "5"){
		ClearNugetPack
		Continue
	}
	ElseIf ($cmd -eq "6"){
		PublishNugetPack
		Continue
	}
	ElseIf ($cmd -eq "7"){
		Break		
	}
	If ([System.String]::IsNullOrEmpty($cmd) -eq $false) {
		Invoke-Expression $cmd
		Write-Host "-----------------------------------------------------------------------"
	}
}