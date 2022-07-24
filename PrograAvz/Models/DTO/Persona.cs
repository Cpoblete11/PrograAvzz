using System.Collections.Generic;

namespace form.Models.DTO
{
    public class Persona
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public List<Direccion> direcciones { get; set; }

        public Persona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
    }
}
