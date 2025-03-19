using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valeros.Solid.Demo
{
	public interface IStudentRepository
	{
		void AddStudent(Student student);
		void UpdateStudent(int id, Student student);
		void DeleteStudent(int id);
		Student GetStudent(int id);
		List<Student> GetAllStudents();
	}
}


