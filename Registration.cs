using System.ComponentModel.DataAnnotations;

namespace EventManagementApp.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        public string Phone { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Please select an event.")]
        public int EventId { get; set; }

        public bool IsPresent { get; set; }
    }
}