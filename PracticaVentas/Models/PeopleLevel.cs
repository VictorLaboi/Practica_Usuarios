using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaVentas.Models
{
    internal class PeopleLevel
    {
        public PeopleLevel()
        {

        }

        private Guid _idLevel;
        private decimal _levelSalary;
        private string _nameLevel;
        private string _descriptionLevel;
        private Guid _idAssignableArea;

        public Guid IdLevel
        {
            get => _idLevel;
            set
            {
                if (value != _idLevel)
                {
                    _idLevel = value;
                }
            }
        }

        [Required]
        public decimal LevelSalary
        {
            get => _levelSalary;
            set
            {
                if (value != _levelSalary)
                {
                    _levelSalary = value;
                }
            }
        }

        [MaxLength(5)]
        public string NameLevel
        {
            get => _nameLevel;
            set
            {
                if (value != _nameLevel)
                {
                    _nameLevel = value;
                }
            }
        }
        [MaxLength(100)]
        public string DescriptionLevel
        {
            get => _descriptionLevel;
            set
            {
                if (value != _descriptionLevel)
                {
                    _descriptionLevel = value;
                }
            }
        }
        
        public Guid IdAssignableArea
        {
            get => _idAssignableArea;
            set
            {
                if (value != _idAssignableArea)
                {
                    _idAssignableArea = value;
                }
            }
        }

    }
}
