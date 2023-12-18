using System;

// Гра на усі бали гравців: переможцю нараховуються усі бали супротивника,
// а рахуной переможеного скидається до мінімального (1)
public class AllOrNothingGame : Game
{

    public AllOrNothingGame(GameAccount currentPlayer, GameAccount opponentPlayer, int currentRating, int opponentRating) : base(currentPlayer, opponentPlayer, currentRating, opponentRating) { }

    public override int CalculateRating(int rating, bool isWin)
    {

        int a = CurrentPlayer.Rating;
        int b = OpponentPlayer.Rating;

        int transferedPoints = b - 1;


        // тестування - виводить опис гри
        Console.WriteLine($"All Or Nothing: normal rating: {rating} -> calculated rating {transferedPoints}");

        return transferedPoints;    // Переможець отримує всі бали супротивника
    }

    public override string Type()
    {
        return "all or nothing";
    }
}
