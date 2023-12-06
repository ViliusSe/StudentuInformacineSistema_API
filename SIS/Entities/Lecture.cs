namespace SIS.Entities
{
    public class Lecture: BaseEntities
    {
        public List<StudentLectures> studentLectures { get; set; } = new();
        public List<DepartmentLectures> departmentLectures { get; set; } = new();

    }
}
