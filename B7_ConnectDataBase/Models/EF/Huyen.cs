using System;
using System.Collections.Generic;

namespace B7_ConnectDataBase.Models.EF
{
    public partial class Huyen
    {
        public Huyen()
        {
            Xa = new HashSet<Xa>();
        }

        public int Idqh { get; set; }
        public string NameQh { get; set; }
        public int? Idtp { get; set; }

        public virtual Tinh IdtpNavigation { get; set; }
        public virtual ICollection<Xa> Xa { get; set; }
    }
}
