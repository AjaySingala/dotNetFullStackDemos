using Moq;
using Xunit;

namespace MoqDemo.Lib.Tests
{
    public class ThingDependencyTests
    {
        [Fact]
        public void TestUsingRealDependency()
        {
            // Arrange.
            var sut = new ThingBeingTested(new ThingDependency());

            // Act.
            var result = sut.X();

            // Assert.
            Assert.Equal("A B = 42", result);
        }

        [Fact]
        public void TestUsingMockDependency()
        {
            // create mock version
            var mockDependency = new Mock<IThingDependency>();

            // set up mock version's method
            mockDependency.Setup(x => x.JoinUpper(It.IsAny<string>(), It.IsAny<string>()))
                          .Returns("A B");

            // set up mock version's property
            mockDependency.Setup(x => x.Meaning)
                          .Returns(42);

            // create thing being tested with a mock dependency
            var sut = new ThingBeingTested(mockDependency.Object);

            var result = sut.X();

            Assert.Equal("A B = 42", result);
        }

        [Fact]
        public void TestUsingMockDependencyUsingInteractionVerification()
        {
            // create mock version
            var mockDependency = new Mock<IThingDependency>();

            // create thing being tested with a mock dependency
            var sut = new ThingBeingTested(mockDependency.Object)
            {
                FirstName = "Sarah",
                LastName = "Smith"
            };

            sut.X();

            // Assert that the JoinUpper method was called with Sarah Smith
            mockDependency.Verify(x => x.JoinUpper("Sarah", "Smith"), Times.Once);

            // Assert that the Meaning property was accessed once
            mockDependency.Verify(x => x.Meaning, Times.Once);
        }

        [Fact]
        public void TestCardUsingMockDependency()
        {
            // create mock version
            var mockDependency = new Mock<IThingDependency>();

            // set up mock version's method
            mockDependency.Setup(x => x.JoinUpper("John", "Smith"))
                          .Returns("John Smith");

            // set up mock version's property
            mockDependency.Setup(x => x.Meaning)
                          .Returns(42);

            // Mock the card.
            var card = new Card
            {
                Name = "Peter Quill",
                Number = 1234567890,
                CVV = 666
            };
            mockDependency.Setup(t => t.Charge(123, card)).Returns(true);
            //mockDependency.Setup(t => t.Charge(It.IsAny<int>(), card)).Returns(true);

            // create thing being tested with a mock dependency
            var sut = new ThingBeingTested(mockDependency.Object);

            var result = sut.X();
            var res2 = sut.ChargeTheCard(122, card);

            Assert.Equal("John Smith = 42", result);
        }
    }
}