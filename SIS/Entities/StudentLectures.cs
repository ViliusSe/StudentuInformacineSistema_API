namespace SIS.Entities
{
    public class StudentLectures
    {
        public int students_id { get; set; }
        public int lectures_id { get; set; }

        public Student student { get; set; } = null!;
        public Lecture lecture { get; set; } = null!;
    }
}
