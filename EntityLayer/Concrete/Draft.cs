﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Draft
    {
        [Key]
        public int DraftID { get; set; }
        [StringLength(100)]
        public string DraftSubject { get; set; }
        [StringLength(50)]
        public string SenderMail { get; set; }
        [StringLength(50)]
        public string ReceiverMail { get; set; }
        public string DraftContent { get; set; }
        public bool DraftStatus { get; set; }
        public DateTime DraftDate { get; set; }
    }
}
