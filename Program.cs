using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Green_1:");
            Green_1.Participant participant1 = new Green_1.Participant100M("Степанова", "Спартак", "Зайцев");
            participant1.Run(41.94);
            Console.WriteLine($"{participant1.Surname} {participant1.Group} {participant1.Trainer} {participant1.Result} {participant1.HasPassed}");

            Green_1.Participant participant2 = new Green_1.Participant100M("Кристиан", "Русь", "Жарков");
            participant2.Run(55.29);
            Console.WriteLine($"{participant2.Surname} {participant2.Group} {participant2.Trainer} {participant2.Result} {participant2.HasPassed}");

            Green_1.Participant participant3 = new Green_1.Participant100M("Чехова", "Юность", "Свиридов");
            participant3.Run(72.01);
            Console.WriteLine($"{participant3.Surname} {participant3.Group} {participant3.Trainer} {participant3.Result} {participant3.HasPassed}");

            Green_1.Participant participant4 = new Green_1.Participant100M("Зайцева", "Быки", "Свиридов");
            participant4.Run(140.78);
            Console.WriteLine($"{participant4.Surname} {participant4.Group} {participant4.Trainer} {participant4.Result} {participant4.HasPassed}");

            Green_1.Participant participant5 = new Green_1.Participant100M("Смирнова", "Русь", "Павлов");
            participant5.Run(95.45);
            Console.WriteLine($"{participant5.Surname} {participant5.Group} {participant5.Trainer} {participant5.Result} {participant5.HasPassed}");

            Green_1.Participant participant6 = new Green_1.Participant500M("Кристиан", "Химик", "Распутин");
            participant6.Run(79.63);
            Console.WriteLine($"{participant6.Surname} {participant6.Group} {participant6.Trainer} {participant6.Result} {participant6.HasPassed}");

            Green_1.Participant participant7 = new Green_1.Participant500M("Иванова", "Байкал", "Иванов");
            participant7.Run(29.67);
            Console.WriteLine($"{participant7.Surname} {participant7.Group} {participant7.Trainer} {participant7.Result} {participant7.HasPassed}");

            Green_1.Participant participant8 = new Green_1.Participant500M("Жаркова", "Югра", "Жарков");
            participant8.Run(18.41);
            Console.WriteLine($"{participant8.Surname} {participant8.Group} {participant8.Trainer} {participant8.Result} {participant8.HasPassed}");

            Green_1.Participant participant9 = new Green_1.Participant500M("Чехова", "Метеор", "Тихонов");
            participant9.Run(140.87);
            Console.WriteLine($"{participant9.Surname} {participant9.Group} {participant9.Trainer} {participant9.Result} {participant9.HasPassed}");

            Green_1.Participant participant10 = new Green_1.Participant500M("Степанова", "Энергия", "Свиридов");
            participant10.Run(75.52);
            Console.WriteLine($"{participant10.Surname} {participant10.Group} {participant10.Trainer} {participant10.Result} {participant10.HasPassed}");


            Console.WriteLine($"Количество прошедших норматив: {Green_1.Participant.PassedTheStandard}");
            Console.WriteLine();


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

             Console.WriteLine("Green_2:");

            // Создаем массив студентов
            Green_2.Student[] students =
            {
                new Green_2.Student("Лев", "Петров"),
                new Green_2.Student("Алевтина", "Козлова"),
                new Green_2.Student("Полина", "Смирнова"),
                new Green_2.Student("Иван", "Смирнов"),
                new Green_2.Student("Алиса", "Смирнова"),
                new Green_2.Student("Юрий", "Чехов"),
                new Green_2.Student("Степан", "Кристиан"),
                new Green_2.Student("Анаставия", "Полевая"),
                new Green_2.Student("Никита", "Зайцев"),
                new Green_2.Student("Оксана", "Лисицына")
            };

            // Добавляем оценки студентам
            students[0].Exam(3);
            students[0].Exam(4);
            students[0].Exam(4);
            students[0].Exam(4);

            students[1].Exam(5);
            students[1].Exam(3);
            students[1].Exam(4);
            students[1].Exam(2);

            students[2].Exam(5);
            students[2].Exam(4);
            students[2].Exam(2);
            students[2].Exam(5);

            students[3].Exam(4);
            students[3].Exam(5);
            students[3].Exam(4);
            students[3].Exam(5);

            students[4].Exam(4);
            students[4].Exam(3);
            students[4].Exam(5);
            students[4].Exam(4);

            students[5].Exam(3);
            students[5].Exam(4);
            students[5].Exam(3);
            students[5].Exam(4);

            students[6].Exam(5);
            students[6].Exam(5);
            students[6].Exam(5);
            students[6].Exam(3);

            students[7].Exam(4);
            students[7].Exam(3);
            students[7].Exam(4);
            students[7].Exam(4);

            students[8].Exam(5);
            students[8].Exam(5);
            students[8].Exam(2);
            students[8].Exam(3);

            students[9].Exam(4);
            students[9].Exam(5);
            students[9].Exam(5);
            students[9].Exam(5);

            // Сортируем студентов по среднему баллу
            Green_2.Student.SortByAvgMark(students);

            // Выводим отсортированных студентов
            Console.WriteLine("Студенты, отсортированные по убыванию среднего балла:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} {student.Surname} {student.AvgMark} {student.IsExcellent}");
            }

            // Выводим общее количество отличников
