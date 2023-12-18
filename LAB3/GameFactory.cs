using System;

// клас, що містить функції для створення об'єкту конкретної гри та переведення об'єкту до базового типу гри 
public class GameFactory
{
    public static Game CreateGame(GameAccount currentPlayer, GameAccount opponentPlayer, int currentRating, int opponentRating, string gameType)
    {
        switch (gameType)
        {
            case "1":
                return new StandardGame(currentPlayer, opponentPlayer, currentRating, opponentRating);
            case "2":
                return new TrainingGame(currentPlayer, opponentPlayer, currentRating, opponentRating);
            case "3":
                return new AllOrNothingGame(currentPlayer, opponentPlayer, currentRating, opponentRating);
            default:
                throw new ArgumentException("Невідомий тип гри");
        }
    }
}