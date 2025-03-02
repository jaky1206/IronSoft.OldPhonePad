using System.Net;

namespace IronSoft.OldPhonePad.UnitTests
{
    public class OldPhonePadTests
    {
        #region IsValidKey
        [Fact]
        public void IsValidKey_ReturnFalse()
        {
            Assert.False(Libraries.OldPhonePad.IsValidKey("T"));
        }
        [Fact]
        public void IsValidKey_ReturnTrue()
        {
            Assert.True(Libraries.OldPhonePad.IsValidKey("3"));
        }
        #endregion

        #region GenerateOutPut
        [Fact]
        public void GenerateOutPut_ReturnsException()
        {
            // Mimicking the input 33#
            List<KeyValuePair<char, int>> input = new List<KeyValuePair<char, int>>();
            input.Add(new KeyValuePair<char, int>('3', 0));
            input.Add(new KeyValuePair<char, int>('M', 0));
            Assert.ThrowsAny<Exception>(() => Libraries.OldPhonePad.GenerateOutput(input));
        }
        [Fact]
        public void GenerateOutPut_ReturnsValidInput_E()
        {
            // Mimicking the input 33# and output E
            List<KeyValuePair<char, int>> input = new List<KeyValuePair<char, int>>
            {
                new KeyValuePair<char, int>('3', 0),
                new KeyValuePair<char, int>('3', 0),
            };
            Assert.Equal("E", Libraries.OldPhonePad.GenerateOutput(input));
        }

        [Fact]
        public void GenerateOutPut_ReturnsValidInput_B()
        {
            // Mimicking the input 227*# and output E
            List<KeyValuePair<char, int>> input = new List<KeyValuePair<char, int>>
            {
                new KeyValuePair<char, int>('2', 0),
                new KeyValuePair<char, int>('2', 0),
                new KeyValuePair<char, int>('7', 0),
                new KeyValuePair<char, int>('*', 0),
            };
            Assert.Equal("B", Libraries.OldPhonePad.GenerateOutput(input));
        }

        [Fact]
        public void GenerateOutPut_ReturnsValidInput_HELLO()
        {
            // Mimicking the input 4433555 555666# and output HELLO
            List<KeyValuePair<char, int>> input = new List<KeyValuePair<char, int>>
            {
                new KeyValuePair<char, int>('4', 0),
                new KeyValuePair<char, int>('4', 0),
                new KeyValuePair<char, int>('3', 0),
                new KeyValuePair<char, int>('3', 0),
                new KeyValuePair<char, int>('5', 0),
                new KeyValuePair<char, int>('5', 0),
                new KeyValuePair<char, int>('5', 0),
                new KeyValuePair<char, int>('5', 1),
                new KeyValuePair<char, int>('5', 0),
                new KeyValuePair<char, int>('5', 0),
                new KeyValuePair<char, int>('6', 0),
                new KeyValuePair<char, int>('6', 0),
                new KeyValuePair<char, int>('6', 0),
            };
            Assert.Equal("HELLO", Libraries.OldPhonePad.GenerateOutput(input));
        }
        [Fact]
        public void GenerateOutPut_ReturnsValidInput_TURING()
        {
            // Mimicking the input 8 88777444666*664# and output TURING
            List<KeyValuePair<char, int>> input = new List<KeyValuePair<char, int>>
            {
                new KeyValuePair<char, int>('8', 0),
                new KeyValuePair<char, int>('8', 1),
                new KeyValuePair<char, int>('8', 0),
                new KeyValuePair<char, int>('7', 0),
                new KeyValuePair<char, int>('7', 0),
                new KeyValuePair<char, int>('7', 0),
                new KeyValuePair<char, int>('4', 0),
                new KeyValuePair<char, int>('4', 0),
                new KeyValuePair<char, int>('4', 0),
                new KeyValuePair<char, int>('6', 0),
                new KeyValuePair<char, int>('6', 0),
                new KeyValuePair<char, int>('6', 0),
                new KeyValuePair<char, int>('*', 0),
                new KeyValuePair<char, int>('6', 0),
                new KeyValuePair<char, int>('6', 0),
                new KeyValuePair<char, int>('4', 0),
            };
            Assert.Equal("TURING", Libraries.OldPhonePad.GenerateOutput(input));
        }
        #endregion
    }
}
