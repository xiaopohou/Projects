﻿using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class AblumList<T>
    {
        [JsonProperty("ablumnList")]
        public T[] Data
        {
            get;
            set;
        }
    }
}