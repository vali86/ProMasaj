using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProMasaj
{
    //validator pentru camp required
    public class StringNotEmpty : ValidationRule
    {
        //mostenim din clasa ValidationRule
        //suprascriem metoda Validate ce returneaza un
        //ValidationResult
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureinfo)
        {
            string aString = value.ToString();
            if (aString == "")
                return new ValidationResult(false, "Field-ul nu poate sa fie gol");
            return new ValidationResult(true, null);
        }
    }
    //validator pentru lungime minima a string-ului
    public class StringMinLengthValidator : ValidationRule
    {
        public override ValidationResult Validate(object value,
        System.Globalization.CultureInfo cultureinfo)
        {
            string aString = value.ToString();
            if (aString.Length < 3)
                return new ValidationResult(false, "Datele introduse trebuie sa fie de cel putin 3 caracter");
        return new ValidationResult(true, null);
        }
    }
    class Validation
    {
    }
}
