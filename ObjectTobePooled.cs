using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ObjectTobePooled
{
    internal interface IObjectPool
    {
        public GenericPool pool { get; set; }
    }
}
