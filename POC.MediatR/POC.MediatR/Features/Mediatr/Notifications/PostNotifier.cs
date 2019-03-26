using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace POC.MediatR.Features.Mediatr.Notifications
{
    public class PostNotifier : INotification
    {
        public string Info { get; set; }
    }
}
