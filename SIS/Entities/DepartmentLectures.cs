namespace SIS.Entities
{
    public class DepartmentLectures
    {
        public int departments_id {  get; set; }
        public int lectures_id { get; set; }

        public Department department { get; set; } = null!;
        public Lecture lecture { get; set; } = null!;

    }
}
