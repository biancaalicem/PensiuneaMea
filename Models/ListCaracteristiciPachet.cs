using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Threading.Tasks;

namespace PensiuneaMea.Models
{
    public class ListCaracteristiciPachet
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        [ForeignKey(typeof(PachetSejur))] public int PachetSejurID { get; set; }
        public int CaracteristiciPachetID { get; set; }
    }
}
