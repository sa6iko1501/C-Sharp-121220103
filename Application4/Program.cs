// See https://aka.ms/new-console-template for more information
using Application4;

ChatRoom chatRoom = new ChatRoom("chatroom");
Contact contact = new Contact(null);
Contact contact2 = new Contact("Aleksandar Stoyanov");
Console.WriteLine("Hello!\n\n");
Console.WriteLine("1.Generate user\n");
Console.WriteLine("2.Create a message\n");
Console.WriteLine("3.Get stats from the chat room\n");
string input = Console.ReadLine();
switch (input)
{
    case "1":
        {
            Contact contact3 = new Contact(null);
            Console.WriteLine("Generated user: " + contact3.Name);
            break;
        }
    case "2":
        {
            Console.WriteLine("Message:\n");
            string text = Console.ReadLine();
            Console.WriteLine("Author:\n");
            string author = Console.ReadLine();
            Message customMessage = new Message(author, text);
            Console.WriteLine(customMessage.Text + " -" + customMessage.Author);
            break;
        }
    case "3":
        {
            //Генерираме данни за тестване на функцията за извеждане на потребителя с най-много съобщения
            chatRoom.addContact(contact);
            chatRoom.addContact(contact2);
            //Проверяваме рандом user с име null
            Console.WriteLine("Testing other functionalities of the program...");
            Console.WriteLine(contact.Name);
            Console.WriteLine(contact2.Name);
            //Тук тестваме функционалността за промяна на съобщение (Може да бъде интерпретирана в менюто но това е извън scope на задачата)
            Message message = new Message(contact.Name, "Some Text Here...");
            if (message.WasModified())
            {
                Console.WriteLine("Message with author " + message.Author + " and content:\n\t" + message.Text + "\nWAS modified");
            }
            else
            {
                Console.WriteLine("Message with author " + message.Author + " and content:\n\t" + message.Text + "\nWAS NOT modified");
            };
            message.Text = "Change the text to something else";
            if (message.WasModified())
            {
                Console.WriteLine("Message with author " + message.Author + " and content:\n\t" + message.Text + "\nWAS modified");
            }
            else
            {
                Console.WriteLine("Message with author " + message.Author + " and content:\n\t" + message.Text + "\nWAS NOT modified");
            };
            Console.WriteLine("\nStats for chatroom:");
            Message message2 = new Message(contact2.Name, "Some message");
            Message message3 = new Message(contact.Name, "Shortest Text");
            chatRoom.addMessage(message);
            chatRoom.addMessage(message2);
            chatRoom.addMessage(message3);
            Tuple<string, int, string> result = chatRoom.getChatroomStats();
            Console.WriteLine("\n\t user with most messages: " + result.Item1.ToString());
            Console.WriteLine("\n\t number of messages: " + result.Item2.ToString());
            Console.WriteLine("\n\t shortest message of user: " + result.Item3.ToString());
            break;
        }
}



