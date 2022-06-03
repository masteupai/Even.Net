using System;

namespace Event.Net.Models
{
    public class EventoCreateVM
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
    }
}
