﻿using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class User
    {
        [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
        public int UserId
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("avatarUrl")]
        public string AvatarUrl
        {
            get;
            set;
        }

        [JsonProperty("relation", NullValueHandling = NullValueHandling.Ignore)]
        public int Relation
        {
            get;
            set;
        }

        [JsonProperty("followerCount", NullValueHandling = NullValueHandling.Ignore)]
        public int FollowerCount
        {
            get;
            set;
        }

        [JsonProperty("followCount", NullValueHandling = NullValueHandling.Ignore)]
        public int FollowCount
        {
            get;
            set;
        }

        [JsonProperty("followerDate")]
        public object FollowerDate
        {
            get;
            set;
        }

        [JsonProperty("isHighlight")]
        public object IsHighlight
        {
            get;
            set;
        }
    }
}