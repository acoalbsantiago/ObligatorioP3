﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Exceptions
{
    public class PagoException : Exception
    {
        public PagoException() { }
        public PagoException(string mensaje)
        : base(mensaje) { }
        public PagoException(string mensaje, Exception ex)
        : base(mensaje, ex) { }
    }
}
