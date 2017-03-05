using MaiNguyen.Service.Implements;
using MaiNguyen.Service.Interfaces;

namespace MaiNguyen.GUI.Business
{
    public class BaseBusiness
    {
        protected ITestService dbContext;
        public BaseBusiness()
        {
            dbContext = new TestService();
        }
    }
}
