using System;
using System.Linq;

namespace Lab_7
{
    public class Green_4
    {
        // Структура Participant
        public struct Participant
        {
            // Поля
            private string _name;
            private string _surname;
            private double[] _jumps;

            // Свойства
            public string Name => _name;
            public string Surname => _surname;
            public double[] Jumps
            {
                get
                {
                    if (_jumps == null) return null;
                    double[] copy = new double[_jumps.Length];
                    Array.Copy(_jumps, copy, _jumps.Length);
                    return copy;
                }
            }
            public double BestJump
            {
                get
                {
                    if (_jumps == null || _jumps.Length == 0) return 0;
                    return _jumps.Max();
                }
            }

            // Конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _jumps = new double[3]; // Максимум 3 прыжка
            }

            // Методы
            public void Jump(double result)
            {
                if (_jumps == null) return;
                for (int i = 0; i < _jumps.Length; i++)
                {
                    if (_jumps[i] == 0)
                    {
                        _jumps[i] = result;
                        return;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {BestJump}");
            }
        }

        // Абстрактный класс Discipline
        public abstract class Discipline
        {
            // Поля
            private string _name;
            private Participant[] _participants;
            private int _participantCount;
            // Свойства
            public string Name => _name;
            public Participant[] Participants => _participants;

            // Конструктор
            public Discipline(string name)
            {
                _name = name;
                _participants = new Participant[0]; // Инициализация пустого массива
                _participantCount = 0;
            }

            // Методы
            public void Add(Participant participant)
            {
                if (_participants == null)
                {
                    _participants = new Participant[0];
                }
                Array.Resize(ref _participants, _participants.Length + 1);
                _participants[_participantCount] = participant;
                _participantCount++;
            }

            public void Add(Participant[] participants)
            {
                if (participants == null) return;
                foreach (var p in participants)
                {
                    Add(p);
                }
            }

            public void Sort()
            {
                Participant.Sort(_participants);
            }
            // Абстрактный метод для повторной попытки
            public abstract void Retry(int index);

            public void Print()
            {
                Console.WriteLine($"Дисциплина: {Name}");
                foreach (var participant in _participants)
                {
                    participant.Print();
                }
            }

            protected Participant GetParticipantAt(int index)
            {
                if (_participants != null && index >= 0 && index < _participantCount)
                {
                    return _participants[index];
                }
                return default(Participant);
            }

            protected void SetParticipant(int index, Participant participant)
            {
                if (_participants != null && index >= 0 && index < _participantCount)
                {
                    _participants[index] = participant;
                }
            }
        }

        // Класс LongJump
        public class LongJump : Discipline
        {
            // Конструктор
            public LongJump() : base("Long jump")
            {
            }

            // Переопределение метода Retry
            public override void Retry(int index)
            {
                Participant participant = GetParticipantAt(index);
                double bestJump = participant.BestJump;
                participant = new Participant(participant.Name, participant.Surname);

                participant.Jump(bestJump);// Сохраняем лучший прыжок
                SetParticipant(index, participant);

            }
        }

        // Класс HighJump
        public class HighJump : Discipline
        {
            // Конструктор
            public HighJump() : base("High jump")
            {
            }

            // Переопределение метода Retry
            public override void Retry(int index)
            {
                Participant participant = GetParticipantAt(index);
                double[] jumps = participant.Jumps;
                Participant new_Participant = new Participant(participant.Name, participant.Surname);
                if (jumps != null)
                {
                    for (int i = 0; i < jumps.Length - 1; i++)
                    {
                        new_Participant.Jump(jumps[i]);
                    }
                }
                SetParticipant(index, new_Participant);
            }
        }
    }
}