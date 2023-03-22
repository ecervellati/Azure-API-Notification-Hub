using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PushDemoAPI.Models
{
    // Name =  XamarinAndroidNotificationHub (the name of the notificationhub that we create into the Azure Portal)
    // ConnectionString = Endpoint URL to access the notification hub 
    public class NotificationHubOptions
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ConnectionString { get; set; }
    }
}
