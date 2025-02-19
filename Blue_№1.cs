using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab6.Blue_1;

namespace Lab_6
{
    public class Blue_1
    {
        public struct Response
        {
            //поля
            private string _name;
            private string _surname;
            private int _votes;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;

            //конструкторы
            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }

            //методы
            public int CountVotes(Response[] responses)
            {
                if(responses == null || responses.Length == 0) return 0;

                foreach(Response response in responses)
                {
                    if (response.Name == _name && response.Surname == _surname)
                        _votes ++;    
                }
                return _votes;
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} has {_votes} votes");
            }
        }//struct Response
    }
}
