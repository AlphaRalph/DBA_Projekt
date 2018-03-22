using System;

namespace DBA_Projekt
{
    public class Appointment : IDbItem<Appointment>
    {
        #region properties
        public int Id { get; set; }
        public string SemesterName { get; set; }
        public int SemesterNumber { get; set; }
        public DateTime? Beginning { get; set; }
        public DateTime? Ending { get; set; }
        public string Type { get; set; }
        public string Identification { get; set; }
        public StudyProgram StudyProgram { get; set; }
        public Room Room { get; set; }
        public Teacher Teacher { get; set; }
        #endregion

        #region IEquals interface
        public new bool Equals(object other)
        {
            if (other is null) return false;
            if (other.GetType() != GetType()) return false;
            return base.Equals((Appointment) other);
        }

        public bool Equals(Appointment other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(SemesterName, other.SemesterName)
                && Equals(SemesterNumber, other.SemesterNumber)
                && Beginning == other.Beginning
                && Ending == other.Ending
                && string.Equals(Type, other.Type)
                && StudyProgram == other.StudyProgram
                && Room == other.Room
                && Teacher == other.Teacher;
        }
        #endregion
    }
}