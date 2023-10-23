using TaskHTT.Core.Configurations;

namespace TaskHTT.UI
{
    public class AppSettings
    {
        public static AppSettings Instance { get; private set; } = null!;
        public DatabaseConfig Database { get; set; } = null!;

        public static void Init(AppSettings instance)
            => Instance = instance;
    }
}
