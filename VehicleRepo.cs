using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BusinessEntities;

namespace DAL
{
    public class VehicleRepo : BaseRepo, IVehicleRepo
    {
        public IEnumerable<VehicleView> GetVehicles()
        {
            List<VehicleView> vehicles = new List<VehicleView>();
            using (var con = GetOpenConnection())
            {

                String sql = " SELECT VehicleId, ";
                       sql += "        FirstName + ' ' + LastName as OwnersName, ";
                       sql += "        Make,Model,Color,RegistrationNumber,DateRegistered ";
                       sql += " FROM Vehicles ";
                       sql += " INNER JOIN Owners   ON Vehicles.OwnerId=Owners.OwnerId ";
                       sql += " INNER JOIN Makes   ON Vehicles.MakeId= Makes.MakeId ";
                       sql += " INNER JOIN Models   ON Vehicles.ModelId= Models.ModelId";


                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    VehicleView vehicleView = new VehicleView();
                    vehicleView.VehicleId = Convert.ToInt32(rdr["VehicleId"]);
                    vehicleView.OwnersName = rdr["OwnersName"].ToString();
                    vehicleView.Make = rdr["Make"].ToString();
                    vehicleView.Model = rdr["Model"].ToString();
                    vehicleView.Color = rdr["Color"].ToString();
                    vehicleView.Registration = rdr["RegistrationNumber"].ToString();
                    vehicleView.DateRegistered = (DateTime)rdr["DateRegistered"];
                    vehicles.Add(vehicleView);
                }
            }
            return vehicles;
        }

        public bool AddVehicle(Vehicles vehicle)
        {
            int result = -1;
            using (var con = GetOpenConnection())
            {
                String sql = "INSERT INTO Vehicles (OwnerId,MakeID,ModelId,Color,RegistrationNumber,DateRegistered )";
                       sql += "VALUES (@OwnerId,@MakeID,@ModelId, @Color,@RegistrationNumber,@DateRegistered)";

               
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@OwnerId", vehicle.OwnerId);
                cmd.Parameters.AddWithValue("@MakeID", vehicle.MakeID);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd.Parameters.AddWithValue("@RegistrationNumber", vehicle.Registration);
                cmd.Parameters.AddWithValue("@DateRegistered", vehicle.DateRegistered);

                result = cmd.ExecuteNonQuery();
            }
            return (result > 0);
        }

        public bool Delete(int vehicleId)
        {
            throw new NotImplementedException();
        }
        public bool Update(Vehicles vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
