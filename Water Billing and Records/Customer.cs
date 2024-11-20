namespace Water_Billing_and_Records
{
    {
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public double TotalWaterUsage { get; set; } // Total water usage in cubic meters
    }
}