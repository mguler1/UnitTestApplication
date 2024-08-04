using JobApplication.Models;
using JobApplication.Services;
using Moq;

namespace JobApplication.Test
{
    public class ApplicationEvaluatorUnitTest
    {
        [Test]
        public void Application_WithUnderAge_TransferredAutoRejected()
        {
            var evaluater = new ApplicationEvaluators(null);

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
            var mockValidator=new Mock<IIdentityValidateService >();
            mockValidator.Setup(x=>x.IsValid(It.IsAny<string>())).Returns(true);

            var evaluater = new ApplicationEvaluators(mockValidator.Object);
            var form = new JApplication()
            {
                Applicant = new Applicant() { Age = 19, IdentityNumber = "123456" },
                 TechStackList =new System.Collections.Generic.List<string>() { ""}
            };

            var appResult = evaluater.Evaluate(form);

            Assert.AreEqual(appResult, ApplicationResult.AutoRejected);
        }



        [Test]
        public void Application_WithTechStackOver75P_TransferredAutoAccepted()
        {
            var mockValidator = new Mock<IIdentityValidateService>();
            mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
            var evaluater = new ApplicationEvaluators(mockValidator.Object);

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