using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Collaborateur
    {
        public int CollaborateurId { get; set; }
        public string NomCollaborateur { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Musicien> Musiciens { get; set; }
    }
}
