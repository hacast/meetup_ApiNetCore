using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Birras.Core.DTOs
{
    public class AttendanceDTO
    {
        public int IdAsistencia { get; set; }
        public int IdReunion { get; set; }
        public int IdUsuario { get; set; }
        public string Aceptada { get; set; }
        public string Cumplida { get; set; }

        public int? IdUsuarioCreador { get; set; }
        public string DescripcionUsuarioCreador { get; set; }

        public DateTime? FechaReunion { get; set; }

        public int? Temperatura { get; set; }

        public string DescripcionIdUsuario { get; set; }

    }
}
