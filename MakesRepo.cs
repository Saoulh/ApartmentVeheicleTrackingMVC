using BusinessEntities;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class MakesRepo : BaseRepo , IMakesRepo
    {
        public IEnumerable<Makes> GetMakes()
        {
            List<Makes> makes = new List<Makes>();
            using (var con = GetOpenConnection())
            {
                SqlCommand cmd = new SqlCommand("Select MakeId, Make From Makes", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Makes make = new Makes();
                    make.MakeId = Convert.ToInt32(rdr["MakeId"]);
                    make.Make = rdr["Make"].ToString();
                    makes.Add(make);
                }
            }
            return makes;
            
        }
    }
}