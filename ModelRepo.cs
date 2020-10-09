using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BusinessEntities;

namespace DAL
{
    public class ModelRepo : BaseRepo, IModelRepo
    {
        public IEnumerable<Models> GetMakeModels(int makeId)
        {
            List<Models> models = new List<Models>();
            using (var con = GetOpenConnection())
            {
                SqlCommand cmd = new SqlCommand("Select ModelId, Model From Models Where MakeId="+ makeId, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Models model = new Models();
                    model.ModelId = Convert.ToInt32(rdr["ModelId"]);
                    model.Model = rdr["Model"].ToString();
                    models.Add(model);
                }
            }
            return models;
        }
    }
}
