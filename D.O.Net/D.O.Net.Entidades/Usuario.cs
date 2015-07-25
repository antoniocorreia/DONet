using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D.O.Net.Entidades
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }
}