Console.WriteLine($"Общее количество отличников: {Green_2.Student.ExcellentAmount}");

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////      

            Console.WriteLine("Green_3:");
            Green_3.Student[] students2 =
            {
                new Green_3.Student("Ярослав", "Козлов"),
                new Green_3.Student("Сергей", "Свиридов"),
                new Green_3.Student("Екатерина", "Батова"),
                new Green_3.Student("Николай", "Луговой"),
                new Green_3.Student("Ирина", "Кристиан"),
                new Green_3.Student("Полина", "Зайцева"),
                new Green_3.Student("Мирослав", "Степанов"),
                new Green_3.Student("Игорь", "Чехов"),
                new Green_3.Student("Александра", "Павлова"),
                new Green_3.Student("Максим", "Свиридов"),


            };
            students2[0].Exam(4);
            students2[0].Exam(3);
            students2[0].Exam(4);

            students2[1].Exam(4);
            students2[1].Exam(4);
            students2[1].Exam(3);

            students2[2].Exam(3);
            students2[2].Exam(2);
            students2[2].Exam(0);

            students2[3].Exam(4);
            students2[3].Exam(3);
            students2[3].Exam(3);

            students2[4].Exam(5);
            students2[4].Exam(4);
            students2[4].Exam(5);

            students2[5].Exam(4);
            students2[5].Exam(4);
            students2[5].Exam(3);

            students2[6].Exam(3);
            students2[6].Exam(4);
            students2[6].Exam(4);

            students2[7].Exam(4);
            students2[7].Exam(4);
            students2[7].Exam(2);

            students2[8].Exam(3);
            students2[8].Exam(4);
            students2[8].Exam(5);

            students2[9].Exam(3);
            students2[9].Exam(3);
            students2[9].Exam(4);

            Green_3.Student.SortByAvgMark(students2);

            foreach (var student in students2)
            {
                Console.WriteLine($"{student.Name} {student.Surname} {student.AvgMark} {student.IsExpelled}");
            }
            Console.WriteLine();

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Green_4");
            Green_4.Participant[] participants2 =
            {
                new Green_4.Participant("Анастасия", "Свиридова"),
                new Green_4.Participant("Кристина", "Батова"),
                new Green_4.Participant("Мирослав", "Пономарев"),
                new Green_4.Participant("Виктор", "Распутин"),
                new Green_4.Participant("Алевтина", "Свиридова"),
                new Green_4.Participant("Савелий", "Распутин"),
                new Green_4.Participant("Светлана", "Смирнова"),
                new Green_4.Participant("Оксана", "Зайцева"),
                new Green_4.Participant("Юлия", "Луговая"),
                new Green_4.Participant("Савелий", "Сверидов")
            };

            // Анастасия Свиридова
            participants2[0].Jump(4.92);
            participants2[0].Jump(0.08);
            participants2[0].Jump(9.10);

            // Кристина Батова
            participants2[1].Jump(1.02);
            participants2[1].Jump(9.58);
            participants2[1].Jump(9.25);

            // Мирослав Пономарев
            participants2[2].Jump(2.27);
            participants2[2].Jump(8.03);
            participants2[2].Jump(4.15);

            // Виктор Распутин
            participants2[3].Jump(3.44);
            participants2[3].Jump(7.85);
            participants2[3].Jump(4.07);

            // Алевтина Свиридова
            participants2[4].Jump(2.12);
            participants2[4].Jump(4.64);
            participants2[4].Jump(5.46);

            // Савелий Распутин
            participants2[5].Jump(6.08);
            participants2[5].Jump(7.73);
            participants2[5].Jump(8.41);

            // Светлана Смирнова
            participants2[6].Jump(9.14);
            participants2[6].Jump(6.22);
            participants2[6].Jump(5.43);

            // Оксана Зайцева
            participants2[7].Jump(9.03);
            participants2[7].Jump(7.71);
            participants2[7].Jump(2.65);

            // Юлия Луговая
            participants2[8].Jump(8.66);
            participants2[8].Jump(9.53);
            participants2[8].Jump(2.59);

            // Савелий Свиридов
            participants2[9].Jump(1.04);
            participants2[9].Jump(1.20);
            participants2[9].Jump(1.07);

            Green_4.Participant.Sort(participants2);

            foreach (var participant in participants2)
            {
                Console.WriteLine($"{participant.Name} {participant.Surname} {participant.BestJump}");
            }
            Console.WriteLine();

