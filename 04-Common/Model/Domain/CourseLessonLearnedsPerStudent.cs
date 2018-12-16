using Common;
using Common.CustomFilters;
using Model.Auth;
using Model.Helper;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class CourseLessonLearnedsPerStudent : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }

        public LessonsPerCourse Lesson { get; set; }
        public int LessonsId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public bool Deleted { get; set; }
    }
}
