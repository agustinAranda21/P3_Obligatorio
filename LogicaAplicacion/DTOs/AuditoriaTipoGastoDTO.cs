using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs
{
    public class AuditoriaTipoGastoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
    }
}
