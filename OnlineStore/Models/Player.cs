using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int? TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }
    }
}