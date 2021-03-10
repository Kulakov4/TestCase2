using System;
using System.Collections.Generic;
using Xunit;

namespace Parentheses.Tests
{
    public class ParenthesesTests
    {
        [Fact]
        public void TestParenthesesIsBalanced()
        {
            var list = new List<string> {
                "((1+3)()(4+(3-5)))"
            };

            foreach (var s in list)
            {
                Assert.True(Parentheses.isBalanced(s));
            }
        }

        [Fact]
        public void TestParenthesesIsNotBalanced()
        {
            var list = new List<string>
                {"((())" };

            foreach (var s in list)
            {
                Assert.False(Parentheses.isBalanced(s));
            }
        }
    }
}
