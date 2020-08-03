using System;
using System.Collections.Generic;

namespace B7_ConnectDataBase.Models.EF
{
    public partial class Xa
    {
        public int Idpx { get; set; }
        public string NameXa { get; set; }
        public string Cap { get; set; }
        public int? Idqh { get; set; }

        public virtual Huyen IdqhNavigation { get; set; }
    }
}
