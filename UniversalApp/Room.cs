using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalApp
{
    class Room
    {
        public int RoomId { get; set; }
        public int RoomNum { get; set; }
        public int RoomSize { get; set; }
        public int NumOfBeds { get; set; }
        public bool Booked { get; set; }
    }
}
