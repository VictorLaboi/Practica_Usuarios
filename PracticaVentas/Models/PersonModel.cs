using PracticaVentas.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PracticaVentas.Models
{
    public class PersonModel
    {
        private Guid _id = Guid.NewGuid();

        
        private string? _name;

        private string? _lastName;

        
        private string? _description;
        
        private string? _role;

        private string? _area;

        private DateOnly _fechaNacimiento;
        
        private BitmapImage? _fotoEmpleado;

        //[ImageAttribute(200,300,300,300, ErrorMessage =$"Image Must be!")]

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateOnly
        {
            get => _fechaNacimiento;
            set
            {
                if (value != _fechaNacimiento) _fechaNacimiento = value;
            }
        }
        [Required(ErrorMessage ="Debe ingresar foto del empleado")]
        public BitmapImage? FotoEmpleado {
            get { return _fotoEmpleado; }
            set {
                if (value != _fotoEmpleado) {
                    _fotoEmpleado = value;
                }
            }
        }

        public Guid Id { 
            get => _id;
            set
            {
                if (value != _id)
                {
                    _id = value;
                }
            }
        }

        [Required(ErrorMessage = "Empleado no tiene nombre!")]
        public string Name { get => _name!;
            set {
                if (value != _name) { 
                    _name = value;
                }
            }
        }
        public string LastName { get => _lastName!;
            set {
                if (_lastName != value) {
                    _lastName = value; 
                }
            } }


        [MaxLength(50, ErrorMessage = "Empleado no tiene descripcion!")]
        public string Description { get => _description!;
            set {
                if (_description != value) { 
                    _description = value;   
                }
            }
        }

        [Required(ErrorMessage = "Empleado no tiene rol!")]
        public string Role{ get => _role; set {
                if (_role != value) { 
                    _role = value;
                }
            } }

        [Required(ErrorMessage = "Empleado no tiene área!")]
        public string Area { get => _area;
            set {
                if (_area != value) { 
                    _area = value;
                }
            } }
    }
}
