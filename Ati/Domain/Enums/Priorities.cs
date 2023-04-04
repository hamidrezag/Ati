using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Priorities
    {
        [Description("High")]
        High,
        [Description("Normal")]
        Normal,
        [Description("Low")]
        Low
    }
}
