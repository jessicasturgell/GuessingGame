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
    string randomBoon = Boons();
    string randomDeath = Deaths();
    int difficultyAttempts = SelectDifficulty();
    Console.WriteLine($"You will have {difficultyAttempts} attempts to find the correct answer.");
    int secretNumber = SecretNumber();
    Guess(secretNumber, difficultyAttempts, randomBoon, randomDeath);
}

    string Boons()
    {
        List<string> boons = new List<string> {
            "a basket of orc feathers",
            "a potion of endless giggles",
            "a cloak of invisibility that only works on Tuesdays",
            "a talking sword with a sarcastic sense of humor",
            "a bottomless mug that always fills with your favorite beverage",
            "a magical hat that summons an army of friendly squirrels",
            "a pair of enchanted shoes that make you dance like nobody's watching",
            "a spellbook that only contains useless spells, like making tea boil faster",
            "a pet dragon that hoards bubblegum instead of gold",
            "a mystical crystal ball that tells you the best jokes from alternate dimensions"
        };

        Random rand = new Random();
        int index = rand.Next(boons.Count);

        return boons[index];
    }

    string Deaths()
    {
        List<string> deaths = new List<string> {
            "chewed thoroughly and spit out as indigestible",
            "swallowed whole and then burped out with a cloud of glitter",
            "nibbled on like a crunchy snack",
            "gobbled up like a piece of toast with extra butter",
            "devoured with a side of enchanted hot sauce",
            "munched on like a tasty tidbit",
            "crunched up like a crunchy potato chip",
            "munched down like a delicious dessert",
            "gulped down like a refreshing beverage",
            "gobbled up like a delicious appetizer"
        };

        Random rand = new Random();
        int index = rand.Next(deaths.Count);

        return deaths[index];
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
        else if (selectedDifficulty == "boolProp testingCheatsEnabled true")
        {
            string difficultyString = "CHEATER";
            Console.WriteLine($"\nYou have enabled {difficultyString} mode. This has angered the gods.");
            return int.MaxValue;
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

void Guess(int secretNumber, int difficultyAttempts, string randomBoon, string randomDeath)
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
                Console.WriteLine($"\nCorrect! You have received {randomBoon}. You figured out the secret number on attempt #{attempts}.");
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
        Console.WriteLine($"\nIncorrect! The answer was {secretNumber}. You are {randomDeath}.");
    }
}

