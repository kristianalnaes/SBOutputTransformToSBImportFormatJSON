using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace SBOutputTransformToSBImportFormatJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var JsonToPrint = LoadJson(args[0]);
            File.WriteAllText($"{args[0]}-sbimportable.json", JsonToPrint);
        }
        public static string LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<BrokeredMessageTemplate>>(json);

                var outputJsonString = JsonConvert.SerializeObject(items);
                return outputJsonString;
            }
        }

        public class BrokeredMessageTemplate
        {
            #region Private Fields
            private string content;
            #endregion

            #region Public Constructors
            public BrokeredMessageTemplate()
            {
                Properties = new List<Dictionary<string,string>>();
            }
            #endregion

            #region Public Properties
            /// <summary>
            /// Gets or sets the value of the MessageId property of the BrokeredMessage object.
            /// </summary>
            [JsonProperty(PropertyName = "messageId", Order = 1)]
            public string MessageId { get; set; }

            /// <summary>
            /// Gets or sets the value of the SessionId property of the BrokeredMessage object.
            /// </summary>
            [JsonProperty(PropertyName = "sessionId", Order = 2)]
            public string SessionId { get; set; }

            /// <summary>
            /// Gets or sets the value of the CorrelationId property of the BrokeredMessage object.
            /// </summary>
            [JsonProperty(PropertyName = "correlationId", Order = 3)]
            public string CorrelationId { get; set; }

            /// <summary>
            /// Gets or sets the value of the ContentType property of the BrokeredMessage object.
            /// </summary>
            [JsonProperty(PropertyName = "contentType", Order = 4)]
            public string ContentType { get; set; }

            /// <summary>
            /// Gets or sets the value of the Label property of the BrokeredMessage object.
            /// </summary>
            [JsonProperty(PropertyName = "label", Order = 5)]
            public string Label { get; set; }

            /// <summary>
            /// Gets or sets the value of the PartitionKey property of the BrokeredMessage object.
            /// </summary>
            [JsonProperty(PropertyName = "partitionKey", Order = 6)]
            public string PartitionKey { get; set; }

            /// <summary>
            /// Gets or sets the value of the To property of the BrokeredMessage object.
            /// </summary>
            [JsonProperty(PropertyName = "to", Order = 7)]
            public string To { get; set; }

            /// <summary>
            /// Gets or sets the value of the ReplyTo property of the BrokeredMessage object.
            /// </summary>
            [JsonProperty(PropertyName = "replyTo", Order = 8)]
            public string ReplyTo { get; set; }

            /// <summary>
            /// Gets or sets the value of the ReplyToSessionId property of the BrokeredMessage object.
            /// </summary>
            [JsonProperty(PropertyName = "replyToSessionId", Order = 9)]
            public string ReplyToSessionId { get; set; }

            /// <summary>
            /// Gets or sets the value of the TimeToLive property of the BrokeredMessage object.
            /// </summary>
            [JsonProperty(PropertyName = "timeToLive", Order = 10)]
            public string TimeToLive { get; set; }

            /// <summary>
            /// Gets or sets the value of the ScheduledEnqueueTimeUtc property of the BrokeredMessage object.
            /// </summary>
            [JsonProperty(PropertyName = "scheduledEnqueueTimeUtc", Order = 11)]
            public string ScheduledEnqueueTimeUtc { get; set; }

            /// <summary>
            /// Gets or sets the value of the ForcePersistence property of the BrokeredMessage object.
            /// </summary>
            [JsonProperty(PropertyName = "forcePersistence", Order = 12)]
            public bool ForcePersistence { get; set; }

            /// <summary>
            /// Gets or sets the message of the BrokeredMessage object.
            /// </summary>
            
            [JsonProperty(PropertyName = "message", Order = 13)]
            public string Message
            {
                get
                {
                    return content;
                }
                set
                {
                    content = value;
                }
            }

            /// <summary>
            /// Gets or sets the message of the BrokeredMessage object.
            /// </summary>
        

   
            [JsonProperty(PropertyName = "properties", Order = 14)]
            public List<Dictionary<string,string>> Properties { get; set; }
            #endregion
        }


    }


}
