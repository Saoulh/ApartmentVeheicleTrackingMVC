using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IMakesRepo
    {
        IEnumerable<Makes> GetMakes();
    }
}
