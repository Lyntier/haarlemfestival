using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hf.Models;

namespace hf.Repository
{
    public interface IHomeRepository
    {
        PageInfo GetPageInfo();
    }
}