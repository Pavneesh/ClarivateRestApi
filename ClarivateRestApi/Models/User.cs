using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClarivateRestApi.Models
{
    public class LoginUser
    {
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
