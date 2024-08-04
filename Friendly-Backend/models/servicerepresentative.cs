using System.Collections.Generic;
using api.models;

namespace api.models;
public class ServiceRepresentative
{
    public int ServiceRepresentativeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; }= string.Empty;

    // Navigation properties
    public ICollection<ServiceRecord> ServiceRecords { get; set; }
}
