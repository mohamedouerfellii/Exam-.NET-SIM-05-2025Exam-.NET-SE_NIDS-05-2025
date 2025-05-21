using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class ServiceMusicien : Service<Musicien>, IServiceMusicien
    {
        public ServiceMusicien(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public float prixAPayer(Musicien m, DateTime debut, DateTime fin)
        {
            return m.Reservations
                .Where(r => r.DateReservation >= debut && r.DateReservation <= fin)
                .Sum(r => r.Studio.PrixHeure * r.NbrHeure);
        }
    }
}
