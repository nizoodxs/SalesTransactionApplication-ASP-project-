//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalesTransactionApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VwSalesTransaction
    {
        public int SalesTransactionId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }
        public byte[] InvoiceNumber { get; set; }
    }
}