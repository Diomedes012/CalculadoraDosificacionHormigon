using System.ComponentModel.DataAnnotations;

namespace CalculadoraDosificacionHormigon.Modelo;

public class CalculoHormigon
{
    [Key]
    public int CalculoId { get; set; }
    public DateTime FechaCalculo { get; set; } = DateTime.Now;
    public double Cemento { get; set; }
    public double Agua { get; set; }
    public double Arena { get; set; }
    public double Grava { get; set; }
    public double VolumenTotal { get; set; }
    public double RelacionAguaCemento { get; set; }
    public double ResistenciaEstimada { get; set; }
    public bool Eliminado { get; set; } = false;

}
