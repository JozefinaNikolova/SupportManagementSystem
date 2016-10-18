namespace SMS.Data
{
    using SMS.Data.Repositories;
    using SMS.Models;

    public interface ISMSData
    {
        //IRepository<MyEntity> MyEntities { get; }

        int SaveChanges();
    }
}
