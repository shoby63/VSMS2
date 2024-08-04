using System.Collections.Generic;
using api.models;

namespace api.models;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }=string.Empty;
    public string? Address { get; set; }

    public string ContactNumber { get; set; }= string.Empty;

    // Navigation properties
    public ICollection<Vehicle> Vehicles { get; set; }
}