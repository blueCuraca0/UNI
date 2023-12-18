using System;

// Базовий абстрактний клас гри
// * конструктор бути абстрактним не може *
public abstract class Game
{
    public static int numOfGames = 0;

    public int gameIndex;


    GameAccount currentPlayer;
    public GameAccount CurrentPlayer
    {
        get { return currentPlayer; }
        set
        {
            if (value != null) currentPlayer = value;        // Перевірка, чи ім'я не є порожнім
            else Console.WriteLine("ERROR: Non-existing player");
        }
    }


    GameAccount opponentPlayer;
    public GameAccount OpponentPlayer
    {
        get { return opponentPlayer; }
        set
        {
            if (value != null) opponentPlayer = value;        // Перевірка, чи ім'я не є порожнім
            else Console.WriteLine("ERROR: Non-existing player");
        }
    }


    private int currentRating;
    public int CurrentRating
    {
        get { return currentRating; }
        set
        {
            if (value >= 0) currentRating = value;  // Перевірка, чи значення не від'ємне перед встановленням
            else
            {
                currentRating = 1;
                Console.WriteLine("Помилка: Рейтинг повинен бути не менше 1.");
            }
        }
    }


    private int opponentRating;
    public int OpponentRating
    {
        get { return opponentRating; }
        set
        {
            if (value >= 0) opponentRating = value; // Перевірка, чи значення не від'ємне перед встановленням
            else
            {
                opponentRating = 1;
                Console.WriteLine("Помилка: Рейтинг повинен бути не менше 1.");
            }
        }
    }


    public abstract int CalculateRating(int rating, bool isWin);
    public abstract string Type();

    public Game(GameAccount currentPlayer, GameAccount opponentPlayer, int currentRating, int opponentRating)
    {
        this.CurrentPlayer = currentPlayer;
        this.OpponentPlayer = opponentPlayer;

        bool isWin = currentRating >= opponentRating;

        this.CurrentRating = currentRating;
        this.OpponentRating = opponentRating;

        gameIndex = numOfGames++;
    }
}