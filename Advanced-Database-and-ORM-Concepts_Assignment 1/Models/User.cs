namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public User()
        {

        }
        public User(string userName)
        {

            UserName = userName;
        }
    }
}
