
public class Usuario
{
    public int UsuarioID { get; set; }
    public string Nombre { get; set; }
    public List<Reserva> Reservas { get; set; }
}