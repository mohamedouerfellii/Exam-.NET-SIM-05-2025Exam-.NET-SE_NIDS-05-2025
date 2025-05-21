using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Studio
    {
        public int StudioId { get; set; }
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Le nom doit être entre 5 et 20 caractères")]
        public string NomStudio { get; set; }
        public float PrixHeure { get; set; }
        [Display(Name = "Superficie du studio")]
        public int Superficie { get; set; }
        public virtual ICollection<Equipement> Equipements { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
