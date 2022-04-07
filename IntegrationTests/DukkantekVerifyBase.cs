using VerifyTests;
using VerifyXunit;

namespace Dukkantek.IntegrationTests
{
    public class DukkantekVerifyBase : VerifyBase
    {
        public DukkantekVerifyBase()
            : base(GetVerifySettings())

        { }

        private static VerifySettings GetVerifySettings()
        {
            var settings = new VerifySettings();

            settings.UseDirectory("__Verify__");
            settings.ModifySerialization(x =>
            {
                x.IgnoreMember("traceId");
            });

            return settings;
        }
    }
}
