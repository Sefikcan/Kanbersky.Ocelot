namespace Kanbersky.Ocelot.Core.Settings.Concrete
{
    public class MassTransitSettings : ISettings
    {
        public string MassTransitUri { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
