namespace Lab6;
 // 3.1
//Результаты сессии содержат оценки 5 экзаменов по каждой группе.
//Определить средний балл для трех групп студентов одного потока и выдать список групп в порядке убывания среднего балла.

class Program
{
    static void Main(string[] args)
    {
        static Student[] deleteStudentWithBadMarks(Student[] array)
        {
            int length = array.Length;
            int index = 0;

            while (index < length)
            {
                if (array[index].minMark == 2)
                {
                    for (int i = index + 1; i < length; i++)
                    {
                        array[i - 1] = array[i];
                    }
                    length--;
                }
                else
                {
                    index++;
                }
                Array.Resize(ref array, length);
            }
            return array;
        }

        static Group[] sortedGroups(Group[] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = i + 1; j < groups.Length; j++)
                {
                    if (groups[i].averageMark < groups[j].averageMark)
                    {
                        (groups[i], groups[j]) = (groups[j], groups[i]);
                    }
                }
            }
            return groups;
        }

        Student[] students_19 = new Student[4];
        students_19[0] = new Student(1, new int[] { 2, 5, 5, 5, 5 });
        students_19[1] = new Student(2, new int[] { 2, 3, 4, 5, 4 });
        students_19[2] = new Student(3, new int[] { 3, 3, 3, 5, 3 });
        students_19[3] = new Student(4, new int[] { 2, 2, 3, 2, 3 });


        students_19 = deleteStudentWithBadMarks(students_19);

        Student[] students_20 = new Student[4];
        students_20[0] = new Student(1, new int[] { 3, 3, 4, 5, 5 });
        students_20[1] = new Student(2, new int[] { 2, 2, 4, 5, 4 });
        students_20[2] = new Student(3, new int[] { 5, 3, 4, 5, 5 });
        students_20[3] = new Student(4, new int[] { 5, 5, 5, 5, 3 });


        students_20 = deleteStudentWithBadMarks(students_20);

        Student[] students_21 = new Student[4];
        students_21[0] = new Student(1, new int[] { 5, 5, 5, 4, 4 });
        students_21[1] = new Student(2, new int[] { 3, 3, 4, 5, 4 });
        students_21[2] = new Student(3, new int[] { 5, 3, 4, 5, 3 });
        students_21[3] = new Student(4, new int[] { 2, 2, 4, 5, 3 });

        students_21 = deleteStudentWithBadMarks(students_21);


        Group[] groups = new Group[3];
        groups[0] = new Group("19", students_19);
        groups[1] = new Group("20", students_20);
        groups[2] = new Group("21", students_21);

        sortedGroups(groups);


        foreach (var group in groups) group.Print();
        Console.ReadKey();
    }

    struct Student
    {
        public int StudentId;
        public int[] marks;
        public int minMark = 5;
        public double averageMark { get; set; }
        public Student(int StudentId, int[] marks)
        {
            this.StudentId = StudentId;
            this.marks = marks;
            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] < minMark) { minMark = marks[i]; }
                averageMark += marks[i];
            } averageMark /= marks.Length;
        }
    }

    struct Group
    {
        public string groupName;
        public Student[] students;
        public double averageMark;
        public Group(string groupName, Student[] students)
        {
            this.groupName = groupName;
            this.students = students;
            foreach (var student in students) averageMark += student.averageMark;
            averageMark /= students.Length;

            for (int i = 0; i < students.Length; i++) {
                for (int j = i + 1; j < students.Length; j++) {
                    if (students[i].averageMark < students[j].averageMark) { (students[i], students[j]) = (students[j], students[i]); }
                }
            }
        }

        public void Print()
        {
            if (averageMark > 0)
            {
                Console.WriteLine($"BIVT_22_{groupName} {averageMark:F1}");
                foreach (Student student in students)
                {
                    Console.Write($"Студент {student.StudentId}  Ср.оценка – {student.averageMark:F1};");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"BIVT_22_{groupName}");
                Console.WriteLine("В этой группе все двоечники!");
                Console.WriteLine();
            }
        }
    }
}
