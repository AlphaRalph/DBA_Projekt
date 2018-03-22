using System.Linq;

namespace DBA_Projekt
{
    public class Teacher : IDbItem<Teacher>
    {
        #region properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #endregion

        #region methods
        public new string ToString() => LastName + " " + FirstName;

        public static Teacher Parse(string teacherString)
        {
            var info = teacherString.Split(' ');
            if (info.Length == 2) return null;

            return new Teacher
            {
                LastName = info[0].Trim(),
                FirstName = info[1].Trim()
            };
        }

        public static Teacher[] Parse(string[] teacherStrings) => teacherStrings.Select(Parse).Where(teacher => teacher != null).ToArray();
        #endregion

        #region IDbItem interface
        public new bool Equals(object other)
        {
            if (other is null) return false;
            if (other.GetType() != GetType()) return false;
            return base.Equals((Teacher) other);
        }

        public bool Equals(Teacher other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName);
        }
        #endregion
    }
}