using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErikVanDelft.Models;
using System.ComponentModel.DataAnnotations;

namespace ErikVanDelft.Models
{
    public class CvViewModel
    {
        public List<CvContent> CvList { get; set; }       
    }
    public class CvContent
    {
        [Key]
        public int FunctieID { get; set; }

        [Display(Name = "Functie titel")]
        [Required]
        public string Functie { get; set; }


        [Display(Name = "Bedrijfsnaam")]
        [Required]
        public string Bedrijf { get; set; }


        [Display(Name = "Functie inhoud")]
        [Required]
        public string Werkzaamheden { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Startdatum")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Start { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Einddatum")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Finish { get; set; }

        [Display(Name = "Bedrijfswebsite")]
        public string Website { get; set; }




    }

}
