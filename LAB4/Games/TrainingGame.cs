using System;

// Тренувальна гра без рейтингу
public class TrainingGame : Game
{
    public TrainingGame(GameAccount currentPlayer, GameAccount opponentPlayer, int currentRating, int opponentRating) : base(currentPlayer, opponentPlayer, currentRating, opponentRating) { }

    public override int CalculateRating(int rating, bool isWin)
    {
        // тестування - виводить опис гри
        Console.WriteLine($"Training: normal rating: {rating} -> calculated rating 0");

        return 0;   // Тренувальна гра не впливає на рейтинг
    }

    public override string Type()
    {
        return "training";
    }
}