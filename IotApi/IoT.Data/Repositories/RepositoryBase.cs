using IoT.Data.Databases;

namespace IoT.Data.Repositories
{
   
    public class RepositoryBase
    {

        private readonly IoTDataContext _dataContext;

        protected IoTDataContext IoTDContext { get { return _dataContext; } }

        public RepositoryBase(IoTDataContext context)
        {
            _dataContext = context;
        }
    }
}