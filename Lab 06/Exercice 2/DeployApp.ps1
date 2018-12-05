param(
[string]$resourceGroup ,
[string]$hostingPlan ,
[string]$applicationName ,
[string]$dockerCustomImageName ,
[string]$dockerRegistryServerUrl ,
[string]$dockerRegistryServerUser ,
[string]$dockerRegistryServerPassword,
[string]$tenantId,
[string]$principalUsername,
[string]$principalPassword
)

#login to Azure user a PrincipalId
az login --service-principal -u $principalUsername --password $principalPassword --tenant $tenantId
#Create a Container based Web App
az webapp create --resource-group $resourceGroup --plan $hostingPlan --name $applicationName --deployment-container-image-name $dockerCustomImageName
#Allow the web app to login to the customer Azure Container Registry
az webapp config container set --name $applicationName --resource-group $resourceGroup --docker-custom-image-name $dockerCustomImageName --docker-registry-server-url $dockerRegistryServerUrl --docker-registry-server-user $dockerRegistryServerUser --docker-registry-server-password $dockerRegistryServerPassword