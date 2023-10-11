using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entitites;

public class Ciudad : BaseEntity
{
    public string NombreCiudad { get; set; }

    public int IdDep { get; set; }
    public Departamento Departamento { get; set; }
    public ClienteDireccion ClienteDireccion { get; set; }
}
