namespace Recruitment.Contracts
{
    public class LoginResponse
    {
        public string Hash_value { get; private set; }
        public LoginResponse(string hashValue)
        {
            Hash_value = hashValue;
        }
    }
}
