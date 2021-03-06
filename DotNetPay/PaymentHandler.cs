﻿using System;
using IndyDotNet.PaymentHandler;

namespace DotNetPay
{
    public class PaymentHandler : IPaymentHandler
    {
        public string PaymentMethod { get { return "DNP";  } }

        public string CreatePaymentAddress()
        {
            return $"pay:{PaymentMethod}:someid";
        }
    }
}
