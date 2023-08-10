using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationComponent.CustomAttributes;
using System.Text.Json.Serialization;

namespace AttributesExamples.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(15, 2, "Field {0} cannot exceed {1} characters in length and cannot be less than {2} characters in length")]
        public string FirstName  { get; set; }

        [Required]
        [StringLength(15, 2, "Field {0} cannot exceed {1} characters in length and cannot be less than {2} characters in length")]
        public string LastName { get; set; }

        [Required]
        [StringLength(15, 2, "Field {0} cannot exceed {1} characters in length and cannot be less than {2} characters in length")]
        [RegularExpression(@"\s*\(?0\d{4}\)?\s*\d{6}\s*)|(\s*\(?0\d{3}\)?\s*\d{3}\s*\d{4}\s*")]
        [JsonIgnore]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(15, 2, "Field {0} cannot exceed {1} characters in length and cannot be less than {2} characters in length")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(15, 2, "Field {0} cannot exceed {1} characters in length and cannot be less than {2} characters in length")]
        [RegularExpression(@"^ ?(([BEGLMNSWbeglmnsw][0-9][0-9]?)|(([A-PR-UWYZa-pr-uwyz][A-HK-Ya-hk-y][0-9][0-9]?)|(([ENWenw][0-9][A-HJKSTUWa-hjkstuw])|([ENWenw][A-HK-Ya-hk-y][0-9][ABEHMNPRVWXYabehmnprvwxy])))) ?[0-9][ABD-HJLNP-UW-Zabd-hjlnp-uw-z]{2}$")]
        //[JsonIgnore]
        public string PostCode { get; set; }
    }
}
