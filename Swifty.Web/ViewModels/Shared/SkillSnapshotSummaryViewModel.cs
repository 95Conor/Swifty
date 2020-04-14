using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swifty.Web.ViewModels.Shared
{
    public class SkillSnapshotSummaryViewModel
    {
        public int SkillSnapshotId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Reviewed By")]
        public string ReviewerEmail { get; set; }

        [Display(Name = "Date Reviewed")]
        public DateTime ReviewedDate { get; set; }

        public string ReviewerNotes { get; set; }
    }
}
