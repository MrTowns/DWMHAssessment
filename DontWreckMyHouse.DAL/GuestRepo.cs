using DontWreckMyHouse.CORE.DTO;
using DontWreckMyHouse.CORE.Interfaces;

namespace DontWreckMyHouse.DAL
{
    public class GuestRepo : IGuestRepo
    {
        private const string HEADER = "guest_id,first_name,last_name,email,phone,state";
        private readonly string filePath;

        public GuestRepo(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Guest> FindAllGuest()
        {
            throw new NotImplementedException();
        }

        public Guest FindByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}