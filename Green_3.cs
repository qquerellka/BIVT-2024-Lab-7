using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_7
{
    public class Green_3
    {
        public class Student
        {
            //поля
            private string _name;
            private string _surname;
            private int[] _marks;
            private bool _isExpelled;
            private int _examCount;
            private int _id;
            private static int _nextId = 1;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int ID => _id;
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    if (_examCount == 0)
                    {
                        return false;
                    }
                    for (int i = 0; i < _examCount; i++)
                    {
                        if (_marks[i] <= 2)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;

                    double sum = 0;
                    int count = 0;
                    foreach (int mark in _marks)
                    {
                        if (mark != 0)
                        {
                            sum += mark;
                            count++;
                        }
                    }
                    if (count == 0) return 0;
                    return sum / count;
                }
            }

            //конструктор
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[3];
                _isExpelled = false;
                _examCount = 0;
                _id = _nextId++;
            }
            static Student()
            {
                _nextId = 1;
            }
            //методы
            public void Exam(int mark)
            {
                if (_marks == null || _marks.Length == 0) return;
                if (_examCount >= 3) return;
                if (_isExpelled) return;
                if (mark >= 2 && mark <= 5)
                    {
                        _marks[_examCount] = mark;
                        _examCount++;
                    }
                else
                    {
                        _marks[_examCount] = mark;
                        _examCount++;
                        _isExpelled = true;
                    }
                if (mark <= 2)
                {
                    _isExpelled = true;
                }
            }
            public void Restore()
            {
                _isExpelled = false;
            }
            public static void SortByAvgMark(Student [] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].AvgMark < array[j+1].AvgMark)
                        {
                            (array[j],array[j+1])=(array[j+1],array[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {Math.Round(AvgMark, 2)} {IsExpelled}");
            }
        }

        public class Commission
        {
            public static void Sort(Student[] students)
            {
                if (students == null) return;

                for (int i = 0; i < students.Length - 1; i++)
                {
                    for (int j = 0; j < students.Length - 1 - i; j++)
                    {
                        if (students[j].ID > students[j + 1].ID)
                        {
                            (students[j], students[j + 1]) = (students[j + 1], students[j]);
                        }
                    }
                }
            }
            public static Student[] Expel(ref Student[] students)
            {
                if (students == null) return new Student[0];

                int expelledCount = 0;
                foreach (var student in students)
                {
                    if (student.IsExpelled)
                    {
                        expelledCount++;
                    }
                }

                Student[] expelledStudents = new Student[expelledCount];
                Student[] activeStudents = new Student[students.Length - expelledCount];

                int expelledIndex = 0;
                int activeIndex = 0;

                foreach (var student in students)
                {
                    if (student.IsExpelled)
                    {
                        expelledStudents[expelledIndex++] = student;
                    }
                    else
                    {
                        activeStudents[activeIndex++] = student;
                    }
                }

                students = activeStudents;
                return expelledStudents;
            }
            public static void Restore(ref Student[] students, Student restored)
            {
                if (students == null || restored == null) return;

                bool found = false;
                foreach (var student in students)
                {
                    if (student.ID == restored.ID)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Студент не найден в списке.");
                    return;
                }

                foreach (var student in students)
                {
                    if (student.ID == restored.ID && !student.IsExpelled)
                    {
                        Console.WriteLine("Студент уже восстановлен.");
                        return;
                    }
                }

                restored.Restore();

                Student[] newStudents = new Student[students.Length + 1];
                Array.Copy(students, newStudents, students.Length);
                newStudents[students.Length] = restored;

                students = newStudents;
            }

        }
    }
}