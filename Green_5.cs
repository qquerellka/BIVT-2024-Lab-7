using System;

namespace Lab_7
{
    public class Green_5
    {
        // Структура Student
        public struct Student
        {
            // Поля
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _examId;

            // Свойства
            public string Name => _name;
            public string Surname => _surname;
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
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) { return 0; }
                    double sum = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum / _marks.Length;
                }
            }

            // Конструкторы
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
                _examId = 0;
            }

            // Методы
            public void Exam(int mark)
            {
                if (_marks == null || _marks.Length == 0) return;
                if (mark < 2 || mark > 5) return;
                if (_examId >= _marks.Length) return;

                _marks[_examId] = mark;
                _examId++;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AvgMark:F2}");
            }
        }

        // Класс Group
        public class Group
        {
            // Поля
            private string _name;
            private Student[] _students;
            private int _studentCount;

            // Свойства
            public string Name => _name;
            public Student[] Students => _students;
            public virtual double AvgMark
            {
                get
                {
                    if (_students == null || _studentCount == 0) return 0;
                    double totalAvg = 0;
                    int validStudents = 0;
                    for (int i = 0; i < _studentCount; i++)
                    {
                        if (_students[i].AvgMark > 0)
                        {
                            totalAvg += _students[i].AvgMark;
                            validStudents++;
                        }
                    }
                    return validStudents == 0 ? 0 : totalAvg / validStudents; // тернарный оператор
                }
            }

            // Конструкторы
            public Group(string name)
            {
                _name = name;
                _students = new Student[0];
                _studentCount = 0;
            }

            // Методы
            public void Add(Student student)
            {
                if (_students == null)
                    _students = new Student[0];
                Array.Resize(ref _students, _studentCount + 1);
                _students[_studentCount] = student;
                _studentCount++;
            }

            public void Add(Student[] students)
            {
                if (students == null)
                    return;
                if (_students == null)
                    _students = new Student[0];

                int newLength = _studentCount + students.Length;
                Array.Resize(ref _students, newLength);
                for (int i = 0; i < students.Length; i++)
                {
                    _students[_studentCount + i] = students[i];
                }
                _studentCount = newLength;
            }

            public static void SortByAvgMark(Group[] groups)
            {
                for (int i = 0; i < groups.Length - 1; i++)
                {
                    for (int j = 0; j < groups.Length - 1 - i; j++)
                    {
                        if (groups[j].AvgMark < groups[j + 1].AvgMark)
                        {
                            (groups[j], groups[j + 1]) = (groups[j + 1], groups[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {AvgMark:F2}");
                for (int i = 0; i < _studentCount; i++)
                {
                    _students[i].Print();
                }
            }
        }

        // Класс EliteGroup
        public class EliteGroup : Group
        {
            // Конструктор
            public EliteGroup(string name) : base(name) { }

            // Переопределение свойства AvgMark
            public override double AvgMark
            {
                get
                {
                    if (Students == null || Students.Length == 0) return 0;

                    double totalWeightedSum = 0;
                    int validStudents = 0;

                    foreach (var student in Students)
                    {
                        if (student.Marks != null && student.Marks.Length > 0)
                        {
                            double studentWeightedSum = 0;
                            int validMarks = 0;

                            foreach (var mark in student.Marks)
                            {
                                if (mark >= 2 && mark <= 5)
                                {
                                    double weight = 0;
                                    switch (mark)
                                    {
                                        case 5: weight = 1.0; break;
                                        case 4: weight = 1.5; break;
                                        case 3: weight = 2.0; break;
                                        case 2: weight = 2.5; break;
                                    }
                                    studentWeightedSum += weight;
                                    validMarks++;
                                }
                            }

                            if (validMarks > 0)
                            {
                                totalWeightedSum += studentWeightedSum / validMarks;
                                validStudents++;
                            }
                        }
                    }

                    return validStudents == 0 ? 0 : totalWeightedSum / validStudents;
                }
            }
        }

        // Класс SpecialGroup
        public class SpecialGroup : Group
        {
            // Конструктор
            public SpecialGroup(string name) : base(name) { }

            // Переопределение свойства AvgMark
            public override double AvgMark
            {
                get
                {
                    if (Students == null || Students.Length == 0) return 0;

                    double totalWeightedSum = 0;
                    int validStudents = 0;

                    foreach (var student in Students)
                    {
                        if (student.Marks != null && student.Marks.Length > 0)
                        {
                            double studentWeightedSum = 0;
                            int validMarks = 0;

                            foreach (var mark in student.Marks)
                            {
                                if (mark >= 2 && mark <= 5)
                                {
                                    double weight = 0;
                                    switch (mark)
                                    {
                                        case 5: weight = 1.0; break;
                                        case 4: weight = 0.75; break;
                                        case 3: weight = 0.5; break;
                                        case 2: weight = 0.25; break;
                                    }
                                    studentWeightedSum += weight;
                                    validMarks++;
                                }
                            }

                            if (validMarks > 0)
                            {
                                totalWeightedSum += studentWeightedSum / validMarks;
                                validStudents++;
                            }
                        }
                    }

                    return validStudents == 0 ? 0 : totalWeightedSum / validStudents;
                }
            }
        }
    }
}