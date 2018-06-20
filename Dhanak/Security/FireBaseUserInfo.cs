using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dhanak.Security
{
    public class FireBaseUserInfo
    {

        public class FirebaseUserInfo
        {
            [JsonProperty(PropertyName = "identities")]
            public FirebaseIdentities Identities { get; set; }

            [JsonProperty(PropertyName = "sign_in_provider")]
            public string SignInProvider { get; set; }
        }

        public class FirebaseIdentities
        {
            [JsonProperty(PropertyName = "facebook.com")]
            public string[] FacebookDotCom { get; set; }

            [JsonProperty(PropertyName = "google.com")]
            public string[] GoogleDotCom { get; set; }

            [JsonProperty(PropertyName = "email")]
            public string[] Email { get; set; }
        }
    }
}
