using form.Models.DTO;
using PrograAvz.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace form.Models.DAL
{
    public class PersonaDAL
    {
        static Class conexion = new Class();
        public List<Persona> get()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                using (SqlConnection con = new SqlConnection(conexion.GetBd()))
                {

                    string sql = "select * from persona";
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Persona p = new Persona(reader["nombre"].ToString(), reader["apellido"].ToString());
                            p.Id = int.Parse(reader["id"].ToString());
                            p.direcciones = getDireccionById(int.Parse(reader["id"].ToString()));
                            personas.Add(p);
                            
                        }
                        con.Close();
                    }
                }
            } catch(Exception e)
            {
                Persona p = new Persona(e.ToString(), "");
                personas.Add(p);
            }
               return personas;
        }

        public List<Direccion> getDireccionById(int id)
        {
            List<Direccion> direcciones = new List<Direccion>();
            string sql = "select d.id, d.direccion from persona_tiene_direcciones pd join direccion d on pd.id_direccion = d.id where pd.id_persona = " + id;
            using (SqlConnection con = new SqlConnection(conexion.GetBd()))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Direccion d = new Direccion(int.Parse(reader["id"].ToString()), reader["direccion"].ToString());
                        direcciones.Add(d);
                    }
                    con.Close();
                }
            }
            return direcciones;
        }

        public void agregar(Persona persona)
        {
            string sql = "insert into persona (nombre, apellido) values ('" + persona.nombre + "', '" + persona.apellido + "')";
            query(sql);
        }

        public void borrar(int id)
        {
            string sql = "DELETE FROM persona WHERE id=" + id + ";";
            query(sql);
        }

        public void modificar(int id, string nombre, string apellido)
        {
            string sql = "UPDATE persona SET nombre = '" + nombre + "', apellido = '" + apellido + "' WHERE id=" + id + ";";
            query(sql);
        }

        public void query(string sql)
        {
            using (SqlConnection con = new SqlConnection(conexion.GetBd()))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    int reader = command.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
