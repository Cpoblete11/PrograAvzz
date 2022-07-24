using Microsoft.Extensions.Configuration;



namespace PrograAvz.Models.DAL

{
    public class Class
    {
        String file = "appsettings.json";
        public static IConfiguration Configuration;

        public Class()
        {
            init();
        }

        private void init()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(file);

            Configuration = builder.Build();
        }
        public String GetBd()
        {
            return Configuration["ConnectionStrings:ApplicationDbContextConnection"];
        }
    }
}
