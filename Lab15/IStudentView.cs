using System.Windows.Forms;

namespace Lab15.Views
{
    public interface IStudentView
    {
        string StudentId { get; set; }
        string StudentName { get; set; }
        string StudentScore { get; set; }
        string SearchValue { get; set; }

        void SetStudentList(BindingSource studentList);
        void ShowMessage(string message);
    }
}