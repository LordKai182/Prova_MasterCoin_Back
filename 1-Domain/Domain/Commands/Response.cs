using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands
{
    public class Response
    {
        public Response(INotifiable notifiable)
        {

            this.Success = notifiable.IsValid();
            this.Notifications = notifiable.Notifications;
        }

        public Response(INotifiable notifiable, object data)
        {
            this.Success = notifiable.IsValid();
            this.Notifications = notifiable.Notifications;
            this.Data = data;
        }

        public Response(object data)
        {
            this.Success = true;
            this.Notifications = new List<Notification>();
            this.Data = data;
        }

        public IEnumerable<Notification> Notifications { get; set; }
        public bool Success { get; set; }

        public object Data { get; set; }
    }
}
