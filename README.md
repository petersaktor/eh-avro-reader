# eh-avro-reader
By using Avro files in Azure Event Hubs, you can take advantage of the compact binary format to reduce network bandwidth and storage costs, and ensure data interoperability across different programming languages and platforms.
This project is an example how to deserialize Avro file used in Azure Event Hub.
# schema
{
  "type" : "record",
  "name" : "EventData",
  "namespace" : "Microsoft.ServiceBus.Messaging",
  "fields" : [ {
    "name" : "SequenceNumber",
    "type" : "long"
  }, {
    "name" : "Offset",
    "type" : "string"
  }, {
    "name" : "EnqueuedTimeUtc",
    "type" : "string"
  }, {
    "name" : "SystemProperties",
    "type" : {
      "type" : "map",
      "values" : [ "long", "double", "string", "bytes" ]
    }
  }, {
    "name" : "Properties",
    "type" : {
      "type" : "map",
      "values" : [ "long", "double", "string", "bytes", "null" ]
    }
  }, {
    "name" : "Body",
    "type" : [ "null", "bytes" ]
  } ]
}
