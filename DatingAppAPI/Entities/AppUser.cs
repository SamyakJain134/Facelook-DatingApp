using DatingAppAPI.Extensions;

namespace DatingAppAPI.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
        
        public DateTime DateofBirth { get; set; }

        public string KnownAs { get; set; } 

        public DateTime Created { get; set; } = DateTime.Now;  

        public DateTime LastActive { get; set; }   =DateTime.Now;

        public string Gender { get; set; }
        public String Introduction { get; set; }

        public string LookingFor { get; set; }  
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> Photos { get; set; }

        //In order fr mapper to go in this method, its going to get the app user and going to retrive things that are not needed by us
        // so for Get Ageb function we are not going to to this way
/*        public int GetAge()
        {
            return DateofBirth.CalculateAge(); 
            //datetime extension
        }

        CancellationToken get age we will add this functionality in automapper profiles */
    }
}
