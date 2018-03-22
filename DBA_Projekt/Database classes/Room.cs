using System.Linq;

namespace DBA_Projekt
{
    public class Room : IDbItem<Room>
    {
        #region properties
        public int Id { get; set; }
        public string Building { get; set; }
        public string Type { get; set; }
        public string RoomName { get; set; }
        #endregion

        #region methods
        public new string ToString() => Building + " | " + Type + " - " + RoomName;

        public static Room Parse(string roomString)
        {
            var info = roomString.Split('|', '-', '(');
            if (info.Length < 3) return null;

            return new Room
            {
                Building = info[0].Trim(),
                Type = info[1].Trim(),
                RoomName = info[2].Trim()
            };
        }

        public static Room[] Parse(string[] roomStrings) => roomStrings.Select(Parse).Where(room => room != null).ToArray();
        #endregion

        #region IDbItem interface
        public override bool Equals(object other)
        {
            if (other is null) return false;
            if (other.GetType() != GetType()) return false;
            return Equals((Room) other);
        }

        public bool Equals(Room other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Building, other.Building)
                && string.Equals(Type, other.Type)
                && string.Equals(RoomName, other.RoomName);
        }
        #endregion
    }
}