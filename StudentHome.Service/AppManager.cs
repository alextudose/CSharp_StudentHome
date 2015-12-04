using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentHome.Core;
using StudentHome.Domain;
using StudentHome.Repository;
using StudentHome.Service.Validators;

namespace StudentHome.Service
{
    public class AppManager
    {
        private EmployeeRepository employeeRepository;
        private PersonValidator employeeValidator;
        private StudentHomeRepository studentHomeRepository;
        private StudentHomeValidator studentHomeValidator;
        private StudentRepository studentRepository;
        private StudentValidator studentValidator;

        public void SaveAllToXml()
        {
            employeeRepository.SaveAllToXml(Constants.EmployeeResourcePath);
            studentHomeRepository.SaveAllToXml(Constants.StudentHomeResourcePath);
            studentRepository.SaveAllToXml(Constants.StudentResourcePath);
        }

        public void AddEmployee(string CNP, string nume, string prenume, string post)
        {
            Employee employee = new Employee(CNP, nume, prenume, post);
            string errors = employeeValidator.Validate(employee);
            if (errors != string.Empty)
                throw new ValidationException(errors);
            employeeRepository.Save(employee);
        }

        public IList<Employee> GetAllEmployees()
        {
            IList<Employee> employees = new List<Employee>();
            Task getAll = Task.Factory.StartNew(() => employees = employeeRepository.FindAll());
            getAll.Wait();
            return employees;
        }

        public int CountEmployees()
        {
            return employeeRepository.Count();
        }

        public void AddStudentHome(string nume, int numarPersoaneInCamera, int numarCamere, int regie)
        {
            Domain.StudentHome studentHome = new Domain.StudentHome(nume, numarPersoaneInCamera, numarCamere, regie);
            string errors = studentHomeValidator.Validate(studentHome);
            if (errors != string.Empty)
                throw new ValidationException(errors);
            studentHomeRepository.Save(studentHome);
        }

        public IList<Domain.StudentHome> GetAllStudentHomes()
        {
            IList<Domain.StudentHome> studentHomes = new List<Domain.StudentHome>();
            Task getAll = Task.Factory.StartNew(() => studentHomes = studentHomeRepository.FindAll());
            getAll.Wait();
            return studentHomes;
        }

        public int CountStudentHomes()
        {
            return studentHomeRepository.Count();
        }

        public void AddStudent(string CNP, string nume, string prenume, double mediaAnuala)
        {
            Student student = new Student(CNP, nume, prenume, mediaAnuala);
            string errors = studentValidator.Validate(student);
            if (errors != string.Empty)
                throw new ValidationException(errors);
            studentRepository.Save(student);
        }

        public IList<Student> GetAllStudents()
        {
            IList<Student> students = new List<Student>();
            Task getAll = Task.Factory.StartNew(() => students = studentRepository.FindAll());
            getAll.Wait();
            return students;
        }

        public int CountStudents()
        {
            return studentRepository.Count();
        }

        public Page<Domain.StudentHome> GetStudentHomePage(Pageable pageable)
        {
            IList<Domain.StudentHome> studentHomes = GetAllStudentHomes();
            Page<Domain.StudentHome> page = new Page<Domain.StudentHome>();

            int pageSize = pageable.getPageSize();
            int pageNumber = pageable.getPageNumber();
            page.setPageNumber(pageNumber);
            page.setPageSize(pageSize);

            var orderedStudentHomes = studentHomes
                .OrderBy(studentHome => studentHome.Name);
            List<Domain.StudentHome> listed = orderedStudentHomes.ToList();

            int noOfElementsLeft = listed.Count - (pageNumber - 1)*pageSize;
            int noOfelementsToPut = Constants.PAGE_SIZE;
            if (noOfElementsLeft < noOfelementsToPut)
                noOfelementsToPut = noOfElementsLeft;

            List<Domain.StudentHome> paged = listed.GetRange((pageNumber - 1) * pageSize, noOfelementsToPut);
           
            page.setNoOfElements(paged.Count);
            page.setItems(paged);
            return page;
        }

        public Page<Student> GetStudentPage(Pageable pageable)
        {
            IList<Student> students = GetAllStudents();
            Page<Domain.Student> page = new Page<Domain.Student>();

            int pageSize = pageable.getPageSize();
            int pageNumber = pageable.getPageNumber();
            page.setPageNumber(pageNumber);
            page.setPageSize(pageSize);

            var orderedStudents = students
                .OrderBy(student => student.Name);
            List<Domain.Student> listed = orderedStudents.ToList();

            int noOfElementsLeft = listed.Count - (pageNumber - 1) * pageSize;
            int noOfelementsToPut = Constants.PAGE_SIZE;
            if (noOfElementsLeft < noOfelementsToPut)
                noOfelementsToPut = noOfElementsLeft;

            List<Domain.Student> paged = listed.GetRange((pageNumber - 1) * pageSize, noOfelementsToPut);

            page.setNoOfElements(paged.Count);
            page.setItems(paged);
            return page;
        }

        public Page<Employee> GetEmployeePage(Pageable pageable)
        {
            IList<Employee> employees = GetAllEmployees();
            Page<Domain.Employee> page = new Page<Domain.Employee>();
            int cix = employeeRepository.FindAll().Count;

            int pageSize = pageable.getPageSize();
            int pageNumber = pageable.getPageNumber();
            page.setPageNumber(pageNumber);
            page.setPageSize(pageSize);

            var orderedEmployees = employees
                .OrderBy(employee => employee.Name);
            List<Domain.Employee> listed = orderedEmployees.ToList();

            int noOfElementsLeft = listed.Count - (pageNumber - 1) * pageSize;
            int noOfelementsToPut = Constants.PAGE_SIZE;
            if (noOfElementsLeft < noOfelementsToPut)
                noOfelementsToPut = noOfElementsLeft;

            List<Domain.Employee> paged = listed.GetRange((pageNumber - 1) * pageSize, noOfelementsToPut);

            page.setNoOfElements(paged.Count);
            page.setItems(paged);
            return page;
        }
    }
}
