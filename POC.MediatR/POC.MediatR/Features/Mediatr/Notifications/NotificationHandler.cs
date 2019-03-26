using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace POC.MediatR.Features.Mediatr.Notifications
{
    public class NotificationHandler1 : INotificationHandler<PostNotifier>
    {
        public Task Handle(PostNotifier notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine(notification.Info);
            return Task.CompletedTask;
        }
    }

    public class NotificationHandler2 : INotificationHandler<PostNotifier>
    {
        public Task Handle(PostNotifier notification, CancellationToken cancellationToken)
        {
            // do something else with notification
            return Task.CompletedTask;
        }
    }
}
