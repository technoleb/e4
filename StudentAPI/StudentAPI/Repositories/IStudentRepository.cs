using StudentAPI.Common;
using StudentAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.Repositories
{
    public interface IStudentRepository
    {
        APIResponse GetStudent();
        APIResponse GetStudent(int Id);
        APIResponse SaveStudent(Student obj);
        APIResponse DeleteStudent(int Id);
    }
}