# Exécuter avec Windows PowerShell (.NET Framework), après compilation de la solution :
# powershell.exe -NoProfile -STA -ExecutionPolicy Bypass -File .\Tests\Verifier-Ihm.ps1
$ErrorActionPreference = 'Stop'
Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing
$racine = Split-Path -Parent $PSScriptRoot
$bin = Join-Path $racine "Veterin'air\UIVeterin'air\bin\Debug"
$testDir = Join-Path $env:TEMP ('veterinair-tests-' + [Guid]::NewGuid().ToString('N'))
[void](New-Item -ItemType Directory -Path $testDir)
$dllPath = Join-Path $testDir 'Veterin_air.dll'
$exePath = Join-Path $testDir 'UIVeterin_air.dll'
Copy-Item -LiteralPath (Join-Path $bin 'Veterin_air.dll') -Destination $dllPath
# Add-Type accepte une référence .dll ; il s'agit de l'assembly de l'application compilée.
Copy-Item -LiteralPath (Join-Path $bin 'UIVeterin_air.exe') -Destination $exePath
[void][System.Reflection.Assembly]::LoadFrom($dllPath)
[void][System.Reflection.Assembly]::LoadFrom($exePath)
$testSource = Get-Content -LiteralPath (Join-Path $PSScriptRoot 'TestsIntegration.cs') -Raw -Encoding UTF8
Add-Type -TypeDefinition $testSource -ReferencedAssemblies @('System.Windows.Forms', 'System.Drawing', $dllPath, $exePath)
$previewPath = Join-Path $testDir 'apercu-ihm.png'
[UiChecks]::Run($previewPath)
Write-Output ("Aperçu : " + $previewPath)
