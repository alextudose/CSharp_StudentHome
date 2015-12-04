using StudentHome.Core;
using StudentHome.Domain;

namespace StudentHome.Repository
{
    public class StudentRepository : CrudRepository<Student>
    {
        public StudentRepository()
        {
            LoadAllFromXml(Constants.StudentResourcePath);
            GeneratedId = Count();
        }

        protected override void SetId(Student obj)
        {
            GeneratedId++;
            obj.Id = GeneratedId;
        }
    }
}
