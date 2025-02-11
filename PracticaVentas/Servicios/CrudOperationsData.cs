using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using PracticaVentas.Models;
using PracticaVentas.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace PracticaVentas
{
    public class CrudOperationsData
    {
        private readonly IConnectBD _connectBd;

        public CrudOperationsData(IConnectBD bd)
        {
            this._connectBd = bd;
        }

        public async Task<ObservableCollection<PersonModel>> GetAsync()
        {
            ObservableCollection<PersonModel> personsModels = new();

            var query = "SELECT * FROM Empleados";

            try
            {
                await using (SqlConnection con = new(_connectBd.GetConnection))
                {
                    await con.OpenAsync();
                    using SqlCommand cmd = new(query, con);
                    using SqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync();

                    while (await sqlDataReader.ReadAsync())
                    {
                        personsModels.Add(new PersonModel
                        {
                            Id = sqlDataReader.GetGuid(sqlDataReader.GetOrdinal("Id")),
                            Name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name")),
                            LastName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Lastname")),
                            Role = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Role")),
                            Description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Description")),
                            Area = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Area"))
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo del error: log o re-lanzar la excepción según corresponda
                Console.WriteLine($"Error al obtener empleados: {ex.Message}");
                throw;
            }

            return personsModels;
        }

        public async Task<ObservableCollection<Area>> GetAreasAsync()
        {
            ObservableCollection<Area> areas = new();

            var query = "SELECT * FROM Areas";
            try
            {
                await using (SqlConnection con = new(_connectBd.GetConnection))
                {
                    await con.OpenAsync();
                    using SqlCommand cmd = new(query, con);
                    using SqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync();

                    while (await sqlDataReader.ReadAsync())
                    {
                        areas.Add(new Area
                        {
                            Id = sqlDataReader.GetGuid(sqlDataReader.GetOrdinal("id_area")),
                            NameArea = sqlDataReader.GetString(sqlDataReader.GetOrdinal("nombre_area")),
                            SupArea = sqlDataReader.GetGuid(sqlDataReader.GetOrdinal("id_supervisor"))

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo del error: log o re-lanzar la excepción según corresponda
                Console.WriteLine($"Error al obtener empleados: {ex.Message}");
                throw;
            }

            return areas;
        }


        //Regex de identificacion para Guid.
        //static Regex guidReg = new Regex("^[A-Fa-f0-9]{32}$|" +
        //                  "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
        //                  "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$", RegexOptions.Compiled);
        public PersonModel GetPerson(Guid id, out string messageAdvice)
        {
            PersonModel personModel = null;
            messageAdvice = string.Empty;
            using (SqlConnection con = new(_connectBd.GetConnection))
            {
                con.Open();


                var query = "EMPLEADO_GET";

                using (SqlCommand cmd = new(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] image = (byte[])reader["photo"];

                            BitmapImage photo = Checkers.ToImage(image);

                            personModel = new PersonModel
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Role = reader.GetString(reader.GetOrdinal("Role")),
                                Area = reader.GetString(reader.GetOrdinal("Area")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                FotoEmpleado = photo
                            };
                        }
                    }
                }
            }
            if (personModel is null)
            {
                messageAdvice = $"No se ha encontrado la persona {id}!";
                return new PersonModel();
            }
            return personModel;
        }


        internal async void Add(PersonModel person)
        {
            if (person is null)
            {
                throw new ArgumentNullException("Debe haber una persona como minimo!");
            }
            byte[] photoBytes = Checkers.ImageToByte(person.FotoEmpleado!);

            using (SqlConnection con = new(_connectBd.GetConnection))
            {
                await con.OpenAsync();
                var query = "INSERTAR_PERSONS";
                using (SqlCommand comand = new SqlCommand(query, con))
                {
                    comand.CommandType = CommandType.StoredProcedure;

                    comand.Parameters.AddWithValue("Id", person.Id);
                    comand.Parameters.AddWithValue("Name", person.Name);
                    comand.Parameters.AddWithValue("LastName", person.LastName);
                    comand.Parameters.AddWithValue("Role", person.Role);
                    comand.Parameters.AddWithValue("Description", person.Description);
                    comand.Parameters.AddWithValue("Area", person.Area);
                    comand.Parameters.AddWithValue("photo", photoBytes);
                    await comand.ExecuteNonQueryAsync();
                }
                con.Close();
            }


        }

        internal void Delete(PersonModel person)
        {
            if (person is null) { throw new ArgumentNullException("Null"); }
            var query = "DELETE FROM Empleados WHERE Id =(@Id)";
            using (SqlConnection connection = new(_connectBd.GetConnection))
            {
                connection.Open();
                using (SqlCommand comand = new(query, connection))
                {
                    comand.Parameters.AddWithValue("Id", person.Id);
                    comand.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        internal void Update(PersonModel person)
        {
            var query = "UPDATE Empleados SET NAME = @Name, Lastname = @LastName, Role = @Role, Description = @Description WHERE Id = @Id";
            using (SqlConnection con = new(_connectBd.GetConnection))
            {

                con.Open();
                using (SqlCommand comand = new(query, con))
                {

                    comand.Parameters.AddWithValue("Name", person.Name);
                    comand.Parameters.AddWithValue("Lastname", person.LastName);
                    comand.Parameters.AddWithValue("Role", person.Role);
                    comand.Parameters.AddWithValue("Description", person.Description);
                    comand.Parameters.AddWithValue("Id", person.Id);

                }
            }
        }




        /*En otro momento se creará un DI Para manejo de archivos*/

        public BitmapImage AgregarImagen()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Multiselect = false,
                    Filter = "Imágenes (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
                };

                bool? sel = ofd.ShowDialog();
                if (sel == true && !string.IsNullOrEmpty(ofd.FileName))
                {
                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(ofd.FileName);
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    return bitmapImage;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar la imagen: {ex.Message}");
            }

            return null!;

        }

        public async Task<ObservableCollection<T>> ReturnDataObservable<T>(ObservableCollection<T> data)
        {
            try
            {
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
                return typeof(T).Name switch
                {
                    nameof(PersonModel) => await this.GetAsync() as ObservableCollection<T>,
                    nameof(Area) => await this.GetAsync() as ObservableCollection<T>,
                    _ => throw new NotImplementedException()
                };
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

        }
    }
}
