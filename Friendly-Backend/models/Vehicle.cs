
using System.Collections.Generic;
using api.models;

namespace api.models;
public class Vehicle
{
    public int VehicleId { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; }= string.Empty;
    public int Year { get; set; }
    public int CustomerID { get; set; }

    // Navigation properties
    public Customer Customer { get; set; }
    public ICollection<ServiceRecord> ServiceRecords { get; set; }
}
