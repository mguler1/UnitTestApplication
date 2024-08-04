using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobApplication.Models;
using JobApplication.Services;
namespace JobApplication
{
    public class ApplicationEvaluators
    {
        private const int minAge = 18;
        private const int autoAcceptYearsofExperience = 15;
        private readonly IIdentityValidateService _identityValidateService;
        private  List<string> teckStackList = new() {"C#","Java","Go" };

        public ApplicationEvaluators(IIdentityValidateService identityValidateService)
        {
                 _identityValidateService = identityValidateService;
        }
        public ApplicationResult Evaluate(JApplication form)
        {
            if (form.Applicant.Age<minAge)
            {
                return ApplicationResult.AutoRejected;
            }
            var valid = _identityValidateService.IsValid(form.Applicant.IdentityNumber);
            var sr = GetTechStackSimilarityRate(form.TechStackList);
            if (sr<25)
            {
                return ApplicationResult.AutoRejected;
            }
            if (sr>75 && form.YearsOfExprience >= autoAcceptYearsofExperience)
            { 
                return ApplicationResult.AutoAccepted;
            }
            return ApplicationResult.AutoAccepted;
        }

        private int GetTechStackSimilarityRate(List<string> teckStackList) 
        { 
            var matchCount=teckStackList.Where(x=>teckStackList.Contains(x,StringComparer.OrdinalIgnoreCase)).Count();
            return (int)((double)matchCount/teckStackList.Count)*100;
        }
    }
}
public enum ApplicationResult
{
    AutoRejected,
    AutoAccepted,
    TransferredToHr,
    TransferredToLead,
    TransferredToCto
}
