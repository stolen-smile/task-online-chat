using OnlineChat.Models;

namespace OnlineChat.Mock
{
    public class FakeRepository : IRepository
    {
        protected IQueryable<User> _users;
        protected IQueryable<Message> _messages;
        protected IQueryable<Group> _groups;
        public FakeRepository()
        {
            _users = initUsers();
            _messages = initMessages();
            _groups = initGroups();
        }

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

            //groups
            Group group = new Group()
            {
                GroupName = "Test Group",
                UsersInGroup = new List<User>()
                {
                    hottabych,prepared,Tom
                }
            };
            hottabych.Groups = new List<Group>() { group };
            prepared.Groups = new List<Group>() { group };
            Tom.Groups = new List<Group>() { group };
            Message messageForGroup = new Message()
            {
                Text = "Hello guys, this is test group!",
                Sender = hottabych,
                AddresseeUser = null,
                AddresseeGroup = group,
                SendTime = new DateTime(2022, 7, 20, 18, 47, 25)
            };
            hottabych.Messages.Add(messageForGroup);
            group.MessagesInGroup = new List<Message>() { messageForGroup };

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
            //groups
            Group group = new Group()
            {
                GroupName = "Test Group",
                UsersInGroup = new List<User>()
                {
                    hottabych,prepared,Tom
                }
            };
            hottabych.Groups = new List<Group>() { group };
            prepared.Groups = new List<Group>() { group };
            Tom.Groups = new List<Group>() { group };
            Message messageForGroup = new Message()
            {
                Text = "Hello guys, this is test group!",
                Sender = hottabych,
                AddresseeUser = null,
                AddresseeGroup = group,
                SendTime = new DateTime(2022, 7, 20, 18, 47, 25)
            };
            hottabych.Messages.Add(messageForGroup);
            group.MessagesInGroup = new List<Message>() { messageForGroup };

            IQueryable<Message> messages = new List<Message>()
            {
                messageFromTomToPlaton, messageFromHottabychToTom,
                messageFromHottabychToPrepared, messageFromPreparedToHottabych,
                messageFromPreparedToTom
            }.AsQueryable<Message>();
            return messages;
        }

        protected IQueryable<Group> initGroups()
        {
            User hottabych = new User() { NickName = "hottabych" };
            User prepared = new User() { NickName = "prepared" };
            User Tom = new User() { NickName = "Tom" };
            User Platon = new User() { NickName = "Platon" };

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



            //groups
            Group group = new Group()
            {
                GroupName = "Test Group",
                UsersInGroup = new List<User>()
                {
                    hottabych,prepared,Tom
                }
            };
            hottabych.Groups = new List<Group>() { group };
            prepared.Groups = new List<Group>() { group };
            Tom.Groups = new List<Group>() { group };
            Message messageForGroup = new Message()
            {
                Text = "Hello guys, this is test group!",
                Sender = hottabych,
                AddresseeUser = null,
                AddresseeGroup = group,
                SendTime = new DateTime(2022, 7, 20, 18, 47, 25)
            };
            hottabych.Messages.Add(messageForGroup);
            group.MessagesInGroup = new List<Message>() { messageForGroup };

            IQueryable<Group> groups = new List<Group>()
            {
                group
            }.AsQueryable<Group>();
            return groups;
        }

        public IQueryable<User> Users => _users;

        public IQueryable<Group> GroupChats => _groups;
        public IQueryable<Message> Messages { get => _messages; } 
    } 
       
        //public void Add(Message message)
        //{
        //    var a = new List<Message>();
        //    a.AddRange(_messages.ToList());
        //    a.Add(message);
        //    _messages = a.AsQueryable<Message>();
        //}
       //public IQueryable<Message> IRepository.Messages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
}
