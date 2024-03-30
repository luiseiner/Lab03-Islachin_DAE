using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_Islachin
{
    internal class conexion
    {
        public class Student
        {
            public int StudentId { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
        }

    }
}


namespace DataAccessDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Llamada a la función para recuperar la lista de estudiantes usando DataTable
            DataTable studentsDataTable = GetStudentsDataTable();
            Console.WriteLine("Estudiantes recuperados usando DataTable:");
            foreach (DataRow row in studentsDataTable.Rows)
            {
                Console.WriteLine($"{row["ID"]}, {row["Nombre"]}, {row["Apellido"]}");
            }
            Console.WriteLine();

            // Llamada a la función para recuperar la lista de estudiantes usando una lista de objetos
            List<Student> studentsList = GetStudentsList();
            Console.WriteLine("Estudiantes recuperados usando una lista de objetos:");
            foreach (var student in studentsList)
            {
                Console.WriteLine($"{student.ID}, {student.Nombre}, {student.Apellido}");
            }
        }

        // Función para recuperar la lista de estudiantes usando DataTable
        static DataTable GetStudentsDataTable()
        {
            string connectionString = "Data Source=TuServidor;Initial Catalog=TuBaseDeDatos;Integrated Security=True";
            string query = "SELECT ID, Nombre, Apellido FROM Estudiantes";

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        // Función para recuperar la lista de estudiantes usando una lista de objetos
        static List<Student> GetStudentsList()
        {
            string connectionString = "Data Source=TuServidor;Initial Catalog=TuBaseDeDatos;Integrated Security=True";
            string query = "SELECT ID, Nombre, Apellido FROM Estudiantes";

            List<Student> studentsList = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString()
                    };
                    studentsList.Add(student);
                }
                reader.Close();
            }

            return studentsList;
        }
    }

    // Clase para representar un estudiante
    public class Student
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
