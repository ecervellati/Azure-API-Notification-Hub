using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PushDemoAPI.Models
{
    /// <summary>
    /// This class contains the tokenized notification payloads for the generic and silent notifications required by this scenario. 
    /// The payloads are defined outside of the Installation to allow experimentation without having to update existing installations via the service. 
    /// Handling changes to installations in this way is out of scope for this tutorial. For production, consider custom templates.
    /// </summary>
    public class PushTemplates
    {
        public class Generic
        {
            public const string Android = "{ \"notification\": { \"title\" : \"PushDemo\", \"body\" : \"$(alertMessage)\"}, \"data\" : { \"action\" : \"$(alertAction)\" } }";
            public const string iOS = "{ \"aps\" : {\"alert\" : \"$(alertMessage)\"}, \"action\" : \"$(alertAction)\" }";
        }

        public class Silent
        {
            public const string Android = "{ \"data\" : {\"message\" : \"$(alertMessage)\", \"action\" : \"$(alertAction)\"} }";
            public const string iOS = "{ \"aps\" : {\"content-available\" : 1, \"apns-priority\": 5, \"sound\" : \"\", \"badge\" : 0}, \"message\" : \"$(alertMessage)\", \"action\" : \"$(alertAction)\" }";
        }
    }
}
