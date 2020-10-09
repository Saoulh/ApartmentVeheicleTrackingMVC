using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BusinessEntities;

namespace DAL
{
    public class OwnerRepo : BaseRepo, IOwnerRepo
    {
        public IEnumerable<Owners> GetOwners()
        {
            List<Owners> owners = new List<Owners>();
            using (var con = GetOpenConnection())
            {
                SqlCommand cmd = new SqlCommand("Select ownerId, FirstName , LastName From Owners", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Owners owner = new Owners();
                    owner.OwnerID = Convert.ToInt32(rdr["ownerId"]);
                    owner.FirstName = rdr["FirstName"].ToString();
                    owner.LastName = rdr["LastName"].ToString();
                    owners.Add(owner);
                }
            }
            return owners;
        }
    }
}
