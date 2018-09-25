using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_Projekt
{
    public class Raum
    {
        private static int id = 100;
        public string Building { get; }
        public string Type { get; }
        public string RoomName { get; }
        public int Id { get; set; }

        public Raum(string building, string type, string roomName)
        {
            Building = building;
            Type = type;
            RoomName = roomName;
            Id = ++id;
        }

        public override string ToString()
        {
            return Building + " | " + Type + " - " + RoomName;
        }
    }
}
