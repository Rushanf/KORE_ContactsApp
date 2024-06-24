using System.ComponentModel.DataAnnotations;

namespace KORE_Contacts_Service.ViewModels
{
    public class Contact
    {        
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Title { get; set; }
        public string MiddleInitial { get; set; } = string.Empty;
    }
}
