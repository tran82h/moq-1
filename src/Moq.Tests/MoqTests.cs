﻿using Xunit;
using static Moq.Arg;

namespace Moq.Tests
{
    public class MoqTests
    {
        [Fact(Skip = "Waiting on Roslyn generator.")]
        public void CanSetupPropertyViaReturns()
        {
            var calculator = Mock.Of<ICalculator>();

            calculator.Mode.Returns("Basic");

            var mode = calculator.Mode;

            Assert.Equal("Basic", mode);
        }

        [Fact(Skip = "Waiting on Roslyn generator.")]
        public void CanSetupMethodWithArgumentsViaReturns()
        {
            var calculator = Mock.Of<ICalculator>();

            calculator.Add(2, 3).Returns(5);

            var result = calculator.Add(2, 3);

            Assert.Equal(5, result);
        }

        [Fact(Skip = "Waiting on Roslyn generator.")]
        public void CanSetupMethodWithDifferentArgumentsViaReturns()
        {
            var calculator = Mock.Of<ICalculator>();

            calculator.Add(2, 2).Returns(4);
            calculator.Add(2, 3).Returns(5);
            calculator.Add(10, Any<int>()).Returns(10);
            calculator.Add(Is<int>(i => i > 20), Any<int>()).Returns(20);

            Assert.Equal(5, calculator.Add(2, 3));
            Assert.Equal(4, calculator.Add(2, 2));
            Assert.Equal(10, calculator.Add(10, 2));
            Assert.Equal(20, calculator.Add(25, 20));
        }
    }
}