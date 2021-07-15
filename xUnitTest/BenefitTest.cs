using LIR.DOMAIN.Entities;
using LIR.INFRASTRUCTURE.Services;
using Moq;
using Xunit;

namespace xUnitTest
{
    public class BenefitTest
    {
        Mock<RetirementSetupRepository> retirementSetup = new Mock<RetirementSetupRepository>();

        [Fact]
        public void Test_GetRetirementSetup_NotNull()
        {
            var lookUpSetup = new RetirementSetup()
            {
                GuaranteedIssue = 50000,
                MaxAgeLimit = 50,
                MinAgeLimit = 25,
                MinimumRange = 1,
                MaximumRange = 3,
                Increments = 1
            };
            retirementSetup.Setup(x => x.GetSetup()).Returns(lookUpSetup);

            var result = retirementSetup.Object.GetSetup();

            Assert.NotNull(result);
        }

        [Fact]
        public void Test_GetRetirementSetup_Null()
        {
            var lookUpSetup = new RetirementSetup();

            retirementSetup.Setup(x => x.GetSetup()).Returns(lookUpSetup);

            var result = retirementSetup.Object.GetSetup();

            Assert.Null(result);
        }

        [Fact]
        public void Test_CreateSetup()
        {
            var lookUpSetup = new RetirementSetup()
            {
                GuaranteedIssue = 50000,
                MaxAgeLimit = 50,
                MinAgeLimit = 25,
                MinimumRange = 1,
                MaximumRange = 3,
                Increments = 1
            };

            retirementSetup.Setup(x => x.CreateSetup(lookUpSetup)).Returns(true);

            var result = retirementSetup.Object.CreateSetup(lookUpSetup);

            Assert.True(result);
        }

        [Fact]
        public void Test_UpdateSetup()
        {
            var lookUpSetup = new RetirementSetup()
            {
                GuaranteedIssue = 50000,
                MaxAgeLimit = 50,
                MinAgeLimit = 25,
                MinimumRange = 1,
                MaximumRange = 3,
                Increments = 12345
            };

            retirementSetup.Setup(x => x.UpdateSetup(lookUpSetup)).Returns(true);

            var result = retirementSetup.Object.UpdateSetup(lookUpSetup);

            Assert.True(result);
        }
    }
}
