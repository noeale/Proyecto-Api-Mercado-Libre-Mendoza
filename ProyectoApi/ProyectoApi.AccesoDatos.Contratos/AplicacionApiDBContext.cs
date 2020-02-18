using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoApi.AccesoDatos.Contratos
{
    public class AplicacionApiDBContext : DbContext
    {

        public AplicacionApiDBContext()
        {

        }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
