using Xunit;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;

namespace Roses.App.Tests
{
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
        [Fact]
        public async Task ThirtyDays()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            await ProgramActions.RunAll();
            var output = fakeoutput.ToString();

            Approvals.Verify(output);
        }
    }
}
