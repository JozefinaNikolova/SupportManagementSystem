namespace SMS.Data
{
    using System;
    using System.Collections.Generic;
    using SMS.Data.Repositories;
    using SMS.Models;

    public class SMSData : ISMSData
    {
        private SMSContext context;
        private IDictionary<Type, object> repositories;

        public SMSData(SMSContext context)
        {
            this.context = context;
            repositories = new Dictionary<Type, object>();
        }

        public IRepository<Availability> Availabilities
        {
            get { return this.GetRepository<Availability>(); }
        }

        public IRepository<CallSettings> CallSettings
        {
            get { return this.GetRepository<CallSettings>(); }
        }

        public IRepository<Report> Reports
        {
            get { return this.GetRepository<Report>(); }
        }

        public IRepository<SupportAgent> SupportAgents
        {
            get { return this.GetRepository<SupportAgent>(); }
        }

        public IRepository<SupportAgentsAvailability> SupportAgentsAvailabilities
        {
            get { return this.GetRepository<SupportAgentsAvailability>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
