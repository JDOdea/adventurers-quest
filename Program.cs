﻿using Quest;



// Make a new "Adventurer" object using the "Adventurer" class
    Console.WriteLine("What is thine name, adventurer?");
    string response = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(response))
    {
        Console.WriteLine("Enter thine own name...");
        response = Console.ReadLine();
    }
Robe robe = new Robe
{
    Length = 10,
    Colors = new List<string>
    {
        "green",
        "blue",
        "purple",
        "yellow"
    }
};
Hat hat = new Hat
{
    ShininessLevel = 9
};
Prize prize = new("WIN");
Adventurer theAdventurer = new Adventurer(response, robe, hat);
Console.WriteLine(theAdventurer.GetDescription());

bool gaming = true;

while (gaming)
    {
        // Create a few challenges for our Adventurer's quest
    // The "Challenge" Constructor takes three arguments
    //   the text of the challenge
    //   a correct answer
    //   a number of awesome points to gain or lose depending on the success of the challenge
    Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
    Challenge theAnswer = new Challenge(
        "What's the answer to life, the universe and everything?", 42, 25);
    Challenge whatSecond = new Challenge(
        "What is the current second?", DateTime.Now.Second, 50);

    int randomNumber = new Random().Next() % 10;
    Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

    Challenge favoriteBeatle = new Challenge(
        @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
    ",
        4, 20
    );

    Challenge howOld = new Challenge("How old am I?", 0, 20);
    Challenge bestBand = new Challenge(
        @"Who's the best band?
    1) Radiohead
    2) Nickelback
    3) Smash Mouth
    4) Jonas Brothers
    ",
        1, 80
    );

    // "Awesomeness" is like our Adventurer's current "score"
    // A higher Awesomeness is better

    // Here we set some reasonable min and max values.
    //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
    //  If an Adventurer has an Awesomeness less than the min, they are terrible
    int minAwesomeness = 0;
    int maxAwesomeness = 100;

    

    // A list of challenges for the Adventurer to complete
    // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
    List<Challenge> challenges = new List<Challenge>()
    {
        twoPlusTwo,
        theAnswer,
        whatSecond,
        guessRandom,
        favoriteBeatle,
        howOld,
        bestBand
    };
    List<Challenge> selectedChallenges = new List<Challenge>();

    // Loop through all the challenges and subject the Adventurer to them
    /* foreach (Challenge challenge in challenges)
    {
        challenge.RunChallenge(theAdventurer);
    } */
    for (int i = 0; i < 5; i++)
    {
        int randomIndex = new Random().Next(challenges.Count);
        selectedChallenges.Add(challenges[randomIndex]);
        challenges.Remove(challenges[randomIndex]);
    }
    foreach (Challenge challenge in selectedChallenges)
    {
        challenge.RunChallenge(theAdventurer);
    }
    prize.ShowPrize(theAdventurer);

    // This code examines how Awesome the Adventurer is after completing the challenges
    // And praises or humiliates them accordingly
    if (theAdventurer.Awesomeness >= maxAwesomeness)
    {
        Console.WriteLine("YOU DID IT! You are truly awesome!");
        Console.WriteLine($"You had {theAdventurer.Successes} successes.");
    }
    else if (theAdventurer.Awesomeness <= minAwesomeness)
    {
        Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
        Console.WriteLine($"You had {theAdventurer.Successes} successes.");
    }
    else
    {
        Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
        Console.WriteLine($"You had {theAdventurer.Successes} successes.");
    }

    //  Play again?
    string newGame = "";
    while (newGame == "")
    {
        Console.WriteLine("Shall we adventure still? Y/N");
        string newGameResponse = Console.ReadLine().ToUpper();
        switch (newGameResponse)
        {
            case "Y":
            theAdventurer.Awesomeness = 50 + (10 * theAdventurer.Successes);
            theAdventurer.Successes = 0;
            newGame = "YES";
            break;
            case "N":
            newGame = "NO";
            gaming = false;
            break;
            default:
            Console.WriteLine("Answer with only 'Y' or 'N'");
            break;
        }
    }

}