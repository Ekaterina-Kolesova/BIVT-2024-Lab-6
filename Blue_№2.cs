using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Blue_2
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private int[,] _marks; // 5 * 2
            private bool[] _isJumpMarked; // 2

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[,] Marks
            {
                get
                {
                    int[,] copy = new int[5, 2];
                    for(int i = 0; i < 5; i++)
                    {
                        for(int j = 0; j < 2; j++)
                            copy[i, j] = _marks[i, j];
                    }
                    return copy;
                }
            }
            public int TotalScore
            {
                get
                {
                    int totalScore = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 2; j++)
                            totalScore += _marks[i, j];
                    }
                    //Console.WriteLine($"{_name} {_surname}'s total score is {totalScore}");
                    return totalScore;
                }
            }

            //конструкторы
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5, 2];
                _isJumpMarked = new bool[2];
            }

            //методы
            
            public void Jump(int[] result)
            {
                if (result == null || result.Length != 5) return;

                int jumpNum = 0;
                while (_isJumpMarked[jumpNum] && jumpNum < _isJumpMarked.Length) // поиск неоценённого прыжка
                     jumpNum++;
                if (jumpNum >= _isJumpMarked.Length) // все прыжки оценены
                    return;

                for(int k = 0;k < 5; k++)
                    _marks[k, jumpNum] = result[k];
                _isJumpMarked[jumpNum] = true;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j + 1].TotalScore > array[j].TotalScore)
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
                Console.WriteLine($"{_name} {_surname}'s marks:");
                Console.WriteLine("             First Jump   Second Jump   Total Score");
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    Console.Write($"judge №{i + 1} ");
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        Console.Write($"{_marks[i, j], 12}");
                    }
                    int totalScore = TotalScore;
                    Console.WriteLine($"{TotalScore, 12}");
                }
            }
        }//struct Participant
    }
}
