targetScope = 'subscription'

param rgName string
param location string = 'westeurope'
param appServicePlanTier string
param appServicePlanSku string

param dockerRegistryHost string
param dockerRegistryServerUsername string
@secure()
param dockerRegistryServerPassword string
param dockerImage string

param webAppName string = 'luxuryphile'

resource rg 'Microsoft.Resources/resourceGroups@2022-09-01' = {
  name: rgName
  location: location
}

module WebApp './docker_webapp_linux.bicep' = {
  name: 'luxuryphile-web'
  scope: resourceGroup(rg.name)
  params: {
    location: location
    webAppName: webAppName
    appServicePlanTier: appServicePlanTier
    appServicePlanSku: appServicePlanSku
    dockerRegistryHost: dockerRegistryHost
    dockerRegistryServerUsername: dockerRegistryServerUsername
    dockerRegistryServerPassword: dockerRegistryServerPassword
    dockerImage: dockerImage
  }
}
