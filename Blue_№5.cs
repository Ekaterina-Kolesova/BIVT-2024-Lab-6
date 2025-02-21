using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman
        {
            //поля
            private string _name;
            private string _surname;
            private int _place;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            //конструкторы
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }
            //методы
            public void SetPlace(int place)
            {
                if (_place > 0 || place < 1) return; //если место уже есть или передано некорректное место
                _place = place;
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} is on the {_place} place");
            }
        }//struct Sportsman

        public struct Team
        {
            //поля
            private string _name;
            private Sportsman[] _sportsmen; //6
            private int _sportsmenNum;

            //свойства
            public string Name => _name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    if (_sportsmen == null) return null;

                    Sportsman[] copy = new Sportsman[_sportsmen.Length];
                    for (int k = 0; k < copy.Length; k++)
                        copy[k] = _sportsmen[k];
                    return copy;
                }
            }
            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null) return 0;

                    int sum = 0;
                    for (int k = 0; k < _sportsmenNum; k++)
                    {
                        int score = 6 - _sportsmen[k].Place;
                        if (score < 0) score = 0;
                        sum += score;
                    }
                    return sum;
                }
            }
            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null) return 0;

                    int top = _sportsmen[0].Place;
                    for (int k = 1; k < _sportsmenNum; k++)
                    {
                        if (_sportsmen[k].Place < top)
                            top = _sportsmen[k].Place;
                    }
                    return top;
                }
            }

            //конструкторы
            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _sportsmenNum = 0;
            }

            //методы
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null || _sportsmenNum >= _sportsmen.Length) return;

                _sportsmen[_sportsmenNum] = sportsman;
                _sportsmenNum++;
            }
            public void Add(Sportsman[] sportsmen)
            {
                if (_sportsmen == null || sportsmen == null || sportsmen.Length == 0 || _sportsmenNum >= _sportsmen.Length)
                    return;

                int k = 0;
                while (_sportsmenNum < _sportsmen.Length && k < sportsmen.Length)
                {
                    _sportsmen[_sportsmenNum] = sportsmen[k];
                    _sportsmenNum++;
                    k++;
                }
            }
            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length == 0) return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if (teams[j + 1].SummaryScore > teams[j].SummaryScore)
                        {
                            Team tmp = teams[j + 1];
                            teams[j + 1] = teams[j];
                            teams[j] = tmp;
                        }
                        else if (teams[j + 1].SummaryScore == teams[j].SummaryScore &&
                            teams[j + 1].TopPlace < teams[j].TopPlace)
                        {
                            Team tmp = teams[j + 1];
                            teams[j + 1] = teams[j];
                            teams[j] = tmp;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine(_name);
                for (int k = 0; k < _sportsmenNum; k++)
                    _sportsmen[k].Print();
                Console.WriteLine();
            }
        }//struct Team
    }
}
