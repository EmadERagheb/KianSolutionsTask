using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public abstract class BaseDomainModel
    {
        [Timestamp]
        public byte[] Version { get; set; } = [];
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
