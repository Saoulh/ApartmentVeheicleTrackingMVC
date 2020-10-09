using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public  interface IVehicleRepo
    {
        IEnumerable<VehicleView> GetVehicles();
        bool AddVehicle(Vehicles vehicle);
        bool Update(Vehicles vehicle);
        bool Delete(int vehicleId);
    }
}
