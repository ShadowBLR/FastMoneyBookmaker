using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastMoneyBookmaker.Models
{
    class Team
    {
        [Key]
        public string Name { get; set; }
        public Match Match { get; set; }
    }
}
