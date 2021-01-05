using MediatR;
using Recruitment.API.Utility;
using Recruitment.Contracts;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Recruitment.API.Application
{
    public class LoginRequestCommandHandler : IRequestHandler<LoginRequestCommand, LoginResponse>
    {
        public HttpClient _client { get; }

        public LoginRequestCommandHandler(IHttpClientFactory client)
        {
            _client = client.CreateClient();
            _client.BaseAddress = new Uri(AppSettings.FunctionUrl);
        }
        public async Task<LoginResponse> Handle(LoginRequestCommand request, CancellationToken cancellationToken)
        {
            var requestJson = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Login", requestJson);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new AuthenticationException(response);
            var contents = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(contents))
                throw new AuthenticationException();

            return new LoginResponse(contents);
        }
    }
}
