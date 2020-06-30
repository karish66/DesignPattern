﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class MapRelation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int NotificationId { get; set; }

        public virtual User User { get; set; }
        public virtual Notification Notification{ get; set; }
    }
}