//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class client
    {
        public int client_id { get; set; }
        public string client_name { get; set; }
        public string client_email { get; set; }
        public Nullable<int> client_fk_Cat { get; set; }
        public Nullable<int> client_fk_ser { get; set; }
        public string client_msg { get; set; }
    
        public virtual category_T category_T { get; set; }
        public virtual service service { get; set; }
    }
}
