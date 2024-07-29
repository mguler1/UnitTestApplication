using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobApplication.Models;
namespace JobApplication
{
    public class ApplicationEvaluators
    {
        private const int minAge = 18;
        private  List<string> teckStackList = new() {"C#","Java","Go" };

        public ApplicationResult Evaluate(JApplication form)
        {
            if (form.Applicant.Age<minAge)
            {
                return ApplicationResult.AutoRejected;
            }
            return ApplicationResult.AutoCompleted;
        }
    }
}
public enum ApplicationResult
{
    AutoRejected,
    AutoCompleted,
    TransferredToHr,
    TransferredToLead,
    TransferredToCto
}
