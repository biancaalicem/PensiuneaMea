using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensiuneaMea.Models
{
    public class PachetSejur
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250), Unique]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey(nameof(AlegerePachet))]
        public int AlegerePachetID { get; set; }
    }
}
