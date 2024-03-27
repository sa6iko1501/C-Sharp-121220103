using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application4
{
    public class ChatRoom
    {
        private string _name;
        private List<Contact> _contacts;
        private List<Message> _messages;
        public String Name { get { return _name; } set {  _name = value; } }
        public List<Contact> Contacts { get { return _contacts; } set { _contacts = value; } }
        public List<Message> Messages { get { return _messages; } set { _messages = value; } }
        public ChatRoom(string name) {
            _name = name;
            _contacts = new List<Contact>();
            _messages = new List<Message>();
           }

        public void addContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void addMessage(Message message)
        {
            _messages.Add(message);
        }

        public Tuple<string, int, string> getChatroomStats()
        {
            // Получаваме желаната информаиця, използвайки LINQ, за да сортираме на няколко пъти съдържанието на листовете в chatroom
            var messageCountByAuthor = Messages.GroupBy(message => message.Author).Select(x => new { Author = x.Key, MessageCount = x.Count() });
            var authorWithMostMessages =  messageCountByAuthor.OrderByDescending(author => author.MessageCount).FirstOrDefault();
            var messagesOfAuthorWithMostMessages = Messages.Where(message => message.Author == authorWithMostMessages.Author);
            var shortestMessage = messagesOfAuthorWithMostMessages.OrderBy(message => message.Text.Length).FirstOrDefault();
            if (authorWithMostMessages != null && shortestMessage != null)
            {
               return new Tuple<string, int, string>(authorWithMostMessages.Author.ToString(), authorWithMostMessages.MessageCount, shortestMessage.Text.ToString());
            }
            return null;
        }
    }
}
