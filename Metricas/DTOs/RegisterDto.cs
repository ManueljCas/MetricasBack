namespace Metricas.DTOs
{
    public class RegisterDto
    {
        public string Username { get; set; }  // Nombre de usuario
        public string Email { get; set; }  // Correo electrónico del usuario
        public string Password { get; set; }  // Contraseña en texto plano (se debería hash en el servicio)
    }
}
