using GerenciamentoComercio_Domain.DTOs.Request;
using GerenciamentoComercio_Domain.DTOs.Response;
using GerenciamentoComercio_Domain.ErrorHandler.ErrorStatusCodes;
using GerenciamentoComercio_Domain.Settings;
using GerenciamentoComercio_Domain.Utils;
using GerenciamentoComercio_Domain.v1.Interfaces.Repositories;
using GerenciamentoComercio_Domain.v1.Interfaces.Services;
using GerenciamentoComercio_Infra.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace GerenciamentoComercio_Domain.v1.Services
{
    public class AuthenticationService : IAuthenticationServices
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly JwtSettings _jwtSettings;
        public AuthenticationService(IEmployeeRepository employeeRepository,
            IOptions<JwtSettings> jwtSettings)
        {
            _employeeRepository = employeeRepository;
            _jwtSettings = jwtSettings.Value;
        }

        public APIMessage Login(LoginRequest request)
        {
            Employee user = _employeeRepository.GetUserLogin(request.Access, request.Password);

            if (user == null)
                return new APIMessage(HttpStatusCode.NotFound,
                    new List<string> { "Usuário não encontrado. Login e/ou senha incorretos." });
            //throw new NotFoundException("Usuário não encontrado. Login e/ou senha incorretos.");

            //return GenerateJwtToken(user);
            return new APIMessage(HttpStatusCode.OK, GenerateJwtToken(user));
        }

        public LoginResponse GenerateJwtToken(Employee user)
        {
            byte[] key = Encoding.ASCII.GetBytes(_jwtSettings.Key);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.FullName),
                new Claim("IsAdministrator", user.IsAdministrator.Value.ToString())
            };

            ClaimsIdentity identityClaims = new ClaimsIdentity();

            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                Subject = identityClaims,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            });

            var encodedToken = tokenHandler.WriteToken(token);
            return new LoginResponse
            {
                AccessToken = encodedToken,
                User = new UserResponse
                {
                    Id = user.Id,
                    Name = user.FullName,
                    Email = user.Email,
                    Claims = claims.Select(c => new UserClaimsResponse { Type = c.Type, Value = c.Value })
                }
            };
        }

        private static long ToUnixEpochDate(DateTime date)
        => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
