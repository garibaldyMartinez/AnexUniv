using Common;
using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain
{
    public class LessonsPerCourse : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Video { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
        public bool Deleted { get; set; }
    }
}
