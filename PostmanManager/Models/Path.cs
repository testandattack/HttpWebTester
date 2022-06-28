using JsonSubTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanManager.Models
{
    [JsonConverter(typeof(JsonSubtypes), "itemType")]
    [JsonSubtypes.KnownSubType(typeof(StringPath), PathItemType.String)]
    [JsonSubtypes.KnownSubType(typeof(ArrayPath), PathItemType.Array)]
    [JsonSubtypes.KnownSubType(typeof(ObjectPath), PathItemType.Object)]
    public abstract class PathItem
    {
        [JsonIgnore]
        public abstract PathItemType itemType { get; set; }
    }


    public class StringPath : PathItem
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonIgnore]
        public override PathItemType itemType 
        {
            get
            {
                return PathItemType.String;
            }
            set
            {
                value = PathItemType.String;
            }
        }

        [JsonConstructor]
        public StringPath()
        {
            itemType = PathItemType.String;
        }
    }

    public class ArrayPath : PathItem
    {
        [JsonProperty("path")]
        public string[] Path { get; set; }

        [JsonIgnore]
        public override PathItemType itemType
        {
            get
            {
                return PathItemType.Array;
            }
            set
            {
                value = PathItemType.Array;
            }
        }

        [JsonConstructor]
        public ArrayPath()
        {
            itemType = PathItemType.Array;
        }
    }

    public class ObjectPath : PathItem
    {
        [JsonProperty("path")]
        public Dictionary<string, string> Path { get; set; }

        [JsonIgnore]
        public override PathItemType itemType
        {
            get
            {
                return PathItemType.Object;
            }
            set
            {
                value = PathItemType.Object;
            }
        }

        [JsonConstructor]
        public ObjectPath()
        {
            itemType = PathItemType.Object;
        }
    }

    public enum PathItemType
    {
        String,
        Array,
        Object
    }
}

/*
    [JsonConverter(typeof(JsonSubtypes), "itemType")]
    [JsonSubtypes.KnownSubType(typeof(StringPath), PathItemType.String)]
    [JsonSubtypes.KnownSubType(typeof(ArrayPath), PathItemType.Array)]
    [JsonSubtypes.KnownSubType(typeof(ObjectPath), PathItemType.Object)]
    public abstract class PathItem<T>
    {
        [JsonProperty("path")]
        public abstract T Path { get; set; }

        [JsonIgnore]
        public abstract PathItemType itemType { get; set; }
    }


    public class StringPath : PathItem<string>
    {
        [JsonProperty("path")]
        public override string Path { get; set; }

        [JsonIgnore]
        public override PathItemType itemType 
        {
            get
            {
                return PathItemType.String;
            }
            set
            {
                value = PathItemType.String;
            }
        }

        [JsonConstructor]
        public StringPath()
        {
            itemType = PathItemType.String;
        }
    }

    public class ArrayPath : PathItem<string[]>
    {
        [JsonProperty("path")]
        public override string[] Path { get; set; }

        [JsonIgnore]
        public override PathItemType itemType
        {
            get
            {
                return PathItemType.Array;
            }
            set
            {
                value = PathItemType.Array;
            }
        }

        [JsonConstructor]
        public ArrayPath()
        {
            itemType = PathItemType.Array;
        }
    }

    public class ObjectPath : PathItem<Dictionary<string, string>>
    {
        [JsonProperty("path")]
        public override Dictionary<string, string> Path { get; set; }

        [JsonIgnore]
        public override PathItemType itemType
        {
            get
            {
                return PathItemType.Object;
            }
            set
            {
                value = PathItemType.Object;
            }
        }

        [JsonConstructor]
        public ObjectPath()
        {
            itemType = PathItemType.Object;
        }
    }
 */
