using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


namespace Lesson6._2
{
    class ToDo
    {
        public string Title { get; set; }

        public bool IsDone { get; set; }

        public ToDo()
        {

        }
        public ToDo(string title, bool isDone)
        {
            Title = title;
            IsDone = isDone;
        }

        public void Add(string title) { 
            
        }
    }
}
