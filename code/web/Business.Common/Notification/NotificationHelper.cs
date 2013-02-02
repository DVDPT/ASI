using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Common.AsiTech.Services.Notifications;
using Business.Common.ManagementCenter;
using DAL.Model.Common;
using DAL.Model.ManagementCenter;

namespace Business.Common.Notification
{
    public static class NotificationHelper
    {
        private const string OrderCantBeHeldMessageFormat = "The order of the product with id {0} can't be held.";

        private const string OrderChangedStateMessageFormat = "The order of the product with id {0} is now on state {1}.";


        public static void Notify(string email, string message)
        {
            try
            {
                using (var notification = new NotificationServiceClient())
                {
                    notification.SendEmail(email, message);
                }
            }
            catch
            {
                // if it fails ignore.
            }
        }

        public static void NotifyOrderCantBeHeld(CustomerBase c, ManagementCenterProduct product)
        {
            Notify(c.Email, string.Format(OrderCantBeHeldMessageFormat, product.Id));
        }

        public static void NotifyOrderIsBeingProcessed(CustomerBase customer, ManagementCenterProduct product)
        {
            NotifyOrderChangedState(customer, product, "Processing");
        }

        public static void NotifyOrderChangedState(CustomerBase customer, ManagementCenterProduct product, string state)
        {
            Notify(customer.Email, string.Format(OrderChangedStateMessageFormat, product.Id, state));
        }
    }
}
