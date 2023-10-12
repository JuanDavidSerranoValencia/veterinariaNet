using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entitites;

public class Cliente : BaseEntity
{
   [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Email { get; set; }
        public ICollection<ClienteDireccion> ClienteDireccion { get; set; }
        public ICollection<ClienteTelefono> ClientesTelefonos { get; set; }         
        public ICollection<Mascota> Mascotas { get; set; }
        public ICollection<Cita> Citas { get; set; }     
}
