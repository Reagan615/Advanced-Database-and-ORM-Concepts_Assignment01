using System.ComponentModel.DataAnnotations;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class User
    {
        public int Id { get; set; }


        [Required(AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "Must be betweeen 3 and 20 characters", MinimumLength = 3)]
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
