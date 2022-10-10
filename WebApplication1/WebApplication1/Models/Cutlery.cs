using System;

namespace WebApplication1.Models
{
    public class Cutlery
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Type { get; set; }

        public string Material { get; set; }

        public double Price { get; set; }
    }
}
