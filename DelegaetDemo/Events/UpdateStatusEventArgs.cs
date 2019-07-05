using System;

namespace DelegaetDemo.Events
{
    public class UpdateStatusEventArgs : EventArgs
    {
        public UpdateStatusEventArgs(int orderId)
        {
            this.OrderId = orderId;
        }
        public int OrderId { get; set; }
    }
}
