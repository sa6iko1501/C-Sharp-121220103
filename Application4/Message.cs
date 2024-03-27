using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application4
{
    public class Message
    {
        private string _author;
        private string _text;
        public String Author { get { return _author; } set { numberOfTimesModified++; _author = value; } }
        public String Text { get { return _text; } set { numberOfTimesModified++; _text = value; } }
        private DateTime dateTime;
        private int numberOfTimesModified;

        public Message (string author, string text) {
            this.Author = author;
            this.Text = text;
            dateTime = DateTime.Now;
            //Тъй като при всяко достъпване на get, set на Text или Author променяме брояча го нулираме при създаването на обекта.
            numberOfTimesModified = 0;
        }

        public Boolean WasModified()
        {
            return numberOfTimesModified == 0 ? false : true;
        }
    }
}
