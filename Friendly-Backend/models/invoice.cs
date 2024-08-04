
using System.Collections.Generic;
using api.models;

namespace api.models;
public class Invoice
{
    public int InvoiceId { get; set; }
    public int ServiceRecordID { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal TotalCost { get; set; }

    // Navigation properties
    public ServiceRecord ServiceRecord { get; set; }
}
