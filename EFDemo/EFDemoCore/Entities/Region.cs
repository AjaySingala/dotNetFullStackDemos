using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemoCore.Entities
{
    [Table("Region")]
    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }
    }
}
