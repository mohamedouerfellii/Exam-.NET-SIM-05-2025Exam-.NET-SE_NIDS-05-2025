using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IServiceReservation : IService<Reservation>
    {
        Dictionary<string, List<Collaborateur>> RetournerCollabGroupeParRole(Reservation r);

        List<Equipement> EquipementParJour(DateTime date);
    }
}
