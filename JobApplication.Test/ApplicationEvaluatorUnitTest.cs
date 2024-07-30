using JobApplication.Models;

namespace JobApplication.Test
{
    public class ApplicationEvaluatorUnitTest
    {
        [Test]
        public void Application_WithUnderAge_TransferredAutoRejected()
        {
            var evaluater = new ApplicationEvaluators();

            var form = new JApplication()
            {
                Applicant = new Applicant
                {
                    Age = 17
                }
            };

            var appResult= evaluater.Evaluate(form);    

            Assert.AreEqual(appResult,ApplicationResult.AutoRejected);
        }


        [Test]
        public void Application_WithNoTechStack_TransferredAutoRejected()
        {
            var evaluater = new ApplicationEvaluators();

            var form = new JApplication()
            {
                Applicant = new Applicant(),
                 TechStackList=new System.Collections.Generic.List<string>() { ""}
            };

            var appResult = evaluater.Evaluate(form);

            Assert.AreEqual(appResult, ApplicationResult.AutoRejected);
        }



        [Test]
        public void Application_WithTechStackOver75P_TransferredAutoAccepted()
        {
            var evaluater = new ApplicationEvaluators();

            var form = new JApplication()
            {
                Applicant = new Applicant() { Age = 19 },
                TechStackList = new System.Collections.Generic.List<string>() {"C#","Java","Go" },
                YearsOfExprience=16

            };

            var appResult = evaluater.Evaluate(form);

            Assert.AreEqual(appResult, ApplicationResult.AutoAccepted);
        }


    }
}