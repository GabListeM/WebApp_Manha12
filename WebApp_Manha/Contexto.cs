﻿using Microsoft.EntityFrameworkCore;
using WebApp_Manha.Entidades;

namespace WebApp_Manha
{
    public class Contexto : DbContext
    {
        public Contexto( DbContextOptions<Contexto> opt) : base(opt)
        {
        
        }
        
        public DbSet<Produtos> Produtos { get; set; }



    }
}
