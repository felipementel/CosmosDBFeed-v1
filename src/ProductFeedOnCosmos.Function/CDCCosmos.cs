using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ProductFeedOnCosmos.Function
{
    public static class CDCCosmos
    {
        [FunctionName("CDCCosmos")]
        public static void Run([CosmosDBTrigger(
                        databaseName: "CanalDEPLOY",
            containerName: "products",
            Connection = "CosmosConnectionString",
            LeaseContainerName = "leases",
            CreateLeaseContainerIfNotExists = true)]IReadOnlyList<Document> input,
            ILogger log)
        {
            log.LogInformation("start of function");

            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
            }

            log.LogInformation("end of function");
        }
    }

    public class Document
    {
        public string Id { get; set; }
    }
}
