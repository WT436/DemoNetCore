using System;
using System.Collections.Generic;

namespace B7_ConnectDataBase.Models.EF
{
    public partial class Tinh
    {
        public Tinh()
        {
            Huyen = new HashSet<Huyen>();
        }

        public int Idtp { get; set; }
        public string NameTp { get; set; }

        public virtual ICollection<Huyen> Huyen { get; set; }
    }
}
