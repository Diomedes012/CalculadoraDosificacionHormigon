using CalculadoraDosificacionHormigon.Data;
using CalculadoraDosificacionHormigon.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CalculadoraDosificacionHormigon.Services;


public class CalculoHormigonService(IDbContextFactory<Contexto> factory)
{
    public async Task<bool> Guardar(CalculoHormigon calculo)
    {
        if (calculo.VolumenTotal <= 0)
        {
            throw new ArgumentException("El volumen total debe ser mayor a cero.");
        }

        await using var contexto = await factory.CreateDbContextAsync();

        if (!await Existe(calculo.CalculoId))
        {
            return await Insertar(calculo);
        }
        else
        {
            return await Modificar(calculo);
        }
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await factory.CreateDbContextAsync();
        return await contexto.CalculosHormigon.AnyAsync(c => c.CalculoId == id);
    }

    private async Task<bool> Insertar(CalculoHormigon calculo)
    {
        await using var contexto = await factory.CreateDbContextAsync();
        contexto.CalculosHormigon.Add(calculo);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(CalculoHormigon calculo)
    {
        await using var contexto = await factory.CreateDbContextAsync();
        contexto.CalculosHormigon.Update(calculo);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<CalculoHormigon?> Buscar(int id)
    {
        await using var contexto = await factory.CreateDbContextAsync();
        return await contexto.CalculosHormigon
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CalculoId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await factory.CreateDbContextAsync();

        var calculo = await contexto.CalculosHormigon.FindAsync(id);
        if (calculo == null) return false;

        calculo.Eliminado = true;
        contexto.CalculosHormigon.Update(calculo);

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Recuperar(int id)
    {
        await using var contexto = await factory.CreateDbContextAsync();

        var calculo = await contexto.CalculosHormigon.FindAsync(id);
        if (calculo == null) return false;

        calculo.Eliminado = false;
        contexto.CalculosHormigon.Update(calculo);

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<CalculoHormigon>> Listar(Expression<Func<CalculoHormigon, bool>> criterio)
    {
        await using var contexto = await factory.CreateDbContextAsync();
        return await contexto.CalculosHormigon
            .Where(criterio)
            .AsNoTracking()
            .OrderByDescending(c => c.FechaCalculo)
            .ToListAsync();
    }
}
