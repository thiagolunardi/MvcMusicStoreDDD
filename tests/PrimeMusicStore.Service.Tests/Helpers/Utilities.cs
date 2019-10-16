using PrimeMusicStore.Data.Context;

namespace PrimeMusicStore.Service.Tests
{
    public static class Utilities
    {
        public static void InitializeDbForTests(PrimeMusicStoreDbContext db)
        {
            //db.Messages.AddRange(GetSeedingMessages());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(PrimeMusicStoreDbContext db)
        {
            //db.Messages.RemoveRange(db.Messages);
            InitializeDbForTests(db);
        }

        //public static List<Message> GetSeedingMessages()
        //{
        //    return new List<Message>()
        //    {
        //        new Message(){ Text = "TEST RECORD: You're standing on my scarf." },
        //        new Message(){ Text = "TEST RECORD: Would you like a jelly baby?" },
        //        new Message(){ Text = "TEST RECORD: To the rational mind, " +
        //            "nothing is inexplicable; only unexplained." }
        //    };
        //}
    }

}
