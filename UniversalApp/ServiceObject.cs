using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalApp
{
    class ServiceObject
    {
        public int ServiceId { get; set; }
        public int RoomId { get; set; }
        public int Description { get; set; }
        public String ServiceType { get; set; }
        public String ServiceStatus { get; set; }
        public System.DateTime Time { get; set; }
        public Nullable <System.DateTime> TimeCompleted { get; set; }
        public virtual Room ServiceRoom { get; set; }
    }
}
