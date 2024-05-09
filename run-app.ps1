$projectPath = "Backend/Src/Technical.Interview.WebApi"
$currentPath = Get-Location
$fullProjectPath = Join-Path -Path $currentPath -ChildPath $projectPath
Write-Host "Running project from path: $fullProjectPath"
cd $fullProjectPath
dotnet run release