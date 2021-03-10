using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RomanNumerals.Tests
{
    public class RomanNumeralsTests
    {

        // Проверяем случай, когда меньшая цифра записана справа от большей
        [Fact]
        public void Test1()
        {
            var romanNumerals = new Dictionary<string, int> 
            {
                {"VIII", 8 },
                {"XXVI", 26 },
                {"LXXIII", 73 }
            };

            foreach (var x in romanNumerals)
            {
                int actual = Roman.RomanToInt(x.Key);
                Assert.Equal(x.Value, actual);
            }
        }

        // Проверяем случай, когда меньшая цифра записана слева от большей
        [Fact]
        public void Test2()
        {
            var romanNumerals = new Dictionary<string, int>
            {
                {"IV", 4 },
                {"IX", 9 },
                {"XXIV", 24 },
                {"XLIV", 44 },
                {"CMXCIX", 999 },
            };

            foreach (var x in romanNumerals)
            {
                int actual = Roman.RomanToInt(x.Key);
                Assert.Equal(x.Value, actual);
            }
        }

        // Проверяем возникновение ошибки "Вычитаемая цифра должна быть степенью числа 10."
        [Fact]
        public void ThrowsPreviousDigitIsNotPowerOf10ExceptionTest()
        {
            var numbers = new List<string> { "VX", "LC" };
            foreach (var s in numbers)
            {
                Exception ex = Record.Exception(() => Roman.RomanToInt(s));
                Assert.NotNull(ex);
                Assert.IsType<RomanException>(ex);
                Assert.Equal(RomanExCode.PreviousDigitIsNotPowerOf10, (ex as RomanException).Code);
            }
        }

        // Проверяем возникновение ошибки "В качестве уменьшаемого могут выступать только ближайшие в числовом ряду к вычитаемой две цифры."
        [Fact]
        public void ThrowsPreviousDigitIsInvalidExceptionTest()
        {
            var numbers = new List<string> { "IC", "IM" };
            foreach (var s in numbers)
            {
                Exception ex = Record.Exception(() => Roman.RomanToInt(s));
                Assert.NotNull(ex);
                Assert.IsType<RomanException>(ex);
                Assert.Equal(RomanExCode.PreviousDigitIsInvalid, (ex as RomanException).Code);
            }
        }

        // Проверяем возникновение ошибки "Повторение меньшей цифры не допускается."
        [Fact]
        public void ThrowsPreviousDigitIsRepeatedExceptionTest()
        {
            Exception ex = Record.Exception(() => Roman.RomanToInt("IIV"));
            Assert.NotNull(ex);
            Assert.IsType<RomanException>(ex);
            Assert.Equal(RomanExCode.PreviousDigitIsRepeated, (ex as RomanException).Code);
        }

        // Проверяем возникновение ошибки "Цифра не является допустимой римской цифрой"
        [Fact]
        public void ThrowsDigitIsInvalidExceptionTest()
        {
            Exception ex = Record.Exception(() => Roman.RomanToInt("PV"));
            Assert.NotNull(ex);
            Assert.IsType<RomanException>(ex);
            Assert.Equal(RomanExCode.DigitIsInvalid, (ex as RomanException).Code);
        }

        // Проверяем возникновение ошибки "Цифра повторяется более X раз подряд"
        [Fact]
        public void ThrowsDigitIsRepeatedExceptionTest()
        {
            var numbers = new List<string> { "IIII", "CMXXXXVIII", "LXVVI" };

            foreach (var s in numbers)
            {
                Exception ex = Record.Exception(() => Roman.RomanToInt(s));
                Assert.NotNull(ex);
                Assert.IsType<RomanException>(ex);
                Assert.Equal(RomanExCode.DigitIsRepeated, (ex as RomanException).Code);
            }
        }
    }
}
