
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Car.Models
{
    public class Purchase
    {
        //[Key]
        //[Display(Name="PurchaseId")]
        public int PurchaseId { get; set; }

        //[Display(Name="BuyerFIO")]
        //[Column(TypeName = "nvarchar(25)")]
        //[Required(ErrorMessage = "This Field is required.")]
        //[MaxLength(25, ErrorMessage = "Maximum 25 characters only.")]
        public string Person { get; set; }

        //[Display(Name = "Adress buyer")]
        //[Column(TypeName = "nvarchar(25)")]
        //[Required(ErrorMessage = "This Field is required.")]
        //[MaxLength(25, ErrorMessage = "Maximum 25 characters only.")]
        public string Adress { get; set; }

        //[Display(Name="CarId")]
        public int CarId { get; set; }

        //[Display(Name = "Day of buy")]
        //[Required(ErrorMessage = "This Field is required.")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}