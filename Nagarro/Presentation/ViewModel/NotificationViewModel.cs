using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Presentation.ViewModel
{
    
    public class NotificationViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Notification Type :")]
        [Required(ErrorMessage = "Notification Type is required")]
        public NotificationType NotificationType { get; set; }

        [Display(Name = "Subject :")]
        [Required(ErrorMessage = "Subject is required")]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Display(Name = "Description :")]
        [Required(ErrorMessage = "Description is required")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}