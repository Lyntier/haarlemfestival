using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hf.Models;

namespace hf.Repository
{
    interface IOrderRepository
    {
        void CreateOrder(Order order);
        bool CheckifKeyExist(string key);
        Order GetLastOrder();
        Event GetEventByEvent(Event @event);
    }
}
