using System;
using System.IO;

namespace DBA_Projekt
{
    public static class CsvHelper
    {
        public static void ReadCsv(string filepath, int headercount,
            out DbItemCollection<Appointment> appointmentCollection,
            out DbItemCollection<StudyProgram> studyProgramCollection,
            out DbItemCollection<Room> roomCollection,
            out DbItemCollection<Teacher> teacherCollection)
        {
            studyProgramCollection = new DbItemCollection<StudyProgram>();
            roomCollection = new DbItemCollection<Room>();
            teacherCollection = new DbItemCollection<Teacher>();
            appointmentCollection = new DbItemCollection<Appointment>();

            var file = File.ReadAllLines(filepath);

            for (var i = 0; i < file.Length; i++)
            {
                if (i < headercount) continue;
                var items = file[i].Split(';');
                if (items.Length != 17) continue;
                
                var studyProgram = StudyProgram.Parse(items[0], items[1]);
                var rooms = Room.Parse(items[10].Split(','));
                var teachers = Teacher.Parse(items[13].Split(','));

                if (studyProgram == null && rooms.Length == 0 && teachers.Length == 0) continue;

                var appointment = new Appointment
                {
                    StudyProgram = studyProgram,
                    SemesterName = items[3],
                    SemesterNumber = IntParser(items[4]),
                    Beginning = DateTime.Parse(items[6].Split(',')[1].Trim() + " " + items[7]),
                    Ending = DateTime.Parse(items[6].Split(',')[1].Trim() + " " + items[8]),
                    Rooms = rooms.Length > 0 ? rooms : null,
                    Identification = items[12],
                    Teachers = teachers.Length > 0 ? teachers : null,
                    Type = items[15]
                };

                studyProgramCollection.Add(studyProgram);
                roomCollection.AddRange(rooms);
                teacherCollection.AddRange(teachers);
                appointmentCollection.Add(appointment);
            }
        }
        
        private static int? IntParser(string input) => int.TryParse(input, out var res) ? (int?) res : null;
    }
}