namespace api.DTOS
{
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }
        public int ServiceRecordID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalCost { get; set; }
    }
}
