using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IServiceMusicien : IService<Musicien>
    {
        float prixAPayer(Musicien m, DateTime debut, DateTime fin);
    }
}
