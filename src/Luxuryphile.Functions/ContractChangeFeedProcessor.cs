using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Luxuryphile.Functions;

public static class ContractChangeFeedProcessor
{
    [FunctionName("ContractChangeFeedProcessor")]
    public static async Task RunAsync([CosmosDBTrigger(
            databaseName: "luxuryphile-dev",
            collectionName: "contracts",
            ConnectionStringSetting = "CosmosDbConnectionString",
            LeaseCollectionName = "leases",
            CreateLeaseCollectionIfNotExists = true)]
        IReadOnlyList<Document> input, ILogger log)
    {
        if (input != null && input.Count > 0)
        {
            log.LogInformation("Documents modified " + input.Count);
            log.LogInformation("First document Id " + input[0].Id);
            
        }
    }
}