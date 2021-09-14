using System;
using System.Collections.Generic;
using System.Linq;
// Nicolas Cinera ISM 6225 / Programming Assignment #1
// I have ample programming experience, just not in C#. It should take me a couple of weeks to fully adjust
namespace Assignment_1
{
    class Program
    {

        static void Main(string[] args)
        {
            bool equal_bowels(string word)
            {
                string vowels = "aeiouAEIOU";
                string a = word.Substring(0, word.Length / 2);
                string b = word.Substring(word.Length / 2);

                int aCounter = 0;
                int bCounter = 0;

                foreach (char letter in vowels)
                {
                    if (a.Contains(letter))
                        aCounter+= a.Count(f => f == letter); 
                    if (b.Contains(letter))
                        bCounter+= b.Count(f => f == letter);
                }
                return aCounter == bCounter;
            }

            bool pangram_checker(string sentence)
            {
                // If the sentence is less than the 26 english chars in the alphabet then it is automatically false
                if (sentence.Length < 26)
                {
                    return false;
                }

                // Since we only have to check for lower case chars we limit the int array to 26.
                int[] frequency = new int[26];
                //Console.WriteLine('c' - 'a'); Checking if this works
                foreach (char character in sentence)
                    frequency[character - 'a']++;

                foreach (char f in frequency)
                {
                    // Checking all the chars have appeared at least once. 
                    if (f == 0)
                        return false;
                }

                return true;
            }

            int largest_account(int rows, int cols)
            {
                int[,] account = new int[rows, cols];
                int maxAccount = 0;
                Console.WriteLine("Please enter your account values.\nRemember your matrix is " + rows + " by " + cols);
                // Initialiizing the array with values.
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        account[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }

                for (int i = 0; i < rows; i++)
                {
                    int temp = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        temp += account[i, j];
                        if (temp > maxAccount)
                            maxAccount = temp;
                    }
                }
                return maxAccount;
            }

            int jewel_checker(string jewels, string stones)
            {
                int counter = 0;
                foreach (char jewel in jewels)
                {
                    counter += stones.Count(f => (f == jewel));
                }
                return counter;
            }

            /*string shuffle_string(string word, int[] indices)
            {
                string shuffle = "";
                Dictionary<int, char> myDict = new Dictionary<int, char>();

                foreach(int index in indices)
                {
                    myDict[index] = word[index];
                }

                //Sort Dictionary and then assign indices.
                foreach (KeyValuePair<int, char> item in myDict.OrderBy(key => key.Key))
                {
                    Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
                    shuffle += myDict[item.Key];
                }

                /*foreach (int index in indices)
                {
                    shuffle += myDict[index];
                }
                return shuffle;
            }*/

            string shuffle_string(string word, int[] indices)
            {
                char[] shuffle = new char[word.Length];
                for(int i = 0; i < indices.Length; i++)
                {
                    shuffle[indices[i]] = word[i];
                }
                return new string(shuffle);
            }

            List<int> restore_string(int[] nums, int[] indices)
            {
                List<int> restored = new List<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    restored.Insert(indices[i], nums[i]);
                }
                return restored;
            }

            bool testcase = equal_bowels("textbook");
            bool pangran_testcase = pangram_checker("thequickbrownfoxjumpsoverthelazydog");
            int account_testcase = largest_account(2, 3);
            int jewel_testcase = jewel_checker("aA", "aAAbbbb");
            string shuffle_testcase = shuffle_string("codeleet", new int[] { 4, 5, 6, 7, 0, 2, 1, 3 });
            List<int> restore_testcase = new List<int>();
            restore_testcase = restore_string(new int[] { 0, 1, 2, 3, 4 }, new int[] { 0, 1, 2, 2, 1 });
            Console.WriteLine("Equal Bowels: " + testcase);
            Console.WriteLine("Pangram: " + pangran_testcase);
            Console.WriteLine("Bank Accounts: " + account_testcase);
            Console.WriteLine("Jewel Count: " + jewel_testcase);
            Console.WriteLine("Shuffle Testcase: " + shuffle_testcase);
            Console.WriteLine(String.Join(",", restore_testcase));
        }
    }
}
