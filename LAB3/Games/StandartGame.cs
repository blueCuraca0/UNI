using System;

// Клас, що описує стандартну гру
public class StandardGame : Game
{
    public StandardGame(GameAccount currentPlayer, GameAccount opponentPlayer, int currentRating, int opponentRating) : base(currentPlayer, opponentPlayer, currentRating, opponentRating) { }

    public override int CalculateRating(int rating, bool isWin)
    {
        // тестування - виводить опис гри
        Console.WriteLine($"Standard: normal rating: {rating} -> calculated rating {rating}");

        return rating;
    }

    public override string Type()
    {
        return "standart";
    }
}