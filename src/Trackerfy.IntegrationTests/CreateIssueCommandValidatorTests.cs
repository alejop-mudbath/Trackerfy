using Shouldly;
using Trackerfy.Application;
using Trackerfy.Application.Issues.Commands.CreateIssue;
using Xunit;

namespace Trackerfy.IntegrationTests
{
    public class CreateIssueCommandValidatorTests
    {
        [Fact]
        public void ShouldBeTrue_WhenSummaryIsNotEmpty()
        {
            var command = new CreateIssueCommand("summary", 21);

            var validator = new CreateIssueCommandValidator();
            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void ShouldBeFalse_WhenSummaryIsEmpty()
        {
            var command = new CreateIssueCommand("", 21);

            var validator = new CreateIssueCommandValidator();
            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void ShouldBeFalse_WheIssueTypeIsEmpty()
        {
            var command = new CreateIssueCommand("summary", 0);

            var validator = new CreateIssueCommandValidator();
            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}