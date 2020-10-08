using AlertToCare.Models;

namespace AlertToCare.Repository
{
    public interface IIcuLayoutManagement
    {
        public bool GetLayoutInformation(IcuWardLayoutModel objLayout);
    }
}
