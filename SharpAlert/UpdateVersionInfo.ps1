$versionInfoTemplatePath = ".\VersionInfoTemplate.cs"
$versionInfoPath = ".\VersionInfo.cs"

$currentDate = Get-Date -Format "yyyy-MM-dd"
$currentTime = Get-Date -Format "HH:mm"
$timeZone = Get-TimeZone
$timeId = $timeZone.Id

$content = Get-Content $versionInfoTemplatePath
$contentNew = Get-Content $versionInfoPath

$currentBuildNumber = [regex]::Match($contentNew, 'public const int BuildNumber = (\d+);').Groups[1].Value
$incrementedBuildNumber = [int]$currentBuildNumber + 1

$content = $content -replace 'BuiltOnDate = "";', "BuiltOnDate = `"$currentDate`";"
$content = $content -replace 'BuiltOnTime = "";', "BuiltOnTime = `"$currentTime`";"
$content = $content -replace 'BuiltTimeZone = "";', "BuiltTimeZone = `"$timeId`";"
$content = $content -replace 'public const int BuildNumber = \d+;', "public const int BuildNumber = $incrementedBuildNumber;"
$content = $content -replace 'class VersionInfoTemplate', 'class VersionInfo'
$content = $content -replace '// Do not change consts!', '// Use VersionInfoTemplate.cs!'

Set-Content $versionInfoPath $content