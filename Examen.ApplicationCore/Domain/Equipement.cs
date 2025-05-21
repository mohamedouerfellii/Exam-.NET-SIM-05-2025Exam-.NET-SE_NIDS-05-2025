using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public enum EtatEquipement
    {
        Excellent,
        Bon,
        Moyen
    }

    public class Equipement
    {
        public int EquipementId { get; set; }
        public string PhotoEquipement { get; set; }
        public string TypeEquipement { get; set; }
        public EtatEquipement EtatEquipement { get; set; }
        public virtual Studio Studio { get; set; }
        [ForeignKey("Studio")]
        public int StudioFk { get; set; }
    }
}
