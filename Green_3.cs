using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7  {
  public class Green_3 {
    public class Student {
      // Поля
      private string? _name;
      private string? _surname;
      private int[] _marks;
      private bool _isExpelled;
      private const int _examsCount = 3;
      private static int _nextStudentId = 1; 
      private int _studentId;

      // Свойства
      public string? Name => _name is not null ? _name : null;
      public string? Surname => _surname is not null ? _surname : null;
      public int[] Marks => (int[])_marks.Clone(); 

      public double AvgMark => _marks.Any(m => m != 0) ? _marks.Where(m => m != 0).Average() : 0;
      public int ID => _studentId;
      public bool IsExpelled => _isExpelled;

      // Статический конструктор
      static Student()
      {
        _nextStudentId = 1; 
      }

      // Конструктор
      public Student(string name, string surname) {
        this._name = name is not null ? name :  null;
        this._surname = surname is not null ? surname : null;
        this._marks = new int[_examsCount];
        // for (int i = 0; i < _examsCount; i++) {
        //   _marks[i] = 0;
        // }
        this._isExpelled = false;
        this._studentId = _nextStudentId++;
      }

      // Методы
      public void Restore() {
        _isExpelled = false;
      }
      // public void Exam(int mark) {
      //   if (_isExpelled) {
      //     return;
      //   }
      //   if (mark < 2 || mark > 5) {
      //     Console.WriteLine("Оценка должна быть от 2 до 5");
      //     return;
      //   }
      //   if (Marks == null) {
      //     Console.WriteLine("Массив оценок не инициализирован");
      //      return;
      //   }
      //   for (int i = 0; i < _examsCount; i++) {
      //     if (Marks[i] == 0) {
      //       if (mark == 2) {
      //         _isExpelled = true;
      //       }
      //       Marks[i] = mark;
      //       return;
      //     }
      //   }
      // }

      public void Exam(int mark) {
        if (mark < 2 || mark > 5) {
          Console.WriteLine("Оценка должна быть от 2 до 5");
          return;
        }
        if (_marks == null) {
          Console.WriteLine("Массив оценок не инициализирован");
          return;
        }

        for (int i = 0; i < _examsCount; i++) {
          if (_marks[i] == 0) {
            _marks[i] = mark;
            return;
          }
        }
      }
      public static void SortByAvgMark(Student[] array) {
        if (array == null) {
          Console.WriteLine("Массив студентов не инициализирован");
          return;
        }
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                // Сравниваем средние баллы групп
                if (array[j].AvgMark < array[j + 1].AvgMark)
                {
                    // Меняем местами группы
                    Student temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
      }

      public void Print() { }

    }


    public class Commission() {
      public static void Sort(Student[] students) {
        if (students == null) {
          Console.WriteLine("Массив студентов не инициализирован");
          return;
        }
        int n = students.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                // Сравниваем средние баллы групп
                if (students[j].ID > students[j + 1].ID)
                {
                    // Меняем местами группы
                    Student temp = students[j];
                    students[j] = students[j + 1];
                    students[j + 1] = temp;
                }
            }
        }
      }


      public static Student[] Expel(ref Student[] students) {
        if (students == null) {
          Console.WriteLine("Массив студентов не инициализирован");
          return [];
        }

        int expelledCount = 0;
        foreach (Student student in students) {
          if (student.IsExpelled) {
            expelledCount++;
          }
        }
        Student[] expelledStudents = new Student[expelledCount];
        Student[] remainingStudents = new Student[students.Length - expelledCount];

        int expelledIndex = 0;
        int remainingIndex = 0;

        foreach (Student student in students) {
          if (student.IsExpelled)
          {
              expelledStudents[expelledIndex++] = student;
          }
          else
          {
              remainingStudents[remainingIndex++] = student;
          }
        }

        students = remainingStudents;
        return expelledStudents;
      }


      public static void Restore(ref Student[] students, Student restored) {
        // if (students == null || restored == null) {
        //   Console.WriteLine("Массив студентов не инициализирован");
        //   return;
        // }

        // bool studentExist = false;
        // for (int i = 0; i < students.Length; i++) {
        //   if (students[i].ID == restored.ID) {
        //     studentExist = true;
        //     break;
        //   }
        // }

        // if (!studentExist) {
        //   return;
        // }

        // bool isAlreadyRestored = false;
        // for (int i = 0; i < students.Length; i++)
        // {
        //   if (students[i].ID == restored.ID && !students[i].IsExpelled)
        //   {
        //     isAlreadyRestored = true;
        //     break;
        //   }
        // }

        // if (isAlreadyRestored)
        // {
        //   return;
        // }

        // Student[] updatedStudents = new Student[students.Length + 1];
        // int index = 0;

        // for (int i = 0; i < students.Length; i++)
        // {
        //   updatedStudents[index++] = students[i];
        // }

        // updatedStudents[index] = restored;
        // students = updatedStudents;
        if (students == null || restored == null)
        {
            Console.WriteLine("Ошибка: массив студентов не инициализирован.");
            return;
        }

        bool wasInOriginalList = students.Any(s => s.ID == restored.ID);
        if (!wasInOriginalList)
        {
            Console.WriteLine("Ошибка: нельзя восстановить студента, которого не было в списке.");
            return;
        }

        if (students.Any(s => s.ID == restored.ID && !s.IsExpelled))
        {
            Console.WriteLine("Ошибка: студент уже восстановлен.");
            return;
        }

        students = students.Append(restored).ToArray();
        
        Sort(students);
      }

      public void Print() { }
    } 
  }
}