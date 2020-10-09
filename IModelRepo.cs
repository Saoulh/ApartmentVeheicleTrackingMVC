using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IModelRepo
    {
        IEnumerable<Models> GetMakeModels(int makeId);
    }
}
