using System;
using System.Collections.Generic;
using System.Text;

namespace ModelKlasser
{
    public class Guest
    {
        public int GuestNr { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }

        public override string ToString()
        {
            return $"{GuestNr} - {Navn} - {Adresse}";
        }
    }
}
