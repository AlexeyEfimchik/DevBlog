namespace Identity.API.Extension
{
    public static class HealthCheckConfigureExtension
    {
        public static void ConfigureHealthCheck(this IServiceCollection services, string connectionString)
        {
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddSqlServer(connectionString,
                  name: "IdentityDb-check",
                  tags: new string[] { "IdentityDB" });
        }
    }
}
