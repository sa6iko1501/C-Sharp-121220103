using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application4
{
    public class Contact { 
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != null)
                {
                    _name = value;
                }
                else
                {
                    Random random = new Random();
                    int rand = random.Next(0, 100000);
                    _name = String.Format($"user{rand}");
                }
            }
        }

        public Contact(String name)
        {
            this.Name = name;
        }
    }
}
