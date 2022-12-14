//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Project.Models;

    public partial class Product
    {
        public Product()
        {
            this.addtocarts = new HashSet<addtocart>();
            this.Orderdetails = new HashSet<Orderdetail>();
            this.Ratings = new HashSet<Rating>();
            this.returndetelis = new HashSet<returndeteli>();
        }
    
        public int Id { get; set; }
        [Required]
        public string P_name { get; set; }
        [Required]
        public string P_price { get; set; }
        [Required]
        public int P_categorie_id { get; set; }
        [Required]
        public int P_quantity { get; set; }
        [Required]
        public string P_details { get; set; }
        [Required]
        public string P_img { get; set; }
    
        public virtual ICollection<addtocart> addtocarts { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<returndeteli> returndetelis { get; set; }
    }
}
