//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryDatabaseData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Id { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string ModelNumber { get; set; }
        public string ModelName { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public string Description { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
