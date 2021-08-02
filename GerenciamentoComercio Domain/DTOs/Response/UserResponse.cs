using System.Collections.Generic;

namespace GerenciamentoComercio_Domain.DTOs.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserClaimsResponse> Claims { get; set; }
    }
}
