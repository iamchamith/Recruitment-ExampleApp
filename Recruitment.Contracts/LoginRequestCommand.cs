using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.Contracts
{
    [Serializable]
    public class LoginRequestCommand : IRequest<LoginResponse>
    {
        [Required(ErrorMessage = "User name required"), StringLength(50)]
        public string UserName { get; set; }
        [Required(), StringLength(50)]
        public string Password { get; set; }
    }
}
