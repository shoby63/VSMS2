
using System.Collections.Generic;
using api.models;

namespace api.models;

public class WorkItem
{
    public int WorkItemId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }

    // Navigation properties
    public ICollection<BillOfMaterial> BillOfMaterials { get; set; }
}
