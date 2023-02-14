﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiOwo.Models
{
    public class Producto
    {
        private long id;
        private string descripcion;
        private decimal costo;
        private decimal precioVenta;
        private int stock;
        private long idUsuario;
        public Producto()
        {
        }
        public Producto(long id, string descripcion, decimal costo, decimal precioVenta, int stock, long idUsuario)
        {
            Id = id;
            Descripcion = descripcion;
            Costo = costo;
            PrecioVenta = precioVenta;
            Stock = stock;
            IdUsuario = idUsuario;
        }

        public long Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Costo { get => costo; set => costo = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Stock { get => stock; set => stock = value; }
        public long IdUsuario { get => idUsuario; set => idUsuario = value; }

        public override string ToString()
        {
            return $"nombre: {descripcion}";
        }
    }
}
