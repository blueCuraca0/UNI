using System;
using System.Collections.Generic;

// 	клас GameAccount виступає в ролі стандарнтого ігрового акаунта
public class GameAccount
{
    private static int numOfAccounts = 0;

    private int id;

    public int Id { get { return id; } }

    private string userName;

    public string UserName
    {
        get { return userName; }
        set
        {
            // Перевірка, чи ім'я не є порожнім
            if (!string.IsNullOrEmpty(value)) userName = value;
            else Console.WriteLine("Ім'я не може бути порожнім.");
        }
    }

    private int rating;

    public int Rating
    {
        get { return rating; }
        set
        {
            // Перевірка, чи значення не менше 1 перед встановленням
            if (value >= 1) rating = value;
            else
            {
                Console.WriteLine("Помилка: Рейтинг повинен бути не менше 1.");
                rating = 1;
            }
        }
    }

    public int GamesCount
    {
        get { return gameHistory.Count; }
    }

    private List<Game> gameHistory;

    public GameAccount(string name)
    {
        UserName = name;
        Rating = 100;                  // Початковий рейтинг 100
        gameHistory = new List<Game>();
        id = numOfAccounts++;
    }


    public virtual int CalculateRating(int rating)
    {
        return rating;
    }

    public void GameResults(int rating, bool isWin, Game game)
    {
        gameHistory.Add(game);
        if (!isWin) rating *= -1;
        Rating += CalculateRating(rating);
    }

    // Передається ім'я того гравця, з перспективи якого аналізуєтсья гра
    // (щоб коректно виводити, виграв він чи програв)
    public void GetStats(string currentName)
    {

        Console.WriteLine($"Current rating: {Rating}");
        Console.WriteLine($"Rounds played: {GamesCount}\n");

        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.WriteLine("| № game | Game Type      | Opponent             | Result        | Players Ratings   |");
        Console.WriteLine("--------------------------------------------------------------------------------------");

        for (int i = 0; i < gameHistory.Count; i++)
        {

            var game = gameHistory[i];
            string opponentName;
            int currentRating;
            int opponentRating;

            bool isEqual = string.Equals(currentName, game.CurrentPlayer.UserName);
            if (isEqual)
            {
                opponentName = game.OpponentPlayer.UserName;
                currentRating = game.CurrentRating;
                opponentRating = game.OpponentRating;
            }
            else
            {
                opponentName = game.CurrentPlayer.UserName;
                currentRating = game.OpponentRating;
                opponentRating = game.CurrentRating;
            }

            Console.WriteLine($"| {game.gameIndex,-6} | {game.Type(),-14} | {opponentName,-20} | {(currentRating < opponentRating ? "LOSE" : "WIN"),-13} | {currentRating,-3} / {opponentRating,-12}|");
        }
        Console.WriteLine("--------------------------------------------------------------------------------------");

    }
}