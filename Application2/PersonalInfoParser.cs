using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application2
{
    internal class PersonalInfoParser
    {
        private String pathToInput = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "resources", "input-02.txt");
        public PersonalInfoParser() 
        {
            parseInput();
        } 
        private void parseInput()
        {
            StringBuilder sb = new StringBuilder();
            if (File.Exists(pathToInput))
            {
                string namePattern = @"[А-Яа-я]+";
                string idNumberPattern = @"\d{6}";
                string phoneNumberPattern = @"\+395\s\d{3}\s\d{2}\s\d{2}";
                Regex nameRegex = new Regex(namePattern);
                Regex phoneRegex = new Regex(phoneNumberPattern);
                Regex idRegex = new Regex(idNumberPattern);
                List<String> nameList = new List<String>();
                List<String> phoneList = new List<String>();
                List<String> idList = new List<String>();
                using (StreamReader reader = new StreamReader(pathToInput))
                {
                    String line;
                    int limiter = 0;
                    /*
                     * Since there is for cycle logic in the function below we will limit the input only to the first 100 lines of input.
                     * Could be resolved with multithreading at a later time if the need arises. Logic is to match every line for a name, phone number and id.
                     * We store them in the lists on top and we know order will be preserved since they allways come in order.
                     * Мисля да започна да пиша коментарите на български??
                     */
                    while ((line = reader.ReadLine()) != null && limiter++ < 100)
                    {
                        MatchCollection nameCollection = nameRegex.Matches(line);
                        MatchCollection phoneCollection = phoneRegex.Matches(line);
                        MatchCollection idCollection = idRegex.Matches(line);
                        foreach(Match m in nameCollection)
                        {
                            nameList.Add(m.Value);
                        }
                        foreach(Match m in phoneCollection)
                        {
                            phoneList.Add(m.Value);
                        }
                        foreach (Match m in idCollection)
                        {
                            idList.Add(m.Value);
                        }
                    }
                }
                // Няма нужда от други проверки
                if(nameList.Count == phoneList.Count && nameList.Count == idList.Count)
                {
                    createPersonList(nameList, phoneList, idList);
                }
            }
        }

        private void createPersonList(List<String> names, List<String> phoneNumbers, List<String> ids)
        {
            List<Person> personList = new List<Person>();
            while(names.Count > 0)
            {
                personList.Add(new Person(names.ElementAt(0), ids.ElementAt(0), phoneNumbers.ElementAt(0)));
                names.Remove(names.ElementAt(0));
                phoneNumbers.Remove(phoneNumbers.ElementAt(0));
                ids.Remove(ids.ElementAt(0));
            }
            createAndFillJSONResourceFile(personList);
        }

        private bool createAndFillJSONResourceFile(List<Person> peopleList)
        {
            bool isSuccess = false;
            List<Object> peopleToJSON = new List<Object>();
            String jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "people.json");
            // Convert the data from the dictionary to Object since it will be simpler to put in JSON
            foreach (var person in peopleList)
            {
                var peopleObject = new { name = person.name, id = person.id, phone = person.phoneNumber };
                peopleToJSON.Add(peopleObject);
            }
            string jsonOutput = JsonSerializer.Serialize(peopleToJSON, new JsonSerializerOptions { WriteIndented = true });
            // Delete old coordinates.json if already one is generated
            if (File.Exists(jsonPath))
            {
                File.Delete(jsonPath);
            }
            File.WriteAllText(jsonPath, jsonOutput);
            if (File.Exists(jsonPath))
            {
                isSuccess = true;
            }
            return isSuccess;
        }
        class Person
        {
            public string name;
            public string id;
            public string phoneNumber;
            public Person(string name, string id, string phoneNumber)
            {
                this.name = name;
                this.id = id;
                this.phoneNumber = phoneNumber;
            }   
        }
    }
}
