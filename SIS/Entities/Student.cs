﻿namespace SIS.Entities
{
    public class Student : BaseEntities
    {
        int departments_id {  get; set; }

        public List<Lecture> lectures_id { get; set; } = new();
    }
}
