using hf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hf.Repository
{
    interface IHistoricRepository
    {
        PageInfo GetHistoricInfo();
        IEnumerable<HistoricLocation> GetHistoricLocation();
    }
}
