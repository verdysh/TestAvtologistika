using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data;

namespace Test.Services
{
    abstract public class ServiceBase: IDisposable
    {
        protected UnitOfWork _unitOfWork;

        public ServiceBase()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
