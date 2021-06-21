using System;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "axiomatic", "inject", "evasive", "improve", "calculating", "weak", "expensive", "absorbed", "utopian", "sidewalk", "protective", "distinct", "thread", "hollow", "gaze", "crash", "obscene", "malicious", "ugliest", "offer", "chilly", "soggy", "hateful", "massive", "imported", "picayune", "delicate", "unequaled", "day", "glistening" };
            var rand = new Random();
            string word = words[rand.Next(0,29)];
            char[] guessed = new char[word.Length];
            int guessedIndex = 0; 
            string hidden = Hide(word, guessed);
            string guess = "";
            int attempts = 0;
            bool finished = false;
            StringBuilder incorrect = new StringBuilder(word.Length);
            while (!finished)
            {
                Console.WriteLine("\nWord: {0}. You have made {1} attempts, {2}. \nMake a guess." ,hidden, attempts, incorrect);
                guess = Console.ReadLine();
                if(guess.Length>1)
                {
                    if (guess.Equals(word))
                    {
                        Console.WriteLine("Congratulations, you won!");
                        finished = true;
                        break;
                    }
                    else
                    {
                        attempts++;
                    }
                }
                else
                {
                    if (word.Contains(guess))
                    {
                        guessed[guessedIndex++] = guess[0];
                        hidden = Hide(word, guessed);
                        if (hidden.Equals(word))
                        {
                            Console.WriteLine("Congratulations, you won!");
                            finished = true;
                            break;
                        }
                    }
                    else
                    {
                        incorrect.Append(guess);
                        attempts++;
                    }
                }
                if (attempts == 10)
                {
                    Console.WriteLine("Sorry, you falied to reveal the word.");
                    break;
                }
            }


        } //main

        static String Hide (string input, char[] revealed)
        {
            string output = input;
            foreach(char c in input)
            {
                if(!(Array.Exists(revealed, element => element == c)))
                {
                    output = output.Replace(c, '_');
                }
            }
            return (output);
        }
    }
}
