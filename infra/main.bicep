targetScope = 'subscription'

param location string = 'westeurope'
param rgName string = 'rg-luxuryphile-bicep'
// param webAppName string = 'mywebapp'
// param appServicePlanTier string = 'Standard'
// param appServicePlanSku string = 'S1'
// param dockerRegistryHost string = 'yourregistry.azurecr.io'
// param dockerRegistryServerUsername string = 'yourregistry'
// param dockerRegistryServerPassword string = 'somepassword'
// param dockerImage string = 'imagename'

resource rg 'Microsoft.Resources/resourceGroups@2022-09-01' = {
  name: rgName
  location: location

}

module WebApp './webapp.bicep' = {
  name: 'dfs'
  scope: resourceGroup(rg.name)
  params: {
    location: location
  }
}
