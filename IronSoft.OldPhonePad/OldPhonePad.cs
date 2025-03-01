using System.Collections.Generic;
using System.Text;

namespace IronSoft.OldPhonePad
{
    internal static class OldPhonePad
    {
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

        public static bool IsValidKey(string key)
        {
            bool result = false;
            if (key.Length == 1 && KEY_MAPPING.ContainsKey(key[0]))
            {
                result = true;
            }
            return result;
        }

        public static string GenerateOutput(List<KeyValuePair<string, int>> input)
        {
            StringBuilder output = new StringBuilder();

            List<KeyValuePair<string, int>> inputMapping = new List<KeyValuePair<string, int>>();

            foreach (var item in input)
            {
                char key = item.Key[0];
                int duration = item.Value;
                int index = 0;
                if (KEY_MAPPING.ContainsKey(key))
                {
                    char[] chars = KEY_MAPPING[key];
                    // if this is the first key add it with index zero
                    if (inputMapping.Count == 0)
                    {
                        // Add the first key with index zero
                        inputMapping.Add(new KeyValuePair<string, int>(chars[index].ToString(), index));
                    }
                    else
                    {
                        // if this is the same key as the previous one and duration is zero
                        if (inputMapping[inputMapping.Count - 1].Key == chars[index].ToString() && duration == 0)
                        {
                            // increment the index
                            index = (inputMapping[inputMapping.Count - 1].Value + 1) % chars.Length;
                            // remove the old key
                            inputMapping.RemoveAt(inputMapping.Count - 1);
                            // add the key with the new index
                            inputMapping.Add(new KeyValuePair<string, int>(chars[index].ToString(), index));
                        }
                        else
                        {
                            // if this is a different key
                            // add the key with index zero
                            inputMapping.Add(new KeyValuePair<string, int>(chars[index].ToString(), index));
                        }
                    }

                }
            }

            foreach (var item in inputMapping)
            {
                // apply special handling for backspace and newline
                if (item.Key == "\b")
                {
                    output.Remove(output.Length - 1, 1);
                }
                else
                {
                    output.Append(item.Key);
                }
                //output.Append(item.Key);
            }

            return output.ToString();
        }
    }
}
