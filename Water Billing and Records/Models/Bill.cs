namespace Water_Billing_and_Records.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; } // Amount for the bill
        public DateTime BillingDate { get; set; }
        public bool IsPaid { get; set; } // Payment status
        public virtual Customer Customer { get; set; }
    }
}