using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ReportesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReportesController(AppDbContext context)
    {
        _context = context;
    }

    // Reporte de reservas por mes para un usuario y una aplicación específicos
    [HttpGet("reservas-por-mes")]
    public async Task<ActionResult<IEnumerable<object>>> ObtenerReservasPorMes(int usuarioId, int aplicacionId)
    {
        var reservasPorMes = await _context.Reservas
            .Where(r => r.UsuarioID == usuarioId && r.AplicacionID == aplicacionId)
            .GroupBy(r => new { Mes = r.FechaReserva.Month, Año = r.FechaReserva.Year })
            .Select(g => new
            {
                Mes = g.Key.Mes,
                Año = g.Key.Año,
                CantidadReservas = g.Count()
            })
            .ToListAsync();

        return Ok(reservasPorMes);
    }

    // Reporte de reservas por año para un usuario y una aplicación específicos
    [HttpGet("reservas-por-ano")]
    public async Task<ActionResult<IEnumerable<object>>> ObtenerReservasPorAno(int usuarioId, int aplicacionId)
    {
        var reservasPorAno = await _context.Reservas
            .Where(r => r.UsuarioID == usuarioId && r.AplicacionID == aplicacionId)
            .GroupBy(r => r.FechaReserva.Year)
            .Select(g => new
            {
                Año = g.Key,
                CantidadReservas = g.Count()
            })
            .ToListAsync();

        return Ok(reservasPorAno);
    }
}
