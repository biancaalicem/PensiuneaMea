using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensiuneaMea.Models
{
    public class AlegerePachet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string AlegerePachetName { get; set; }
        public string Adress { get; set; }
        public string AlegerePachetDetails { get { return AlegerePachetName + " " + Adress; } }
        [OneToMany]
        public List<PachetSejur> PacheteSejur { get; set; }
    }
}
