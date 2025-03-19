using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valeros.Solid.Demo
{
	// Interface for CRUD operations (ISP - Interface Segregation Principle)
	public interface IStudentRepository
	{
		void AddStudent(Student student);
		void UpdateStudent(int id, Student student);
		void DeleteStudent(int id);
		Student GetStudent(int id);
		List<Student> GetAllStudents();
	}

	// Single Responsibility Principle (SRP) - Student class
	public class Student
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string Course { get; set; }
		public int YearLevel { get; set; }
	}

	// Open/Closed Principle (OCP) - Repository implementation can be extended
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

	// Dependency Inversion Principle (DIP) - Depend on abstractions
	class Program
	{
		static void Main()
		{
			IStudentRepository studentRepository = new StudentRepository();

			while (true)
			{
				Console.WriteLine("\n1. Add Student");
				Console.WriteLine("2. Update Student");
				Console.WriteLine("3. Delete Student");
				Console.WriteLine("4. View All Students");
				Console.WriteLine("5. Exit");
				Console.Write("Choose an option: ");
				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter ID: ");
						int id = int.Parse(Console.ReadLine());
						Console.Write("Enter First Name: ");
						string fn = Console.ReadLine();
						Console.Write("Enter Last Name: ");
						string ln = Console.ReadLine();
						Console.Write("Enter Middle Name: ");
						string mn = Console.ReadLine();
						Console.Write("Enter Course: ");
						string course = Console.ReadLine();
						Console.Write("Enter Year Level: ");
						int year = int.Parse(Console.ReadLine());

						studentRepository.AddStudent(new Student { Id = id, FirstName = fn, LastName = ln, MiddleName = mn, Course = course, YearLevel = year });
						break;

					case 2:
						Console.Write("Enter Student ID to update: ");
						int updateId = int.Parse(Console.ReadLine());
						Console.Write("Enter New First Name: ");
						string newFn = Console.ReadLine();
						Console.Write("Enter New Last Name: ");
						string newLn = Console.ReadLine();
						Console.Write("Enter New Middle Name: ");
						string newMn = Console.ReadLine();
						Console.Write("Enter New Course: ");
						string newCourse = Console.ReadLine();
						Console.Write("Enter New Year Level: ");
						int newYear = int.Parse(Console.ReadLine());

						studentRepository.UpdateStudent(updateId, new Student { FirstName = newFn, LastName = newLn, MiddleName = newMn, Course = newCourse, YearLevel = newYear });
						break;

					case 3:
						Console.Write("Enter Student ID to delete: ");
						int deleteId = int.Parse(Console.ReadLine());
						studentRepository.DeleteStudent(deleteId);
						break;

					case 4:
						Console.WriteLine("\nSTUDENT RECORDS");
						Console.WriteLine("\n---------------------------------------------------------------------------------");
						Console.WriteLine("| ID  | First Name     | Middle Name    | Last Name      | Course       | Year |");
						Console.WriteLine("---------------------------------------------------------------------------------");

						foreach (var student in studentRepository.GetAllStudents())
						{
							Console.WriteLine($"| {student.Id,-3} | {student.FirstName,-14} | {student.MiddleName,-14} | {student.LastName,-14} | {student.Course,-12} | {student.YearLevel,-4} |");
						}

						Console.WriteLine("---------------------------------------------------------------------------------");
						break;

					case 5:
						return;

					default:
						Console.WriteLine("Invalid choice. Try again.");
						break;
				}
			}
		}
	}
}

