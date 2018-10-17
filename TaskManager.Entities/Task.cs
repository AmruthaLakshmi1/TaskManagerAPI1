using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entities
{
    [Table("tblTask")]
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [StringLength(20)]
        public string ParentName { get; set; }
        [StringLength(20)]
        public string TaskName { get; set; }
        public int Priority { get; set; }
        [Column(TypeName ="Date")]
        public DateTime SDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EDate { get; set; }
        public bool flag { get; set; }


    }
}
