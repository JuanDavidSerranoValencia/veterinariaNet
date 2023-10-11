using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entitites;

public class ClienteTelefono : BaseEntity
{
    [Required]
    public int idCliente { get; set; }
    public string Numero { get; set; }

}
