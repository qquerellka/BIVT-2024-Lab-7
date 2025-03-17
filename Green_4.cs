using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Intrinsics.Arm;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7 {
  public class Green_4 {
    public struct Participant {
      // Поля
      private string? _name;
      private string? _surname;
      private double[]? _jumps;
      private const int _jumpsCount = 3;

      // Свойства
      public string? Name => _name is not null ? _name : null;
      public string? Surname => _surname is not null ? _surname : null;
      public double[] Jumps => (double[])_jumps.Clone();
      // public double[] Jumps => _jumps is not null ? _jumps : new double[_jumpsCount];

      // public double BestJump => _jumps is not null ? _jumps.Max() : 0;
      public double BestJump => _jumps != null && _jumps.Length > 0 ? _jumps.Max() : 0;


      // Конструктор
      public Participant(string name, string surname) {
        this._name = name is not null ? name :  null;
        this._surname = surname is not null ? surname : null;
        this._jumps = new double[_jumpsCount];
      }

      // Методы
      public void Jump(double result) {
        if (result <= 0) {
          return;
        }
        if (_jumps == null) {
          Console.WriteLine("Массив прыжков не инициализирован");
          return;
          // _jumps = new double[_jumpsCount];
        }
        for (int i = 0; i < _jumpsCount; i++) {
          if (_jumps[i] == 0) {
            _jumps[i] = result;
            return;
          }
        }
      }

      public static void Sort(Participant[] array) {
        if (array == null) {
          return;
        }
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                // Сравниваем средние баллы групп
                if (array[j].BestJump < array[j + 1].BestJump)
                {
                    // Меняем местами группы
                    Participant temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }      
      }

      public void Print() { }

    }

    public abstract class Discipline
    {
        // Поля 
        private string? _name;
        private Participant[] _participants;
        private int _participantCount;

        // Свойства
        public string? Name => _name is not null ? _name : null;
        public Participant[] Participants => _participants;
        public int ParticipantCount => _participantCount;

        // Конструктор
        protected Discipline(string name) 
        {
          this._name = name is not null ? name : null;
          this._participants = new Participant[0];
          this._participantCount = 0;
        }

        // Методы
        public void Add(Participant participant)
        {
            if (_participantCount == _participants.Length)
            {
                Participant[] newParticipants = new Participant[_participantCount == 0 ? 1 : _participants.Length * 2];
                Array.Copy(_participants, newParticipants, _participants.Length);
                _participants = newParticipants;
            }
            
            _participants[_participantCount++] = participant;
        }
        public void Add(Participant[] participants) {
          foreach (Participant participant in participants)
          {
            Add(participant);
          }
        }
        public void Sort()
        {
          Participant.Sort(_participants);
        }
        public abstract void Retry(int index);
    }

    public class LongJump : Discipline {
      public LongJump() : base("Long jump") { }

      public override void Retry(int index)
      {
        if (index < 0 || index >= ParticipantCount)
        {
            Console.WriteLine("Некорректный индекс участника.");
            return;
        }

        if (index < 0 || index >= Participants.Length)

        // if (index < 0 || index >= _participantCount)

        {
            Console.WriteLine("Некорректный индекс участника.");
            return;
        }

        Participant participant = Participants[index];
        double bestJump = participant.BestJump;
        participant = new Participant(participant.Name, participant.Surname);
        participant.Jump(bestJump);
        participant.Jump(0);
        participant.Jump(0);
        Participants[index] = participant;
      }
    }

    public class HighJump : Discipline {
      public HighJump() : base("High jump") { }

      public override void Retry(int index)
      {
        if (index < 0 || index >= ParticipantCount)
        {
            Console.WriteLine("Некорректный индекс участника.");
            return;
        }
        if (index < 0 || index >= Participants.Length)
        {
            Console.WriteLine("Некорректный индекс участника.");
            return;
        }

        Participant participant = Participants[index];

        if (participant.Jumps != null && participant.Jumps.Length > 0)
        {
            participant.Jumps[participant.Jumps.Length - 1] = 0;
        }
      }
    }
  }
}