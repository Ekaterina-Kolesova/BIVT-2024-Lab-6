using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            //поля
            private string _name;
            private int[] _scores; //
            private int _playedMatchesNum;

            //свойства
            public string Name => _name;
            public int[] Scores
            {
                get
                {
                    if (_scores == null) return null;

                    int[] copy = new int[_scores.Length];
                    for (int k = 0; k < copy.Length; k++)
                        copy[k] = _scores[k];
                    return copy;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;

                    int totalScore = 0;
                    for (int k = 0; k < _scores.Length; k++)
                        totalScore += _scores[k];
                    return totalScore;
                }
            }

            //конструкторы
            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
                _playedMatchesNum = 0;
            }

            //методы
            private void IncreaseCapasity()
            {
                if (_scores == null || _scores.Length == 0)
                {
                    _scores = new int[1];
                    return;
                }

                int[] tmp = new int[_scores.Length + 1];
                int k = 0;
                foreach (int score in _scores)
                    tmp[k++] = score;
                _scores = tmp;
            }

            public void PlayMatch(int result)
            {
                if (_scores == null) return;
                if (_playedMatchesNum >= _scores.Length)
                    IncreaseCapasity();
                _scores[_playedMatchesNum] = result;
                _playedMatchesNum++;
            }
            public void Print()
            {
                Console.Write($"{_name,10} :");
                for (int k = 0; k < _scores.Length; k++)
                    Console.Write($"{_scores[k],4}");
                //Console.WriteLine();
                Console.WriteLine($"    Total score - {TotalScore}");
            }
        }//struct Team

        public struct Group
        {
            //поля
            private string _name;
            private Team[] _teams;//12
            private int _teamsNum;

            //свойства
            public string Name => _name;
            public Team[] Teams
            {
                get
                {
                    if (_teams == null) return null;

                    Team[] copy = new Team[_teams.Length]; //!!!
                    for (int k = 0; k < copy.Length; k++)
                        copy[k] = _teams[k];
                    return copy;
                }
            }

            //конструкторы
            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _teamsNum = 0;
            }

            //методы
            private bool IsTeamInGroup(Team team)
            {
                if (_teamsNum == 0) return false;
                for (int k = 0; k < _teamsNum; k++)
                {
                    if (_teams[k].Name == team.Name)
                        return true;
                }
                return false;
            }
            public void Add(Team team)
            {
                if (_teams == null || _teamsNum >= _teams.Length) return;
                //if (IsTeamInGroup(team)) return;
                _teams[_teamsNum] = team;
                _teamsNum++;
            }
            public void Add(Team[] teams)
            {
                if (_teams == null || teams == null || teams.Length == 0 || _teamsNum >= _teams.Length)
                    return;

                int k = 0;
                while (_teamsNum < _teams.Length && k < teams.Length)
                {
                    //if (!IsTeamInGroup(teams[k]))
                    _teams[_teamsNum] = teams[k];
                    _teamsNum++;//end if
                    k++;
                }
            }
            public void Sort()
            {
                if (_teams == null || _teamsNum == 0) return;

                for (int i = 0; i < _teamsNum - 1; i++)
                {
                    for (int j = 0; j < _teamsNum - i - 1; j++)
                    {
                        if (_teams[j + 1].TotalScore > _teams[j].TotalScore)
                        {
                            Team tmp = _teams[j + 1];
                            _teams[j + 1] = _teams[j];
                            _teams[j] = tmp;
                        }
                    }
                }
            }
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group res = new Group("Финалисты");
                int n = size / 2;
                int i = 0, j = 0;
                while (i < n && j < n)
                {
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                    {
                        res.Add(group1.Teams[i]);
                        i++;
                    }
                    else
                    {
                        res.Add(group2.Teams[j]);
                        j++;
                    }
                }
                while (i < n)
                {
                    res.Add(group1.Teams[i]);
                    i++;
                }
                while (j < n)
                {
                    res.Add(group1.Teams[i]);
                    j++;
                }
                return res;
            }
            public void Print()
            {
                Console.WriteLine(_name);
                for (int k = 0; k < _teamsNum; k++)
                    _teams[k].Print();
                Console.WriteLine();
            }

        }//struct Group
    }
}
