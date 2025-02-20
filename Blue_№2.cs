using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private int[,] _marks; // 5 * 2 => 2 * 5
            private bool[] _isJumpMarked; // 2

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[,] Marks // changed
            {
                get
                {
                    if (_marks == null) return null;

                    int[,] copy = new int[2, 5];
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                            copy[i, j] = _marks[i, j];
                    }
                    return copy;
                }
            }
            public int TotalScore // changed
            {
                get
                {
                    if (_marks == null) return 0;

                    int totalScore = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
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
                _marks = new int[2, 5]; //changed
                _isJumpMarked = new bool[2];
            }

            //методы

            public void Jump(int[] result)
            {
                if (result == null) return; 
                if (_marks == null || _isJumpMarked == null) return;

                int jumpNum = 0;
                while (_isJumpMarked[jumpNum] && jumpNum < _isJumpMarked.Length) // поиск неоценённого прыжка
                    jumpNum++;
                if (jumpNum >= _isJumpMarked.Length) // все прыжки оценены
                    return;

                for (int k = 0; k < 5; k++)
                    _marks[jumpNum, k] = result[k]; // changed
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
                Console.Write("             First Jump   Second Jump   Total Score");
                for (int i = 0; i < _marks.GetLength(1); i++)
                {
                    Console.WriteLine();
                    Console.Write($"judge №{i + 1} ");
                    for (int j = 0; j < _marks.GetLength(0); j++)
                    {
                        Console.Write($"{_marks[j, i],12}");
                    }
                }
                int totalScore = TotalScore;
                Console.WriteLine($"{TotalScore,12}");
            }
        }//struct Participant
    }
}