/////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Green_5");
            Green_5.Group bntm = new Green_5.Group("БНТМ");
            Green_5.Group bek = new Green_5.Group("БЭК");
            Green_5.Group bpm = new Green_5.Group("БПМ");

            // Студенты БНТМ
            Green_5.Student[] bntmStudents =
            {
                new Green_5.Student("Дарья", "Павлова"),
                new Green_5.Student("Светлана", "Жаркова"),
                new Green_5.Student("Игорь", "Пономарев"),
                new Green_5.Student("Максим", "Кристиан"),
                new Green_5.Student("Григорий", "Козлов"),
                new Green_5.Student("Игорь", "Зайцев"),
                new Green_5.Student("Полина", "Павлова"),
                new Green_5.Student("Савелий", "Павлов"),
                new Green_5.Student("Иван", "Козлов"),
                new Green_5.Student("Инна", "Батова")
            };
            int[][] bntmMarks =
            {
                new [] {3, 3, 5, 4, 3}, new [] {4, 4, 4, 3, 4}, new [] {5, 3, 4, 4, 4}, new [] {4, 4, 5, 5, 3},
                new [] {4, 5, 2, 5, 5}, new [] {2, 5, 5, 3, 4}, new [] {5, 4, 3, 4, 3}, new [] {3, 3, 4, 4, 3},
                new [] {5, 5, 4, 3, 3}, new [] {5, 3, 3, 5, 3}
            };
            for (int i = 0; i < bntmStudents.Length; i++)
            {
                foreach (var mark in bntmMarks[i]) {
                    bntmStudents[i].Exam(mark);
                }
                bntm.Add(bntmStudents[i]);
            }

            // Студенты БЭК
            Green_5.Student[] bekStudents =
            {
                new Green_5.Student("Татьяна", "Лисицына"), new Green_5.Student("Анастасия", "Лисицына"), new Green_5.Student("Виктор", "Полевой"),
                new Green_5.Student("Алевтина", "Батова"), new Green_5.Student("Лев", "Жарков"), new Green_5.Student("Лев", "Чехов"),
                new Green_5.Student("Юрий", "Зайцев"), new Green_5.Student("Марк", "Петров"), new Green_5.Student("Александра", "Чехова"),
                new Green_5.Student("Анастасия", "Батова")
            };
            int[][] bekMarks =
            {
                new [] {3, 3, 4, 2, 3}, new [] {3, 2, 5, 5, 3}, new [] {2, 4, 4, 5, 2},
                new [] {3, 3, 5, 5, 3}, new [] {5, 2, 3, 4, 4}, new [] {3, 4, 2, 4, 4},
                new [] {4, 3, 3, 4, 3}, new [] {5, 5, 4, 3, 3}, new [] {5, 4, 3, 3, 5},
                new [] {3, 5, 5, 3, 5}
            };

            for (int i = 0; i < bekStudents.Length; i++)
            {
                foreach (var mark in bekMarks[i])
                    bekStudents[i].Exam(mark);
                bek.Add(bekStudents[i]);
            }

            // Аналогично для группы БПМ
            Green_5.Student[] bpmStudents =
            {
                new Green_5.Student("Оксана", "Зайцева"), new Green_5.Student("Юрий", "Пономарев"), new Green_5.Student("Юрий", "Тихонов"),
                new Green_5.Student("Степан", "Зайцев"), new Green_5.Student("Марина", "Смирнова"), new Green_5.Student("Светлана", "Кристиан"),
                new Green_5.Student("Алевтина", "Жаркова"), new Green_5.Student("Инна", "Смирнова"), new Green_5.Student("Алиса", "Сидорова"),
                new Green_5.Student("Татьяна", "Чехова")
            };
            int[][] bpmMarks =
            {
                new [] {3, 4, 3, 3, 3}, new [] {5, 2, 5, 4, 2}, new [] {4, 4, 4, 3, 5},
                new [] {4, 3, 3, 4, 4}, new [] {3, 2, 3, 4, 5}, new [] {5, 3, 2, 4, 2},
                new [] {5, 5, 3, 3, 3}, new [] {3, 5, 4, 3, 3}, new [] {4, 3, 4, 2, 3},
                new [] {4, 4, 5, 3, 5}
            };
            
            for (int i = 0; i < bpmStudents.Length; i++)
            {
                foreach (var mark in bpmMarks[i])
                    bpmStudents[i].Exam(mark);
                bpm.Add(bpmStudents[i]);
            }

            Console.WriteLine($"БНТМ: {bntm.AvgMark}");
            Console.WriteLine($"БЭК: {bek.AvgMark}");
            Console.WriteLine($"БПМ: {bpm.AvgMark}");
        }
    }
}
