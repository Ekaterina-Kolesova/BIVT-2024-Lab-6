using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private int[] _penaltyTimes; //
            private int _playedMatchesNum;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltyTimes == null) return null;

                    int[] copy = new int[_penaltyTimes.Length];
                    for (int k = 0; k < copy.Length; k++)
                        copy[k] = _penaltyTimes[k];
                    return copy;
                }
            }
            public int TotalTime
            {
                get
                {
                    if (_penaltyTimes == null) return 0;

                    int totalTime = 0;
                    for (int k = 0; k < _penaltyTimes.Length; k++) //!!!
                        totalTime += _penaltyTimes[k];
                    return totalTime;
                }
            }
            public bool IsExpelled
            {
                get
                {

                    for (int k = 0; k < _penaltyTimes.Length; k++)
                    {
                        if (_penaltyTimes[k] == 10)
                            return true;
                    }
                    return false;
                }
            }

            //конструкторы
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTimes = new int[0];
                _playedMatchesNum = 0;
            }

            //методы
            private void IncreaseCapasity()
            {
                if (_penaltyTimes == null || _penaltyTimes.Length == 0)
                {
                    _penaltyTimes = new int[1];
                    return;
                }

                int[] tmp = new int[_penaltyTimes.Length + 1];
                int k = 0;
                foreach (int time in _penaltyTimes)
                    tmp[k++] = time;
                _penaltyTimes = tmp;
            }

            public void PlayMatch(int time)
            {
                if (_penaltyTimes == null) return;

                if (_playedMatchesNum >= _penaltyTimes.Length)
                    IncreaseCapasity();

                _penaltyTimes[_playedMatchesNum] = time;
                _playedMatchesNum++;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j + 1].TotalTime < array[j].TotalTime)
                        {
                            Participant tmp = array[j + 1];
                            array[j + 1] = array[j];
                            array[j] = tmp;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}'s penalty time:");
                for (int k = 0; k < _penaltyTimes.Length; k++)
                    Console.Write($"{_penaltyTimes[k],4}");
                Console.WriteLine();
                Console.WriteLine($"Total time - {TotalTime}");
            }

        }//struct Participant
    }
}
