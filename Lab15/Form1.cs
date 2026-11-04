using Lab15.Presenters;
using Lab15.Repositories;
using Lab15.Views;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab15.Views
{
    public partial class Form1 : Form, IStudentView // Implements interface
    {
        private StudentPresenter presenter;

        public Form1()
        {
            InitializeComponent();
            // Khởi tạo Repository và Presenter
            IStudentRepository repository = new StudentRepository();
            presenter = new StudentPresenter(this, repository);

            // Gán sự kiện Click để gọi Presenter (không viết logic trực tiếp)[cite: 1]
            btnAdd.Click += delegate { presenter.AddStudent(); };
            btnDelete.Click += delegate { presenter.DeleteStudent(); };
            btnSearch.Click += delegate { presenter.SearchStudent(); };
            btnLoad.Click += delegate { presenter.LoadAllStudentList(); };
        }

        // Triển khai các property của IStudentView
        public string StudentId
        {
            get => txtId.Text;
            set => txtId.Text = value;
        }

        public string StudentName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        public string StudentScore
        {
            get => txtScore.Text;
            set => txtScore.Text = value;
        }

        public string SearchValue
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public void SetStudentList(BindingSource studentList)
        {
            dataGridView1.DataSource = studentList; // Form có DataGridView[cite: 1]
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}