using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Types
{
    public class Appointment : Slot
    {
        public Appointment() {
            Start = DateTime.Now;
            End = DateTime.Now;
        }
    }
}
