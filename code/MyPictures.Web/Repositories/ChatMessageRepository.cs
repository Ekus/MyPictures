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

namespace MyPictures.Web.Repositories
{
    using System.Linq;
    using MyPictures.Web.Models;
    using System;
    using Raven;
    using Raven.Client;
    using Raven.Client.Document;

    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly IStorageContext storageContext;
        private readonly IDocumentStore ravenDB;

        public ChatMessageRepository()
            : this(StorageContext.DefaultStorageContext())
        {
            ravenDB = new DocumentStore {
                 ConnectionStringName = "Raven"
            };
            ravenDB.Initialize();
        }

        public ChatMessageRepository(IStorageContext storageContext)
        {
            this.storageContext = storageContext;
        }

        //public IQueryable<ChatMessage> GetAll()
        //{
        //    return this.storageContext.Query<ChatMessage>(StorageAccountConfiguration.ChatMessagesTable);
        //}

        public IQueryable<ChatMessage> GetAll()
        {
            using (var session = ravenDB.OpenSession())
            {
                return session.Query<ChatMessage>();
            }                
        }


        public ChatMessage Get(string msgId)
        {
            return this.storageContext.Query<ChatMessage>(StorageAccountConfiguration.ChatMessagesTable).Where(t => t.RowKey.Equals(msgId)).FirstOrDefault();
        }

        public ChatMessage Save(ChatMessage msg)
        {
            this.storageContext.AddEntity(msg, StorageAccountConfiguration.ChatMessagesTable);

            using (var session = ravenDB.OpenSession())
            {
                session.Store(msg);
                session.SaveChanges();
            }
            return msg;
        }

    }
}