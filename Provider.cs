﻿using Newtonsoft.Json;
using System;

namespace CSCordEmbedsHelper
{
    [Serializable]
    public class Provider
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}