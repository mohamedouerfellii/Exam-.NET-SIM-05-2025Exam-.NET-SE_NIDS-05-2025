using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class ServiceReservation : Service<Reservation>, IServiceReservation
    {
        public ServiceReservation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Dictionary<string, List<Collaborateur>> RetournerCollabGroupeParRole(Reservation r)
        {
            return r.Musicien.Collaborateurs
                .GroupBy(c => c.Role)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Equipement> EquipementParJour(DateTime date)
        {
            return GetMany().Where(r => r.DateReservation == date).SelectMany(r => r.Studio.Equipements)
                .OrderBy(e => e.TypeEquipement).ToList();
        }
    }
}
