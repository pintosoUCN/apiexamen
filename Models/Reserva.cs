public class Reserva
{
    public int ReservaID { get; set; }
    public int UsuarioID { get; set; }
    public int AplicacionID { get; set; }
    public DateTime FechaReserva { get; set; }
    public int DuracionDias { get; set; }

    public Usuario Usuario { get; set; }
    public Aplicacion Aplicacion { get; set; }
}