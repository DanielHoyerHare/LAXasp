using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAXasp.Models
{
    public class Film
    {
        public int FilmID { get; set; }
        public string Titel { get; set; }
        public string Instruktør { get; set; }
        public int Årstal { get; set; }
        public string Længde { get; set; }
        public int Rating { get; set; }
        public string Genre { get; set; }
    }
    public class FilmDBContext:DbContext
    {
        public DbSet<Film> Film { get; set; }
    }
}