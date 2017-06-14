﻿using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Marvina
{
    public class User
    {
        [JsonProperty("UserId")]
        public string userId { get; set; }
    }
}

