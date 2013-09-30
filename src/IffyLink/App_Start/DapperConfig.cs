using DapperExtensions.Mapper;

namespace WorldWideWat.IffyLink.App_Start
{
    public static class DapperConfig
    {
        public static void Configure()
        {
            DapperExtensions.DapperExtensions.DefaultMapper = typeof (PluralizedAutoClassMapper<>);
        }
    }
}