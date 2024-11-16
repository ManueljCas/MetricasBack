namespace Metricas.Models
{
    public class Log
    {
        public int LogId { get; set; }  // Identificador único del log
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;  // Fecha y hora del evento
        public string EventType { get; set; }  // Tipo de evento (ej. "Registro", "Inicio de sesión")
        public string Action { get; set; }  // Acción realizada (ej. "Nuevo usuario registrado")
        public string Message { get; set; }  // Mensaje de error, si aplica
        public bool IsError { get; set; }  // Indica si es un error
        public int? UserId { get; set; }  // ID del usuario asociado al evento (puede ser NULL)
        public string Details { get; set; }  // Información adicional del evento

        // Relación con la tabla Users (opcional si se requiere navegación)
        public User User { get; set; }
    }
}
