namespace ConsoleApp1
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Insturctor Instructor { get; set; }
        public string PrintDetails()
        {
            return $"CourseId: {CourseId}, Title:{Title}, Instructor: {Instructor.Name}";
        }

        public Course()
        {
            Instructor = new Insturctor();
            Instructor.Name = "Not Assigned";
        }
    }
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        private int _age;
        public int Age
        {
            get {  return _age; }
            set
            {
                if(value >= 15)
                {
                    _age= value;
                }
                else
                {
                    Console.WriteLine("Age must be at least 15");
                }

            }
                }
        public List<Course> Courses { get; set; }
        public Student()
        {
            Courses= new List<Course>();
        }
        public bool Enroll(Course newCourse)
        {
            Courses.Add(newCourse);
            return true;

        }
        public string PrintDetails()
        {
            return $"ID: {StudentId}, Name: {Name}, Age: {Age}, Enrolled in {Courses.Count} courses.";
        }
    }
    public class Insturctor
    {
        public int InsturctorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string PrintDetails() {
            return $"ID: {InsturctorId}, Name: {Name}, Specialization: {Specialization}.";
        }
    }
    public class StudentManager
    {
        public List<Student> Studnets {  get; set; }
        public List<Course> Courses { get; set; }
        public List<Insturctor> Instructors { get; set; }

        public bool AddStudent(Student student)
        {
            Studnets.Add(student);
            return true;
        }
        public bool AddCourse(Course course)
        {
            Courses.Add(course);
            return true;
        }
        public bool AddInstructor(Insturctor instructor)
        {
            Instructors.Add(instructor);
            return true;
        }
        public Student FindStudent(int studentId)
        {
            Student existingStudent;
            for (int i = 0; i < Studnets.Count; i++) {
                if (Studnets[i].StudentId == studentId)
                {
                    existingStudent = Studnets[i];
                    return existingStudent;
                }
                
            }
            existingStudent= new Student();
            existingStudent.StudentId = 0;
            existingStudent.Name = "no Student founded";
            existingStudent.Age = 0;
            existingStudent.Courses= new List<Course>();
            return existingStudent;
        }
        public Course FindCourse(int courseId)
        {
            Course existingCourse;
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId)
                {
                    existingCourse = Courses[i];
                    return existingCourse;
                }
            }
            existingCourse = new Course();
            existingCourse.CourseId = 0;
            existingCourse.Title = "no Course founded";
            return existingCourse;
        }
        public Insturctor FindInstructor(int instructorId)
        {
            Insturctor existingInstructor;
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InsturctorId == instructorId)
                {
                    existingInstructor = Instructors[i];
                    return existingInstructor;
                }
            }
            existingInstructor = new Insturctor();
            existingInstructor.InsturctorId = 0;
            existingInstructor.Name = "no Instructor founded";
            existingInstructor.Specialization = "None";
            return existingInstructor;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student.StudentId != 0 && course.CourseId != 0)
            {
                return student.Enroll(course);
            }
            return false;
        }
        public bool CheckStudentEnrolledInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            if (student.StudentId != 0)
            {
                for (int i = 0; i < student.Courses.Count; i++)
                {
                    if (student.Courses[i].CourseId == courseId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public string ReturnInstructorNameByCourseName(string courseName)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].Title == courseName)
                {
                    return Courses[i].Instructor.Name;
                }
            }
            return "Course not founded";
        }
    


        public StudentManager()
        {
            Studnets = new List<Student>();
            Courses = new List<Course>();
            Instructors = new List<Insturctor>();
        }

    }
        

    internal class Program
    {
        static void Main(string[] args)
            
        {
            StudentManager manager = new StudentManager();
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("\n=== Student Management System ===");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find the student by id");
                Console.WriteLine("9. Find the course by id");
                Console.WriteLine("10. Exit");
                Console.WriteLine("11. Check if student enrolled in specific course (Bonus)");
                Console.WriteLine("12. Return instructor name by course name (Bonus)");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Student ID: ");
                        int sId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Student Name: ");
                        string sName = Console.ReadLine();
                        Console.Write("Enter Student Age: ");
                        int sAge = int.Parse(Console.ReadLine());

                        Student newStudent = new Student { StudentId = sId, Name = sName, Age = sAge };
                        manager.AddStudent(newStudent);
                        Console.WriteLine("Student Added!");
                        break;

                    case "2":
                        Console.Write("Enter Instructor ID: ");
                        int iId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Instructor Name: ");
                        string iName = Console.ReadLine();
                        Console.Write("Enter Specialization: ");
                        string spec = Console.ReadLine();

                        Insturctor newInstructor = new Insturctor { InsturctorId = iId, Name = iName, Specialization = spec };
                        manager.AddInstructor(newInstructor);
                        Console.WriteLine("Instructor Added!");
                        break;

                    case "3":
                        Console.Write("Enter Course ID: ");
                        int cId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Course Title: ");
                        string cTitle = Console.ReadLine();
                        Console.Write("Enter Instructor ID for this course: ");
                        int instIdForCourse = int.Parse(Console.ReadLine());

                        Insturctor courseInstructor = manager.FindInstructor(instIdForCourse);
                        Course newCourse = new Course { CourseId = cId, Title = cTitle, Instructor = courseInstructor };
                        manager.AddCourse(newCourse);
                        Console.WriteLine("Course Added!");
                        break;

                    case "4":
                        Console.Write("Enter Student ID: ");
                        int enrollSId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Course ID: ");
                        int enrollCId = int.Parse(Console.ReadLine());

                        bool success = manager.EnrollStudentInCourse(enrollSId, enrollCId);
                        if (success)
                            Console.WriteLine("Enrolled Successfully!");
                        else
                            Console.WriteLine("Failed to enroll. Check Student ID or Course ID.");
                        break;

                    case "5":
                        Console.WriteLine("--- All Students ---");
                        for (int i = 0; i < manager.Studnets.Count; i++)
                        {
                            Console.WriteLine(manager.Studnets[i].PrintDetails());
                        }
                        break;

                    case "6":
                        Console.WriteLine("--- All Courses ---");
                        for (int i = 0; i < manager.Courses.Count; i++)
                        {
                            Console.WriteLine(manager.Courses[i].PrintDetails());
                        }
                        break;

                    case "7":
                        Console.WriteLine("--- All Instructors ---");
                        for (int i = 0; i < manager.Instructors.Count; i++)
                        {
                            Console.WriteLine(manager.Instructors[i].PrintDetails());
                        }
                        break;

                    case "8":
                        Console.Write("Enter Student ID to find: ");
                        int findSId = int.Parse(Console.ReadLine());
                        Student foundStudent = manager.FindStudent(findSId);
                        Console.WriteLine(foundStudent.PrintDetails());
                        break;

                    case "9":
                        Console.Write("Enter Course ID to find: ");
                        int findCId = int.Parse(Console.ReadLine());
                        Course foundCourse = manager.FindCourse(findCId);
                        Console.WriteLine(foundCourse.PrintDetails());
                        break;

                    case "10":
                        keepRunning = false;
                        break;

                    case "11":
                        Console.Write("Enter Student ID: ");
                        int checkSId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Course ID: ");
                        int checkCId = int.Parse(Console.ReadLine());
                        bool isEnrolled = manager.CheckStudentEnrolledInCourse(checkSId, checkCId);
                        Console.WriteLine(isEnrolled ? "Yes, Student is enrolled in this course." : "No, Student is NOT enrolled.");
                        break;

                    case "12":
                        Console.Write("Enter Course Name: ");
                        string searchCourseName = Console.ReadLine();
                        string instructorName = manager.ReturnInstructorNameByCourseName(searchCourseName);
                        Console.WriteLine($"Instructor: {instructorName}");
                        break;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
    }

