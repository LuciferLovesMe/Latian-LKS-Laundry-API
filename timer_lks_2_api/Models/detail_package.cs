//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace timer_lks_2_api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class detail_package
    {
        public Nullable<int> id_service { get; set; }
        public Nullable<int> id_package { get; set; }
        public int id_detail_package { get; set; }
        public Nullable<int> total_unit_service_detail_package { get; set; }
    
        public virtual package package { get; set; }
        public virtual service service { get; set; }
    }
}