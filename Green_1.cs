using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class Green_1
    {
        public abstract class Participant
        {
            // Поля
            private string? _surname;
            private string? _group;
            private string? _coachSurname;
            private double _result;
            protected double _standard;
            private static int _passedCount = 0;

            // Статический конструктор
            // static Participant()
            // {
            //     _standard = 100;
            //     _passedCount = 0;
            // }

            // Конструктор
            public Participant(string _surname, string _group, string _coachSurname)
            {
                this._surname = _surname is not null ? _surname : null;
                this._group = _group is not null ? _group : null;
                this._coachSurname = _coachSurname is not null ? _coachSurname : null;
                this._result = 0;
            }

            // Свойства
            public string? Surname => _surname is not null ? _surname : null;
            public string? Group => _group is not null ? _group : null;
            public string? Trainer => _coachSurname is not null ? _coachSurname : null;
            public double Result => _result;
            public static int? PassedTheStandard => _passedCount;
            public bool HasPassed => _result > 0 && _result <= _standard;

            // Методы
            public void Run(double result)
            {
                if (_result == 0)
                {
                    this._result = result;
                    if (result > 0 && result <= _standard)
                    {
                        _passedCount++;
                    }
                }
            }

            public static Participant[] GetTrainerParticipants(Participant[] participants, Type participantType, string trainer) {
                Participant[] tempResult = new Participant[participants.Length];
                int count = 0;

                for (int i = 0; i < participants.Length; i++)
                {
                    if (participants[i] != null && participants[i].GetType() == participantType && participants[i].Trainer == trainer)
                    {
                        tempResult[count] = participants[i];
                        count++;
                    }
                }

                Participant[] result = new Participant[count];
                Array.Copy(tempResult, result, count);

                return result;
            }

            public void Print() {}
        }

        public class Participant100M : Participant
        {
            public Participant100M(string surname, string group, string coachSurname) : base(surname, group, coachSurname)
            {
                _standard = 12; 
            }
        }

        public class Participant500M : Participant
        {
            public Participant500M(string surname, string group, string coachSurname) : base(surname, group, coachSurname)
            {
                _standard = 90;
            }
        }
    }
}