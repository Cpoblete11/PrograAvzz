namespace form.Models.DTO
{
    public class Direccion
    {
        public int id { get; set; }
        public string direccion { get; set; }

        public Direccion(int id, string direccion)
        {
            this.id = id;
            this.direccion = direccion;
        }
    }
}
