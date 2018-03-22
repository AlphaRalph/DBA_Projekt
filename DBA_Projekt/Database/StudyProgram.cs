namespace DBA_Projekt
{
    public class StudyProgram : IDbItem<StudyProgram>
    {
        #region properties
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public int ProgramNumber { get; set; }
        public string ProgramGraduate { get; set; }
        public string ProgramType { get; set; }
        #endregion

        #region IEqals interface
        public new bool Equals(object other)
        {
            if (other is null) return false;
            if (other.GetType() != GetType()) return false;
            return Equals((StudyProgram) other);
        }

        public bool Equals(StudyProgram other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(ProgramName, other.ProgramName)
                && Equals(ProgramNumber, other.ProgramNumber)
                && string.Equals(ProgramGraduate, other.ProgramGraduate)
                && string.Equals(ProgramType, other.ProgramType);
        }
        #endregion
    }
}