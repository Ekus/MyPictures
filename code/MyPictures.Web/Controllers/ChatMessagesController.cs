// ---------------------------------------------------------------------------------- 
// Microsoft Developer & Platform Evangelism 
//  
// Copyright (c) Microsoft Corporation. All rights reserved. 
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,  
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES  
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
// ---------------------------------------------------------------------------------- 
// The example companies, organizations, products, domain names, 
// e-mail addresses, logos, people, places, and events depicted 
// herein are fictitious.  No association with any real company, 
// organization, product, domain name, email address, logo, person, 
// places, or events is intended or should be inferred. 
// ---------------------------------------------------------------------------------- 


namespace MyPictures.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using MyPictures.Web.Models;
    using MyPictures.Web.Repositories;

    public class ChatMessagesController : ApiController
    {
        private readonly IChatMessageRepository repository;

        public ChatMessagesController()
            : this(new ChatMessageRepository())
        {
        }

        public ChatMessagesController(IChatMessageRepository repository)
        {
            this.repository = repository;
        }

        // GET /api/ChatMessages
        public List<ChatMessage> Get()
        {
            var result = this.repository.GetAll();//.OrderByDescending(ch => ch.Timestamp).Take(100); // client will probably reverse the display order but that's beyond our scope
            return result.ToList();
        }

        // GET /api/ChatMessages/ChatMessage1
        public ChatMessage Get(string name)
        {
            return this.repository.Get(name);
        }

        // POST /api/ChatMessages
        public ChatMessage Post([FromBody]ChatMessage msg)
        {
             this.repository.Save(msg);
                return msg;

          //try
          //          {
             
            //    CloudStorageAccount storageAccount =
            //       CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=<your_storage_name>;AccountKey=<your_account_key>");
            //    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            //    CloudTable table = tableClient.GetTableReference("people");
            //    table.CreateIfNotExists();

            //    CustomerEntity customer1 = new CustomerEntity("Harp", "Walter");
            //    customer1.Email = "Walter@contoso.com";
            //    customer1.PhoneNumber = "425-555-0101";

            //    // Create the TableOperation that inserts the customer entity.
            //    var insertOperation = TableOperation.Insert(customer1);

            //    // Execute the insert operation.
            //    table.Execute(insertOperation);

            //    // Read storage
            //    TableQuery<CustomerEntity> query =
            //       new TableQuery<CustomerEntity>()
            //          .Where(TableQuery.GenerateFilterCondition("PartitionKey",
            //              QueryComparisons.Equal, "Harp"));
            //    var list = table.ExecuteQuery(query).ToList();
            //}
            //catch (StorageException ex)
            //{
            //    // Exception handling here.
            //}

            
        }

    }
}