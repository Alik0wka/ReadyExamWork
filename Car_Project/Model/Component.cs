using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project
{
    public class Component
    {
        public Component()
        {

        }
        public Component(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
        public string name { get; set; }
        public int id { get; set; }
    }
}
