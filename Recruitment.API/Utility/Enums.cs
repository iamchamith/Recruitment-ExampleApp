using System.ComponentModel;

namespace Recruitment.API.Utility
{
    public class Enums
    {
        public enum ApplicationEnvironment : byte
        {
            [Description(nameof(Production))]
            Production,
            [Description(nameof(Staging))]
            Staging,
        }
    }
}
