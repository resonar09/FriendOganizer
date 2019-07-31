using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private readonly Func<FriendOrganizerDbContext> _contextCreator;

        public FriendDataService(Func<FriendOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }



        public Task<List<Friend>> GetAllAsync()
        {
            //I turned this off so Thomas could test without the database
            //using (var ctx = new FriendOrganizerDbContext())
            //{
            //    return await ctx.Friends.AsNoTracking().ToListAsync();
            //}

            //TODO: This will be changed back to the code above
            List<Friend> list = new List<Friend>();
            list.Add(new Friend { FirstName = "Thomas", LastName = "Huber" });

            list.Add(new Friend { FirstName = "Andreas", LastName = "Boehler" });
            list.Add(new Friend { FirstName = "Julia", LastName = "Huber" });
            list.Add(new Friend { FirstName = "Chris", LastName = "Egin" });

            return Task.Run(() => list);
        }
            
    }

}
