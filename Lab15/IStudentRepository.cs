using Lab15.Models;
using System.Collections.Generic;

namespace Lab15.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        void Add(Student student);
        void Delete(string id);
        IEnumerable<Student> Search(string keyword);
        bool IsExist(string id);
    }
}