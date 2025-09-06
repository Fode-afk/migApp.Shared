using System;
using System.Collections.Generic;

namespace migApp.Shared.Dtos.Cards
{
    public class CardDto
    {
        public string CardId { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public List<string> ProductIds { get; set; }
    }
}
