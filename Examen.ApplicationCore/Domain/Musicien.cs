using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Musicien
    {
        public int MusicienId { get; set; }
        public string NomMusicien { get; set; }
        public int NumTelephone { get; set; }
        public DateTime DateCarriere { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Collaborateur> Collaborateurs { get; set; }
    }
}
