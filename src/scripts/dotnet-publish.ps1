Set-Location ..
Get-Location
dotnet publish ./Course.Feedback -c Release -o ./bin/app
dotnet publish ./Course.Files -c Release -o ./bin/app
dotnet publish ./Course.Identity -c Release -o ./bin/app
dotnet publish ./Course.Notification -c Release -o ./bin/app
dotnet publish ./Course.Api -c Release -o ./bin/app