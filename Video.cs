﻿using Newtonsoft.Json;
using System;

namespace CSCordEmbedsHelper
{
    [Serializable]
    public class Video
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("proxy_url")]
        public string ProxyVideo { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }
    }
}