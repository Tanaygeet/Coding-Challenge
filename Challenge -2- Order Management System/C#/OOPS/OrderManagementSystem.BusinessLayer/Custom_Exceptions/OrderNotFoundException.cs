/* Tanaygeet Shrivastava */

using System;

namespace OrderManagementSystem.BusinessLayer.Custom_Exceptions
{
    public class OrderNotFoundException : RankException
    {
        public OrderNotFoundException() : base("Order Not Found") {}

        public OrderNotFoundException(string message) : base(message) {}

        public OrderNotFoundException(string message, RankException inner) : base(message, inner) {}
    }
}

