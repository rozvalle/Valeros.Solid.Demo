using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valeros.Solid.Demo
{
	public class StudentRepository : IStudentRepository
	{
		private readonly List<Student> _students = new List<Student>();

		public void AddStudent(Student student)
		{
			_students.Add(student);
		}

		public void UpdateStudent(int id, Student student)
		{
			var existingStudent = GetStudent(id);
			if (existingStudent != null)
			{
				existingStudent.FirstName = student.FirstName;
				existingStudent.LastName = student.LastName;
				existingStudent.MiddleName = student.MiddleName;
				existingStudent.Course = student.Course;
				existingStudent.YearLevel = student.YearLevel;
			}
		}

		public void DeleteStudent(int id)
		{
			_students.RemoveAll(s => s.Id == id);
		}

		public Student GetStudent(int id)
		{
			return _students.Find(s => s.Id == id);
		}

		public List<Student> GetAllStudents()
		{
			return _students;
		}
	}
}
