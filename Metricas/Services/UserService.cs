using Metricas.Data;
using Metricas.DTOs;
using Metricas.Models;
using System;
using System.Threading.Tasks;

namespace Metricas.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly LogService _logService;

        public UserService(AppDbContext context, LogService logService)
        {
            _context = context;
            _logService = logService;
        }

        public async Task<UserDto> RegisterUser(RegisterDto registerDto)
        {
            try
            {
                if (_context.Users.Any(u => u.Email == registerDto.Email))
                {
                    await _logService.LogEventAsync("Registro", "Intento de registro fallido", true, null, $"Correo electrónico ya registrado: {registerDto.Email}");
                    throw new Exception("El usuario con este correo electrónico ya existe.");
                }

                var user = new User
                {
                    Username = registerDto.Username,
                    Email = registerDto.Email,
                    PasswordHash = registerDto.Password, // Asegúrate de aplicar un hash para seguridad
                    CreatedAt = DateTime.Now
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                await _logService.LogEventAsync("Registro", "Nuevo usuario registrado", false, user.UserId, $"Usuario: {registerDto.Username}");

                return new UserDto { UserId = user.UserId, Username = user.Username, Email = user.Email };
            }
            catch (Exception ex)
            {
                await _logService.LogEventAsync("Registro", "Error en el registro de usuario", true, null, ex.Message);
                throw;
            }
        }

        public async Task<UserDto> LoginUser(LoginDto loginDto)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(u => u.Email == loginDto.Email && u.PasswordHash == loginDto.Password);
                if (user == null)
                {
                    await _logService.LogEventAsync("Inicio de sesión", "Intento de inicio de sesión fallido", true, null, $"Correo o contraseña incorrectos para: {loginDto.Email}");
                    throw new Exception("Correo o contraseña incorrectos.");
                }

                await _logService.LogEventAsync("Inicio de sesión", "Inicio de sesión exitoso", false, user.UserId, $"Usuario: {loginDto.Email}");

                return new UserDto { UserId = user.UserId, Username = user.Username, Email = user.Email };
            }
            catch (Exception ex)
            {
                await _logService.LogEventAsync("Inicio de sesión", "Error en el inicio de sesión", true, null, ex.Message);
                throw;
            }
        }
    }
}
