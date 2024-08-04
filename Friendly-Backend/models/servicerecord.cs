
using System;
using System.Collections.Generic;
using api.models;

namespace api.models;

public class ServiceRecord
{
    public int ServiceRecordId { get; set; }
    public DateTime ServiceDate { get; set; }
   
    public int VehicleID { get; set; }
    public int ServiceRepresentativeID { get; set; }
    public string Status { get; set; }=string.Empty;

    // Navigation properties
    public Vehicle Vehicle { get; set; }
    public ServiceRepresentative ServiceRepresentative { get; set; }
    public ICollection<BillOfMaterial> BillOfMaterials { get; set; }
    public Invoice Invoice { get; set; }
}
