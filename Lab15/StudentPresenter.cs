using Lab15.Models;
using Lab15.Repositories;
using Lab15.Views;
using System;
using System.Windows.Forms;

namespace Lab15.Presenters
{
    public class StudentPresenter
    {
        private readonly IStudentView view;
        private readonly IStudentRepository repository;
        private readonly BindingSource studentsBindingSource;

        public StudentPresenter(IStudentView view, IStudentRepository repository)
        {
            this.view = view;
            this.repository = repository;
            this.studentsBindingSource = new BindingSource();

            LoadAllStudentList();
        }

        public void LoadAllStudentList()
        {
            var students = repository.GetAll();
            studentsBindingSource.DataSource = students;
            view.SetStudentList(studentsBindingSource);
        }

        public void AddStudent()
        {
            if (string.IsNullOrWhiteSpace(view.StudentId) || string.IsNullOrWhiteSpace(view.StudentName) || string.IsNullOrWhiteSpace(view.StudentScore))
            {
                view.ShowMessage("Vui lòng nhập đầy đủ thông tin!"); // Kiểm tra rỗng
                return;
            }

            if (repository.IsExist(view.StudentId))
            {
                view.ShowMessage("Lỗi: Mã sinh viên đã tồn tại!"); // Kiểm tra trùng mã
                return;
            }

            if (!double.TryParse(view.StudentScore, out double score) || score < 0 || score > 10)
            {
                view.ShowMessage("Lỗi: Điểm phải là số thực từ 0 đến 10!"); // Kiểm tra sai kiểu
                return;
            }

            var student = new Student
            {
                Id = view.StudentId,
                Name = view.StudentName,
                Score = score
            };

            repository.Add(student);
            LoadAllStudentList();
            view.ShowMessage("Thêm sinh viên thành công!"); // Thông báo kết quả
        }

        public void DeleteStudent()
        {
            if (string.IsNullOrWhiteSpace(view.StudentId))
            {
                view.ShowMessage("Vui lòng chọn sinh viên cần xóa!");
                return;
            }

            repository.Delete(view.StudentId);
            LoadAllStudentList();
            view.ShowMessage("Xóa sinh viên thành công!"); // Thông báo kết quả
        }

        public void SearchStudent()
        {
            var keyword = view.SearchValue;
            var students = repository.Search(keyword);
            studentsBindingSource.DataSource = students;
            view.SetStudentList(studentsBindingSource);
        }
    }
}