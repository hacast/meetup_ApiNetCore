using System;
using System.Collections.Generic;
using System.Text;

namespace Birras.Core.DTOs
{
    public class MeetDTO
    {
        public int Id { get; set; }
        public int IdUsuarioCreador { get; set; }
        public DateTime FechaReunion { get; set; }
        public int Temperatura { get; set; }
        public int Birras { get; set; }
    }
}
