using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Reservation
    {
        public bool Confirme { get; set; }
        public DateTime DateReservation { get; set; }
        public int NbrHeure { get; set; }
        public virtual Musicien Musicien { get; set; }
        public int MuscienFk { get; set; }
        public virtual Studio Studio { get; set; }
        public int StudioFk { get; set; }
    }
}
