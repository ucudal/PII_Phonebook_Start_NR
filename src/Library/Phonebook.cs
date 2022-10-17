using System.Collections.Generic;

namespace Library
{
    public class Phonebook : IMessageChannel
    {
        private List<Contact> persons;

        public Phonebook(Contact owner)
        {
            this.Owner = owner;
            this.persons = new List<Contact>();
        }

        public Contact Owner { get; }

        public void AddContact(Contact myContact){
            this.persons.Add(myContact);
        }

        public void DeleteContact(string name){
            foreach (Contact person in this.persons)
            {
                if (person.Name.Equals(name))
                {
                    this.persons.Remove(person);
                }
            }
        }

        public void SendEmail(Message message, string[] names, string text){
            List<Contact> persons = this.Search(names);
        }
        public void SendSMS(Message message, string[] names, string text){}

        public void SendSMS(string[] myNames, string text)
        {
            List<Contact> persons = this.Search(myNames);

            foreach (Contact person in persons)
            {
                foreach (string name in myNames)
                {
                    if (person.Name.Equals(name))
                    {
                        Message myMessage = new Message(this.Owner.Name, person.Name);
                    }
                }
            }
        }

        public List<Contact> Search(string[] names)
        {
            List<Contact> result = new List<Contact>();

            foreach (Contact person in this.persons)
            {
                foreach (string name in names)
                {
                    if (person.Name.Equals(name))
                    {
                        result.Add(person);
                    }
                }
            }

            return result;
        }
    }
}