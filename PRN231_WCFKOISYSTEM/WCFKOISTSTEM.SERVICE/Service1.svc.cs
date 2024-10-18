using System;
using System.Collections.Generic;

namespace WCFKOISTSTEM.SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class Service1 : IService1
    {
        private TravelService travelService = new TravelService();

        public bool CreateOrUpdateTravel(Travel travel)
        {
            try
            {
                if (string.IsNullOrEmpty(travel.Id))
                {
                    travelService.CreateTravel(travel);
                }
                else
                {
                    travelService.UpdateTravel(travel);
                }
                return true; 
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteTravel(string id)
        {
            try
            {
                travelService.DeleteTravel(id);
                return true; 
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

        public List<Travel> GetTravels()
        {
            return travelService.GetTravels();
        }

        public Travel GetTravelById(string id)
        {
            return travelService.GetTravelById(id);
        }

    }


}
