﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class AdditionalQuestion
    { [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    public string Value { get; set; }

        
    }
