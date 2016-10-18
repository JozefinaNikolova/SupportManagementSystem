namespace SMS.Data
{
    using System;
    using System.Collections.Generic;
    using SMS.Data.Repositories;

    public class SMSData : ISMSData
    {
        private SMSContext context;
        private IDictionary<Type, object> repositories;

        public SMSData(SMSContext context)
        {
            this.context = context;
            repositories = new Dictionary<Type, object>();
        }

        //public IRepository<User> Users
        //{
        //    get { return this.GetRepository<User>(); }
        //}


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
