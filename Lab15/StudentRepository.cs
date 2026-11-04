using Lab15.Models;
using Lab15.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Lab15.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> studentList;

        public StudentRepository()
        {
            studentList = new List<Student>
            {
                new Student { Id = "SV01", Name = "Nguyen Van A", Score = 8.5 },
                new Student { Id = "SV02", Name = "Tran Thi B", Score = 7.0 }
            };
        }

        public IEnumerable<Student> GetAll() => studentList;

        public void Add(Student student) => studentList.Add(student);

        public void Delete(string id) => studentList.RemoveAll(s => s.Id == id);

        public IEnumerable<Student> Search(string keyword) =>
            studentList.Where(s => s.Name.Contains(keyword) || s.Id.Contains(keyword)).ToList();

        public bool IsExist(string id) => studentList.Any(s => s.Id == id);
    }
}