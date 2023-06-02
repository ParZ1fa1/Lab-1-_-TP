using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Laba_1.Models
{
    public class Calculator
    {
        [Required(ErrorMessage = "Первое значение не указано")]
        public short Operand_1 { get; set; }

        [Range(0.01, 1000.00, ErrorMessage = "Второе значение должно быть между 0.01 и 1000.00")]
        public double Operand_2 { get; set; }

        public double Result { get; set; }

        public char Sign { get; set; }
    }
}