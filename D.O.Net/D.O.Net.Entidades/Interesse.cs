using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D.O.Net.Entidades
{
    public class Interesse
    {
        public int InteresseID { get; set; }
        public string Descricao { get; set; }
        public int UsuarioID { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
