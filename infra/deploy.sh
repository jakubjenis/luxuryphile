# create subscription manually
# get subscription ID: 05b77f0d-8c60-44fb-8d5e-55b9f217c2b4

# create azure container registry manually?

#az login - ms account

# create service principal
az ad sp create-for-rbac --name "sp-luxuryphile-cicd" --role contributor --scopes /subscriptions/05b77f0d-8c60-44fb-8d5e-55b9f217c2b4 --sdk-auth
#az ad sp create-for-rbac --name "sp-luxuryphile-cicd" --role contributor --scopes /subscriptions/05b77f0d-8c60-44fb-8d5e-55b9f217c2b4

# to simulate gihub cicd service principal
az login --service-principal -u 2c4c4130-4e40-49c0-a5b3-39bcb885692c -p GQi8Q~CaAV7z1HfxoMCipTsvg3_Ixd1W3tSW3aiW --tenant 3e99d814-4191-4746-bd8b-ded95a1ef35e

az deployment sub create \
    --location 'westeurope' \
    --template-file ./main.bicep  \
    --name 'deploy-luxuryfile-bicep' \
    --parameters location=westeurope \
    --parameters rgName=rg-luxuryphile-bicep \
    --parameters webAppName=luxuryphile-1234 \
    --parameters appServicePlanTier=Free \
    --parameters appServicePlanSku=F1 \
    --parameters dockerRegistryHost=luxuryphile.azurecr.io \
    --parameters dockerRegistryServerUsername=luxuryphile \
    --parameters dockerRegistryServerPassword=lBOIDQPkTJlI4WkfZlXJMuuRSXDfNsfguflVZmUJnN+ACRBCkH9r \
    --parameters dockerImage=luxuryphile/web:60e2135306571fb0b839e891b7d2dd787382bf66

az deployment sub delete --name deploy-luxuryfile-bicep