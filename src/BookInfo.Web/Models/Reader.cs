namespace BookInfo.Models
{
    // EF will create an entity from this model that is essentially a join table in the application database. 
    // It will join the user (Reader) in the application database with the user (IdentityReader) in the Identity database. 

    public class Reader
    {
        // primary key for this user in the application database
        public int ReaderId { get; set; }

        // foreign key for the user in the Identity database
        public string IdentityReaderId { get; set; }

        public string UserName { get; set; }
    }
}
