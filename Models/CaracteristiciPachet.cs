using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PensiuneaMea.Models
{
    public class CaracteristiciPachet
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        public string Description { get; set; }
        [OneToMany] public List<ListCaracteristiciPachet> ListCaracteristiciPachete { get; set; }
    }
}
