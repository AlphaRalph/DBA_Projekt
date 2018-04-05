using System;

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
        
        #region methods
        public new string ToString() => ProgramName + (ProgramGraduate != string.Empty ? "." + ProgramGraduate : "") + " (" + ProgramNumber + ")";

        public static StudyProgram Parse(string studyString, string type)
        {
            var info = studyString.Split('.', '(', ')');
            if (info.Length < 3) return null;

            if (info.Length == 3)
            {
                return new StudyProgram
                {
                    ProgramName = info[0].Trim(),
                    ProgramNumber = Convert.ToInt32(info[1]),
                    ProgramType = type
                };
            }
            return new StudyProgram
            {
                ProgramName = info[0].Trim(),
                ProgramGraduate = info[1].Trim(),
                ProgramNumber = Convert.ToInt32(info[2]),
                ProgramType = type
            };
        }
        #endregion

        #region IDbItem interface
        public override bool Equals(object other)
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
                && ProgramNumber == other.ProgramNumber
                && string.Equals(ProgramGraduate, other.ProgramGraduate)
                && string.Equals(ProgramType, other.ProgramType);
        }
        #endregion
    }
}