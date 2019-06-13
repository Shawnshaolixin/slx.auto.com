using DomeTest;
using Xunit;

namespace DemoTestUnitTest
{
    public class CancluTest
    {
        [Fact]
        public void AddTest()
        {
            var sut = new Canclu();
            var result = sut.Add(1, 2);
            Assert.Equal(3, result);
        }
    }
}
