param location string = 'westeurope'

param appServicePlanTier string
param appServicePlanSku string

param dockerRegistryHost string
param dockerRegistryServerUsername string
@secure()
param dockerRegistryServerPassword string
param dockerImage string

param webAppName string
var appServicePlanName = toLower('asp-${webAppName}')
var webSiteName = toLower('${webAppName}')

//App service plan
resource appServicePlan 'Microsoft.Web/serverfarms@2020-06-01' = {
  name: appServicePlanName
  location: location
  properties: {
    reserved: true
  }
  sku: {
    tier: appServicePlanTier
    name: appServicePlanSku
  }
  kind: 'linux'
}

//Azure web app
resource appService 'Microsoft.Web/sites@2021-02-01' = {
  name: webSiteName
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      appSettings: [
        {
          name: 'DOCKER_REGISTRY_SERVER_URL'
          value: 'https://${dockerRegistryHost}'
        }
        {
          name: 'DOCKER_REGISTRY_SERVER_USERNAME'
          value: dockerRegistryServerUsername
        }
        {
          name: 'DOCKER_REGISTRY_SERVER_PASSWORD'
          value: dockerRegistryServerPassword
        }
      ]
      linuxFxVersion:  'DOCKER|${dockerRegistryHost}/${dockerImage}'
    }
  }
}
