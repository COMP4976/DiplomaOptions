﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OptionsWebsite.Models.BCITModels
{
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }

        [ForeignKey("YearTerm")]
        public int YearTermId { get; set; }
        [ForeignKey("YearTermId")]
        public YearTerm YearTerm { get; set; }

        [StringLength(9, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 5)]
        public string StudentId { get; set; }

        [StringLength(40, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 1)]
        public string StudentFirstName { get; set; }
        [StringLength(40, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 1)]
        public string StudentLastName { get; set; }

        [Display(Name = "First Choice: ")]
        [ForeignKey("FirstOption")]
        public int? FirstChoiceOptionId { get; set; }
        [ForeignKey("FirstChoiceOptionId")]
        public Option FirstOption { get; set; }

        [Display(Name = "Second Choice: ")]
        [ForeignKey("SecondOption")]
        public int? SecondChoiceOptionId { get; set; }
        [ForeignKey("SecondChoiceOptionId")]
        public Option SecondOption { get; set; }

        [Display(Name = "Third Choice: ")]
        [ForeignKey("ThirdOption")]
        public int? ThirdChoiceOptionId { get; set; }
        [ForeignKey("ThirdChoiceOptionId")]
        public Option ThirdOption { get; set; }

        [Display(Name = "Fourth Choice: ")]
        [ForeignKey("FourthOption")]
        public int? FourthChoiceOptionId { get; set; }
        [ForeignKey("FourthChoiceOptionId")]
        public Option FourthOption { get; set; }

        public DateTime SelectionDate { get; set; }

    }
}