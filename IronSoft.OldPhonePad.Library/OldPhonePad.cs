using System.Text;

namespace IronSoft.OldPhonePad.Library
{
    public static class OldPhonePad
    {
        // Define the key mappings
        private static readonly Dictionary<char, char[]> KEY_MAPPING = new Dictionary<char, char[]>
        {
            { '1', new char[] { '&', '\'', '(', ')' } },
            { '2', new char[] { 'A', 'B', 'C' } },
            { '3', new char[] { 'D', 'E', 'F' } },
            { '4', new char[] { 'G', 'H', 'I' } },
            { '5', new char[] { 'J', 'K', 'L' } },
            { '6', new char[] { 'M', 'N', 'O' } },
            { '7', new char[] { 'P', 'Q', 'R', 'S' } },
            { '8', new char[] { 'T', 'U', 'V' } },
            { '9', new char[] { 'W', 'X', 'Y', 'Z' } },
            { '0', new char[] { ' ' } },
            { '*', new char[] { '\b' } },
            { '#', new char[] { '\n' } },
        };

        #region Private Methods

        /// <summary>
        /// Map the input to the key mapping
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static List<KeyValuePair<string, int>> MapIutput(
            List<KeyValuePair<char, int>> input
        )
        {
            List<KeyValuePair<string, int>> inputMapping = new List<KeyValuePair<string, int>>();

            char lastKey = char.MinValue;
            int lastIndex = 0;

            // loop through the input
            foreach (var item in input)
            {
                char key = item.Key;
                int duration = item.Value;
                int index = 0;
                char[] chars = KEY_MAPPING[key];

                if (KEY_MAPPING.ContainsKey(key))
                {
                    // if this is the same key as the previous one and duration is zero
                    if (key.ToString() == lastKey.ToString() && duration == 0)
                    {
                        // increment the index
                        index = (lastIndex + 1) % chars.Length;
                        // remove the old key
                        inputMapping.RemoveAt(inputMapping.Count - 1);
                        // add the key with the new index
                        inputMapping.Add(new KeyValuePair<string, int>(key.ToString(), index));
                    }
                    else
                    {
                        // add the key with index zero
                        // If pause for 1 second in order to type two characters on the same key this will work too
                        inputMapping.Add(new KeyValuePair<string, int>(key.ToString(), 0));
                    }
                    lastKey = key;
                    lastIndex = index;
                }
            }

            return inputMapping;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Check if the key is valid
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsValidKey(string key)
        {
            bool result = false;
            if (key.Length == 1 && KEY_MAPPING.ContainsKey(key[0]))
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Generate the output
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GenerateOutput(List<KeyValuePair<char, int>> input)
        {
            List<KeyValuePair<string, int>> mappedInput = MapIutput(input);

            StringBuilder output = new StringBuilder();
            foreach (var item in mappedInput)
            {
                if (item.Key == "*")
                {
                    output.Remove(output.Length - 1, 1);
                }
                else
                {
                    char[] chars = KEY_MAPPING[item.Key[0]];
                    output.Append(chars[item.Value]);
                }
            }

            return output.ToString();
        }

        #endregion
    }
}
