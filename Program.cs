using System;
using System.Collections.Concurrent;

Main();

void Main()
{
    Console.Write(@"                 ___====-_  _-====___
           _--^^^#####//      \\#####^^^--_
        _-^##########// (    ) \\##########^-_
       -############//  |\^^/|  \\############-
     _/############//   (@::@)   \\############\_
    /#############((     \\//     ))#############\
   -###############\\    (oo)    //###############-
  -#################\\  / VV \  //#################-
 -###################\\/      \//###################-
_#/|##########/\######(   /\   )######/\##########|\#_
|/ |#/\#/\#/\/  \#/\##\  |  |  /##/\#/  \/\#/\#/\#| \|
`  |/  V  V  `   V  \#\| |  | |/#/  V   '  V  V  \|  '
   `   `  `      `   / | |  | | \   '      '  '   '
                    (  | |  | |  )
                   __\ | |  | | /__
                  (vvv(VVV)(VVV)vvv)");

    Console.WriteLine(" F O O L I S H  M O R T A L !");
    Console.WriteLine();
    Console.WriteLine("For intruding on my lair you must guess the number I'm thinking of.");
    Console.WriteLine("Guess correctly, and you can have a gift from my hoard!");
    Console.WriteLine("Guess incorrectly, and you can be my dinner.");
    int difficultyAttempts = SelectDifficulty();
    Console.WriteLine($"You will have {difficultyAttempts} attempts to find the correct answer.");
    int secretNumber = SecretNumber();
    Guess(secretNumber, difficultyAttempts);
}

int SelectDifficulty()
{
    string selectedDifficulty;
    do
    {
        Console.WriteLine("\nSelect your difficulty:");
        Console.WriteLine("  1) Easy (8 Attempts)");
        Console.WriteLine("  2) Medium (6 Attempts)");
        Console.WriteLine("  3) Hard (4 Attempts)");
        Console.Write("\nYour selection: ");
        selectedDifficulty = Console.ReadLine();

        if (selectedDifficulty == "1")
        {
            string difficultyString = "EASY";
            int difficultyAttempts = 8;
            Console.WriteLine($"\nYour difficulty level is {difficultyString}.");
            return difficultyAttempts;
        }
        else if (selectedDifficulty == "2")
        {
            string difficultyString = "MEDIUM";
            int difficultyAttempts = 6;
            Console.WriteLine($"\nYour difficulty level is {difficultyString}.");
            return difficultyAttempts;
        }
        else if (selectedDifficulty == "3")
        {
            string difficultyString = "HARD";
            int difficultyAttempts = 4;
            Console.WriteLine($"\nYour difficulty level is {difficultyString}.");
            return difficultyAttempts;
        }
        else
        {
            Console.WriteLine("\nInvalid selection. Please choose a valid difficulty level.");
        }
    } while (selectedDifficulty != "1" && selectedDifficulty != "2" && selectedDifficulty != "3");

    return 0;
}

int SecretNumber()
{
    Random r = new();
    int secretNumber = r.Next(1, 101);
    return secretNumber;
}

void Guess(int secretNumber, int difficultyAttempts)
{
    int answer = 0;
    int attempts = 0;
    bool isParsed = false;
    bool correct = false;

    do
    {
        Console.Write($"\nEnter a number (1-100): ");
        string input = Console.ReadLine();
        isParsed = int.TryParse(input, out answer);
        attempts++;

        if (isParsed && answer >= 1 && answer <= 100)
        {
            Console.WriteLine($"\nYou answered {answer}. This was attempt #{attempts} of {difficultyAttempts}.");
            if (answer == secretNumber)
            {
                Console.WriteLine($"\nCorrect! You have received a basket of orc feathers. You figured out the secret number on attempt #{attempts}.");
                correct = true;
            }
            else if (answer > secretNumber && attempts < difficultyAttempts)
            {
                Console.WriteLine($"\nToo high! Try again.");
            }
            else if (answer < secretNumber && attempts < difficultyAttempts)
            {
                Console.WriteLine($"\nToo low! Try again.");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid input. Please enter a valid number between 1 and 100.");
        }
    } while (attempts < difficultyAttempts && !correct);

    if (attempts >= difficultyAttempts || !correct)
    {
        Console.WriteLine($"\nIncorrect! The answer was {secretNumber}. You are dinner.");
    }
}
