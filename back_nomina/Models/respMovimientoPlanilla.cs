﻿namespace back_nomina.Models
{
    public class respMovimientoPlanilla
    {
        public string CodigoConcepto { get; set; }

        public string Concepto { get; set; }
        public string Prioridad { get; set; }
        public string TipoOperacion { get; set; }

        public string Cuenta1 { get; set; }
        public string Cuenta2 { get; set; }
        public string Cuenta3 { get; set; }

        public string Cuenta4 { get; set; }
        public string MovimientoExcepcion1 { get; set; }

        public string MovimientoExcepcion2 { get; set; }
        public string MovimientoExcepcion3 { get; set; }
        public string Aplica_iess { get; set; }

        public string Aplica_imp_renta { get; set; }
        public string Empresa_Afecta_Iess { get; set; }
        public string Mensaje { get; set; }

    }
}
