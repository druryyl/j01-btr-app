﻿namespace btr.domain.SalesContext.OutletAgg;

public class CustomerModel : ICustomerKey
{
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
    public double Plafond { get; set; }
    public double CreditBalance { get; set; }
}