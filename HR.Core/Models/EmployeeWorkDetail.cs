﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Core.Models
{
   public class EmployeeWorkDetail
    {
        public int Id { get; set; }
        
        public int BranchId { get; set; }
        public int? DesignationId { get; set; }
        public int? DepartmentId { get; set; }
        public int EmployeeHeaderId { get; set; }
        //public virtual EmployeeHeader EmployeeHeader { get; set; }
        //public virtual Branch Branch  { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public Int16? ProbationPeriod { get; set; }
        public Int16? NoticePeriod { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public DateTime? ResignationDate { get; set; }

    }
}
