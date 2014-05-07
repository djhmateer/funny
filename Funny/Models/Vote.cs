using System;

namespace Funny.Models
{
    public class Vote {
        public int ID { get; set; }
        public string IPAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Story Story { get; set; }
    }
}