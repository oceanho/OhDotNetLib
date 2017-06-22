#
# NugetPackTask.ps1
#

$NugetKey="$ENV:NUGETAPIKEY"
$NugetSvr="https://www.nuget.org/api/v2/package"

$NugetPack="../../packs"
$CsProject="../../src/OhDotNetLib/OhDotNetLib.csproj"

Function BuildProj($Configuration="Debug"){
	Invoke-Expression "dotnet restore $CsProject"
	Invoke-Expression "dotnet build -c $Configuration  $CsProject"
}

Function CreateBetaPack {
	ClearNugetPack
	BuildProj -Configuration "Debug"
	Invoke-Expression "dotnet pack --output $NugetPack -c Debug --include-symbols --version-suffix '-Beta' $CsProject"
}

Function CreateAlphaPack {
	ClearNugetPack
	BuildProj -Configuration "Debug"
	Invoke-Expression "dotnet pack --output $NugetPack --include-symbols --version-suffix '-Alpha' $CsProject"
}

Function CreateReleasePack {
	ClearNugetPack
	BuildProj -Configuration "Release"
	Invoke-Expression "dotnet pack --output $NugetPack -c Release  $CsProject"
}

Function ClearNugetPack {
	If (Test-Path $NugetPack){
		Remove-Item "$NugetPack/*.nupkg" > $null
	}
}

Function PublishNugetPack {
	If ($NugetKey -eq ""){
		Write-Warning -Message "Nuget.org Api Key not set.Your need to set an Key of NUGETAPIKEY system enveriment veriable"
		Return
	}
	If ((Test-Path -PathType Leaf "$NugetPack/*.nupkg") -eq $false){
		Write-Error -Message "Your should be build nuget pack first by Create[Beta/Alpha/Release]Pack function"
		Return
	}
	Get-ChildItem "$NugetPack/*.nupkg" | ForEach-Object -Process {
		Invoke-Expression "dotnet nuget push $_ -s $NugetSvr -k $NugetKey"
	}
}