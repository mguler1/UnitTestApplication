using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplication.Models
{
    public class JApplication
    {
       
            public Applicant Applicant { get; set; }
            public int YearsOfExprience { get; set; }
            public List<string> TechStackList { get; set; }
        }
    
}
