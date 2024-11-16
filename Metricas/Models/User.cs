namespace Metricas.Models
{
    public class User
    {
        public int UserId { get; set; }  // Identificador único
        public string Username { get; set; }  // Nombre de usuario
        public string Email { get; set; }  // Correo electrónico del usuario
        public string PasswordHash { get; set; }  // Contraseña en formato hash
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Fecha de creación
        public DateTime? UpdatedAt { get; set; }  // Fecha de actualización (opcional)
    }
}
