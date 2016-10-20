namespace SMS.Data
{
    using SMS.Data.Repositories;
    using SMS.Models;

    public interface ISMSData
    {
        IRepository<Availability> Availabilities { get; }

        IRepository<CallSettings> CallSettings { get; }

        IRepository<Report> Reports { get; }

        IRepository<SupportAgent> SupportAgents { get; }

        IRepository<SupportAgentsAvailability> SupportAgentsAvailabilities { get; }

        int SaveChanges();
    }
}