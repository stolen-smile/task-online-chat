using Microsoft.EntityFrameworkCore;
using OnlineChat.Data;
using OnlineChat.Models;

namespace OnlineChat.Services
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            Context context = app.ApplicationServices
                .GetRequiredService<Context>();
            context.Database.Migrate();
            if (!context.Users.Any())
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

                context.Users.AddRange(new List<User>() { hottabych,prepared,Tom,Platon });

                context.Messages.AddRange(new List<Message>() {
                    messageFromTomToPlaton,
                    messageFromHottabychToPrepared,
                    messageFromHottabychToTom,
                    messageFromPreparedToHottabych,
                    messageFromPreparedToTom,
                    messageForGroup });
                context.Groups.AddRange(new List<Group>() { group });

                context.SaveChanges();
            }          
        }
    }
}
