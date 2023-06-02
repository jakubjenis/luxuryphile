param webAppName string = 'mywebapp'
param location string = 'westeurope'
param appServicePlanTier string = 'Standard'
param appServicePlanSku string = 'S1'
param dockerRegistryHost string = 'yourregistry.azurecr.io'

var appServicePlanName = toLower('appsvc-${webAppName}')
var webSiteName = toLower('${webAppName}')

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

