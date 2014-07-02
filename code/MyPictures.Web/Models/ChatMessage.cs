using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPictures.Web.Repositories;
using System.Data.Services.Common;

namespace MyPictures.Web.Models
{

       [DataServiceEntity]
    [DataServiceKey(new[] { "PartitionKey", "RowKey" })]
    public class ChatMessage : ITableServiceEntity
    {
        public string AuthorId { get; set;}
        public string Text { get; set;}
        //public ChatMessage(string authorId, string text)
        //{
        //    PartitionKey = authorId;
        //    RowKey = firstName;
        //}

        public ChatMessage() {
            this.PartitionKey = "chatMessages"; //global
            this.RowKey = Guid.NewGuid().ToString();
        }

        public string PartitionKey
        {
            get;
            set;
        }

        public string RowKey
        {
            get;
            set;
        }

        public DateTime Timestamp
        {
            get;
            set;
        }
    }
}

