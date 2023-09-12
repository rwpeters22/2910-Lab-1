/*
 Name: Ryan Peters
 Course: CSCI-2910-001
 Date: 9/2/23
 Assignment: Review Lab
*/

using Lab1;
using System.Collections.Immutable;
using System.Linq;


// #1
List<videoGame> gameList = new List<videoGame>();
string fileName = @"..\..\..\videoGameDataFolder\videogames.csv";

try
{
    using (StreamReader rdr = new StreamReader(fileName))
    {
        rdr.ReadLine();
        while(rdr.Peek() != -1)
        {
            string nextGameInfo = rdr.ReadLine();
            string[] videoGameFields = nextGameInfo.Split(',');

            videoGame vg = new videoGame(videoGameFields[0], videoGameFields[1], int.Parse(videoGameFields[2]), videoGameFields[3],
            videoGameFields[4], decimal.Parse(videoGameFields[5]), decimal.Parse(videoGameFields[6]), decimal.Parse(videoGameFields[7]),
            decimal.Parse(videoGameFields[8]), decimal.Parse(videoGameFields[9]));
            gameList.Add(vg);
        }
    }
}

catch (Exception e)
{
    Console.WriteLine(e.ToString());
}

// #2
gameList.Sort();

for (int i = 0; i < gameList.Count; i++)
{
    Console.WriteLine(gameList[i]);
}

// #3
//I used the following link for help setting up the IEnumerable: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where?view=net-7.0;

IEnumerable<videoGame> nintendoGames = gameList.Where(nintendoGame => nintendoGame.GetPublisher() == "Nintendo");

List<videoGame> nintendoGameList = nintendoGames.ToList();
nintendoGameList.Sort();

foreach (videoGame game in nintendoGameList)
{
    Console.WriteLine(game);
}

// #4
double numGames = gameList.Count;
double numNintendoGames = nintendoGameList.Count;
decimal numDecimal = Math.Round(Convert.ToDecimal(numNintendoGames/numGames),2);

Console.WriteLine($"Out of {numGames}, {numNintendoGames} are developed by Nintendo, which is approximately {numDecimal*100}%.");

// #5
IEnumerable<videoGame> sportsGames = gameList.Where(sportGame => sportGame.GetGenre() == "Sports");

List<videoGame> sportsGamesList = sportsGames.ToList();
sportsGamesList.Sort();

foreach(videoGame game in sportsGamesList)
{
    Console.WriteLine(game);
}

// #6
double numSportsGames = sportsGamesList.Count;
decimal sportsDecimal = Math.Round(Convert.ToDecimal(numSportsGames/numGames), 2);

Console.WriteLine($"Out of {numGames}, {numSportsGames} are sports games, which is approximately {sportsDecimal * 100}%.");

// #7
Console.WriteLine("\nPlease enter the name of a publisher to explore the game database and see the list of games that are published by that company.\n");

string publisherString = Console.ReadLine();

List<videoGame> publisherGameList = new List<videoGame>();

void PublisherData(string publisherString)
{
    IEnumerable<videoGame> publisherGames = gameList.Where(publisherGame => publisherGame.GetPublisher() == publisherString);

    publisherGameList = publisherGames.ToList();
    publisherGameList.Sort();
}

PublisherData(publisherString);

foreach(videoGame game in publisherGameList)
{
    Console.WriteLine(game);
}

// #8
Console.WriteLine("\nPlease enter the name of a genre to explore the game database and see the list of games that are of that genre type.\n");

string genreString = Console.ReadLine();

List<videoGame> genreGameList = new List<videoGame>();

void GenreData(string publisherString)
{
    IEnumerable<videoGame> genreGames = gameList.Where(genreGame => genreGame.GetGenre() == genreString);

    genreGameList = genreGames.ToList();
    genreGameList.Sort();
}

GenreData(genreString);

foreach (videoGame game in genreGameList)
{
    Console.WriteLine(game);
}

