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
    }
}