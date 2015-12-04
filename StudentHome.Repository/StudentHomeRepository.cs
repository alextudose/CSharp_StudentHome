using StudentHome.Core;

namespace StudentHome.Repository
{
    public class StudentHomeRepository : CrudRepository<Domain.StudentHome>
    {
        public StudentHomeRepository()
        {
            LoadAllFromXml(Constants.StudentHomeResourcePath);
            GeneratedId = Count();
        }

        protected override void SetId(Domain.StudentHome obj)
        {
            GeneratedId++;
            obj.Id = GeneratedId;
        }
    }
}
