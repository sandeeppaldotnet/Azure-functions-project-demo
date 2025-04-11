# Azure Functions Demo Project - ASP.NET Core (C#)

This repository is a collection of Azure Functions demonstrating various trigger types using **C# and ASP.NET Core**. Each function showcases how to integrate with different Azure services, providing a practical starting point for building serverless applications on Azure.

## 🚀 Trigger Types Included

| Trigger Type         | Description |
|----------------------|-------------|
| **HTTP Trigger**     | Responds to HTTP requests. Ideal for APIs and webhooks. |
| **Timer Trigger**    | Executes on a scheduled interval (cron). Useful for background jobs. |
| **Blob Trigger**     | Runs when a new blob is added or updated in Azure Blob Storage. |
| **Queue Trigger**    | Processes messages from Azure Storage Queues. |
| **Service Bus Trigger** | Listens to Azure Service Bus queues or topics. Great for messaging between services. |
| **Event Grid Trigger** | Handles events from Azure services like Blob Storage or custom topics. |
| **Event Hub Trigger** | Consumes data from Azure Event Hubs. Ideal for telemetry and event streaming. |
| **Cosmos DB Trigger** | Reacts to inserts and updates in a Cosmos DB collection. |

## 🛠️ Project Structure

AzureFunctionsDemo/ │ ├── HttpTriggerExample/ ├── TimerTriggerExample/ ├── BlobTriggerExample/ ├── QueueTriggerExample/ ├── ServiceBusTriggerExample/ ├── EventGridTriggerExample/ ├── EventHubTriggerExample/ └── CosmosDBTriggerExample/


Each folder contains a function with its respective trigger, input/output bindings, and logic.

## 📦 Prerequisites

- [.NET 6 SDK or later](https://dotnet.microsoft.com/download)
- [Azure Functions Core Tools](https://learn.microsoft.com/azure/azure-functions/functions-run-local)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) with Azure Functions extension
- Azure Subscription (for deploying and testing in the cloud)

## ▶️ Running Locally

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/azure-functions-demo.git
   cd azure-functions-demo
Start the functions:

bash
Copy
Edit
func start
Use tools like Postman, curl, or Azure Storage Explorer to test each trigger.

☁️ Deployment
To deploy to Azure:

bash
Copy
Edit
func azure functionapp publish <YourFunctionAppName>
Make sure the required resources (e.g., blob containers, queues, Event Hubs) are created and connected via local.settings.json or Azure portal configuration.

📄 Configuration
Use local.settings.json to configure connection strings and settings during local development.

json
Copy
Edit
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "BlobStorageConnection": "<your_connection_string>",
    "QueueStorageConnection": "<your_connection_string>",
    "ServiceBusConnection": "<your_connection_string>",
    "EventHubConnection": "<your_connection_string>",
    "CosmosDBConnection": "<your_connection_string>"
  }
}
⚠️ Don't commit local.settings.json to source control.

🙌 Contributions
Feel free to fork, improve, and submit pull requests. Contributions are welcome!

📄 License
This project is licensed under the MIT License.
