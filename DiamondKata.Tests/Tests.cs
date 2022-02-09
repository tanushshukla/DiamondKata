using System;
using System.Diagnostics.SymbolStore;
using System.Linq;
using Xunit;

namespace DiamondKata
{
    public class Tests
    {
        [Fact]
        public void ThrowsExceptionWhenInvalidCharacter()
        {
            var diamond = new Diamond();
            var ex = Assert.Throws<ArgumentException>(() => diamond.GetDiamond('1'));

            Assert.Equal($"Invalid Character provider: 1", ex.Message);
        }

        [Fact]
        public void ReturnsAWhenCharacterIsA()
        {
            var diamond = new Diamond();
            var result = diamond.GetDiamond('A');

            Assert.Equal("A", result.First());
        }

        [Fact]
        public void ReturnsThreeLinesWhenCharacterIsB()
        {
            var diamond = new Diamond();
            var result = diamond.GetDiamond('B');

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void WhenCharacterIsBThenFirstAndLastLineIsA()
        {
            var diamond = new Diamond();
            var result = diamond.GetDiamond('B');

            Assert.Equal("-A-", result.First());
            Assert.Equal("-A-",result.Last());
        }
        [Fact]
        public void WhenCharacterIsBThenLine2IsBDashB()
        {
            var diamond = new Diamond();
            var result = diamond.GetDiamond('B');

            Assert.Equal("B-B", result.ElementAt(1));
        }

        [Fact]
        public void NumberOfRowsShouldBe2NMinus1()
        {
            var diamond = new Diamond();
            var result = diamond.GetDiamond('E');

            Assert.Equal(9, result.Count);
        }

        [Fact]
        public void NumberOfColumnsShouldBe2NMinus1()
        {
            var diamond = new Diamond();
            var result = diamond.GetDiamond('E');

            Assert.Equal(9, result.First().Length);
        }

        [Fact]
        public void NumberOfColumnsShouldBeEqualToNUmberOfRows()
        {
            var diamond = new Diamond();
            var result = diamond.GetDiamond('F');
            foreach (var row in result)
            {
                Assert.Equal(row.Length, result.Count);
            }
           
        }

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('C')]
        [InlineData('X')]
        [InlineData('Z')]
        public void NumberOfColumnsShouldBeEqualToNUmberOfRowsForNthItem(char lastCharacter)
        {
            var diamond = new Diamond();
            var result = diamond.GetDiamond(lastCharacter);
            foreach (var row in result)
            {
                Assert.Equal(row.Length, result.Count);
            }

        }

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('C')]
        [InlineData('X')]
        public void ShouldReturnCharacterIndexTimesTwoMinusOneRows(char lastCharacter)
        {
            var firstCharacter = 'A';
            var diamond = new Diamond();
            var result = diamond.GetDiamond(lastCharacter);
            Assert.Equal(2*(lastCharacter - firstCharacter) + 1, result.Count);

        }

        [Theory]
        [InlineData('a')]
        [InlineData('9')]
        [InlineData('j')]
        [InlineData('k')]
        [InlineData('@')]
        public void ThrowsExceptionWhenAnyInvalidCharacter(char c)
        {
            var diamond = new Diamond();
            var ex = Assert.Throws<ArgumentException>(() => diamond.GetDiamond(c));

            Assert.Equal($"Invalid Character provider: {c}", ex.Message);
        }

    }
}