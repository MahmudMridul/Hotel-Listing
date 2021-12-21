using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.DTOs
{
    public class CreateCountryDTO
    {

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Name too long")]
        public string Name { get; set; }

        [Required]
        public int Code { get; set; }
    }

    public class CountryDTO : CreateCountryDTO 
    {
        public int Id { get; set; }
    }

}
