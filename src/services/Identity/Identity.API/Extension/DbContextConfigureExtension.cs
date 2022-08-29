namespace Identity.API.Extension
{
    public static class DbContextConfigureExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, string connectionString, string migrationsAssembly)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(migrationsAssembly);
                    sqlOptions.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
                }));
        }
    }
}
