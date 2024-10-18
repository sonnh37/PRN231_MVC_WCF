using System.Collections.Generic;
using System.ServiceModel;

namespace WCFKOISTSTEM.SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Travel> GetTravels();
        [OperationContract]
        bool CreateOrUpdateTravel(Travel travel);
        [OperationContract]
        bool DeleteTravel(string id);
        [OperationContract]
        Travel GetTravelById(string id);
    }
}
