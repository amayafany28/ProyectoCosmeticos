using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Cosmeticos
{
    public class SeguridadBL
    {
       public bool Autorizar(string usuario, string contrasena)

        {
        if (usuario == "FanyAmaya" && contrasena == "Cosmeticoszare")
            {
                return true;
            }
            else
            {
                if (usuario == "DanielZelaya" && contrasena == "Cosmeticoszare")
                {
                    return true;
                }

            }
            return false;
        }
    }
}
