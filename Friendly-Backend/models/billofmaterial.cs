using System.Collections.Generic;
using api.models;

namespace api.models;

public class BillOfMaterial
{
  
        public int BillOfMaterialID { get; set; } // Primary Key
        public int ServiceRecordID { get; set; }  // Foreign Key to ServiceRecord
        public int WorkItemID { get; set; }       // Foreign Key to WorkItem
        public int Quantity { get; set; }

        // Navigation properties
        public ServiceRecord ServiceRecord { get; set; }
        public WorkItem WorkItem { get; set; }
    
}



