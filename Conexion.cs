using System;
using System.Data.SqlClient;

namespace EjemploEFCore
{
    internal class Conexion
    {
        public static string ConnectionString = "Server=DESKTOP-IDJJC5O;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True";

        public static void TestConnection()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Conexión exitosa a la base de datos.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al conectar a la base de datos.");
                Console.WriteLine($"Código de error: {ex.Number}");
                Console.WriteLine($"Mensaje de error: {ex.Message}");
                Console.WriteLine($"Detalles del error: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error inesperado.");
                Console.WriteLine($"Mensaje de error: {ex.Message}");
                Console.WriteLine($"Detalles del error: {ex.StackTrace}");
            }
        }
    }
}
