using Microsoft.EntityFrameworkCore;
using CalculadoraDosificacionHormigon.Modelo;
namespace CalculadoraDosificacionHormigon.Data;


public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }
    public DbSet<CalculoHormigon> CalculosHormigon { get; set; }
}
