param(
[string]$resourceGroup ,
[string]$applicationName ,
[string]$settingName,
[string]$settingValue
)
az webapp config appsettings set --name $applicationName --resource-group $resourceGroup --settings "$settingName=$settingValue"