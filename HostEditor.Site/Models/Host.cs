//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HostEditor.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Host
    {
        public int HostId { get; set; }
        public string HostName { get; set; }
        public string IP { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    
        public virtual Category Category { get; set; }
    }
}