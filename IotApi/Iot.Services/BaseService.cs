using IoT.Data.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iot.Services
{
    public class BaseService
    {
        protected IoTDataContext DataContext;

        protected BaseService(IoTDataContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            DataContext = context;

        }
    }
}
