using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace TaskManager.Entity.Models
{
    [Table("IdGen")]
    public class IdGenerator
    {
        [Key]
        public int PrefixId { get; set; }
        [MaxLength(50)]
        public required string Prefix { get; set; }
        public int LastNo { get; set; }
    }
}
