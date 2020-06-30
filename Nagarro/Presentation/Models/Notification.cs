using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Presentation.Models
{

    
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MapRelation> MapRelations { get; set; }
    }
}