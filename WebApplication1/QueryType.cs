using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Types;

namespace WebApplication1
{
    public class QueryType
    {
        [UseFiltering]
        public IEnumerable<Slot> Slots() => new List<Slot>() { new Slot() {  Start =  new DateTime(), End = new DateTime() } };
    }
}
