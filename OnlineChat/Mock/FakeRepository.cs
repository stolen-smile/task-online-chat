using OnlineChat.Models;

namespace OnlineChat.Mock
{
    public class FakeRepository : IRepository
    {
        
        protected IQueryable<User> initUsers()
        {


            User hottabych = new User() { NickName = "hottabych" };
            User prepared = new User() { NickName = "prepared" };
            User Tom = new User() { NickName = "Tom" };
            User Platon = new User() { NickName = "Platon" };

            //message gen
            //message from Tom
            Message messageFromTomToPlaton = new Message()
            {
                Text = "Hello Platon, how are you? It's me, Tom.",
                Sender = Tom,
                AddresseeUser = Platon,
                SendTime = new DateTime(2022, 7, 20, 18, 30, 25)//year month day 
            };
            Tom.Messages = new List<Message>() { messageFromTomToPlaton };

            //messages from hottabych
            Message messageFromHottabychToTom = new Message()
            {
                Text = "Hello Tom, how is Platon? I am worry a bit.",
                Sender = hottabych,
                AddresseeUser = Tom,
                SendTime = new DateTime(2022, 7, 20, 18, 29, 25)//year month day 
            };

            Message messageFromHottabychToPrepared = new Message()
            {
                Text = "Hello friend!",
                Sender = hottabych,
                AddresseeUser = prepared,
                SendTime = new DateTime(2022, 7, 20, 18, 45, 25)//year month day 
            };
            hottabych.Messages = new List<Message>()
            {
                messageFromHottabychToPrepared,
                messageFromHottabychToTom
            };

            //messages from prepared
            Message messageFromPreparedToHottabych = new Message()
            {
                Text = "Hello lad)",
                Sender = prepared,
                AddresseeUser = hottabych,
                SendTime = new DateTime(2022, 7, 20, 18, 47, 25)//year month day 
            };
            Message messageFromPreparedToTom = new Message()
            {
                Text = "How are you Tom?",
                Sender = prepared,
                AddresseeUser = Tom,
                SendTime = new DateTime(2022, 7, 20, 18, 44, 25)//year month day 
            };
            prepared.Messages = new List<Message>()
            {
                messageFromPreparedToHottabych,
                messageFromPreparedToTom
            };

            IQueryable<User> Users = new List<User>()
            {
                hottabych,prepared,Tom,Platon
            }.AsQueryable<User>();
            return Users;
        }

        protected IQueryable<Message> initMessages()
        {
            User hottabych = new User() { NickName = "hottabych" };
            User prepared = new User() { NickName = "prepared" };
            User Tom = new User() { NickName = "Tom" };
            User Platon = new User() { NickName = "Platon" };

            Message messageFromTomToPlaton = new Message()
            {
                Text = "Hello Platon, how are you? It's me, Tom.",
                Sender = Tom,
                AddresseeUser = Platon,
                SendTime = new DateTime(2022, 7, 20, 18, 30, 25)//year month day 
            };
            Tom.Messages = new List<Message>() { messageFromTomToPlaton };

            //messages from hottabych
            Message messageFromHottabychToTom = new Message()
            {
                Text = "Hello Tom, how is Platon? I am worry a bit.",
                Sender = hottabych,
                AddresseeUser = Tom,
                SendTime = new DateTime(2022, 7, 20, 18, 29, 25)//year month day
            };

            Message messageFromHottabychToPrepared = new Message()
            {
                Text = "Hello friend!",
                Sender = hottabych,
                AddresseeUser = prepared,
                SendTime = new DateTime(2022, 7, 20, 18, 45, 25)//year month day
            };
            hottabych.Messages = new List<Message>()
            {
                messageFromHottabychToPrepared,
                messageFromHottabychToTom
            };

            //messages from prepared
            Message messageFromPreparedToHottabych = new Message()
            {
                Text = "Hello lad)",
                Sender = prepared,
                AddresseeUser = hottabych,
                SendTime = new DateTime(2022, 7, 20, 18, 47, 25)//year month day
            };
            Message messageFromPreparedToTom = new Message()
            {
                Text = "How are you Tom?",
                Sender = prepared,
                AddresseeUser = Tom,
                SendTime = new DateTime(2022, 7, 20, 18, 44, 25)//year month day 
            };
            prepared.Messages = new List<Message>()
            {
                messageFromPreparedToHottabych,
                messageFromPreparedToTom
            };

            IQueryable<Message> messages = new List<Message>()
            {
                messageFromTomToPlaton, messageFromHottabychToTom,
                messageFromHottabychToPrepared, messageFromPreparedToHottabych,
                messageFromPreparedToTom
            }.AsQueryable<Message>();
            return messages;
        }

        public IQueryable<User> Users => initUsers();

        public IQueryable<Message> Messages => initMessages();
    }
}
