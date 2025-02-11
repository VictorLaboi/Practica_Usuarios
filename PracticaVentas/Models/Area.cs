using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaVentas.Models
{
    public class Area
    {
        private Guid _id; 
        private string _nameArea;
        private Guid _supArea;

        public Guid Id { get => _id; set {

                if (value != _id) {
                    _id = value;
                }
            
            } }
        [Required]
        public string NameArea { get => _nameArea; set
            {

                if (value != _nameArea)
                {
                    _nameArea = value;
                }

            }
        }
        [Required]
        public Guid SupArea { get => _supArea; set
            {

                if (value != _supArea)
                {
                    _supArea = value;
                }

            }
        }
    }
}
