using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TestTask.Model
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public static IEnumerable<Cat> GetCats()
        {
            for(int i=0; i<5; i++)
            {
                yield return new Cat
                {
                    Id = i,
                    Name = $"Кот {i}",
                    Age = i * i
                };
            }
        }

        public override string ToString()
        {
            return $"Я кот {Name}, мне {Age} лет!";
        }
    }
}