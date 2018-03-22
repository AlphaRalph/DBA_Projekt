namespace DBA_Projekt
{
    public class Teacher : IDbItem<Teacher>
    {
        #region properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #endregion

        #region IEquals interface
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