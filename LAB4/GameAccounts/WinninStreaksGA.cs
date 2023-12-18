using System;

// аккаунт в якому нараховуються додаткові бали за серію перемог.
public class WinningStreakGA : GameAccount
{
    private int winsInRow;

    public WinningStreakGA(string name) : base(name)
    {
        winsInRow = 0;
    }

    public override int CalculateRating(int rating)
    {
        if (rating > 0)
        {
            winsInRow++;
            return (rating + (winsInRow - 1) * 5);  // Бонуси за серію перемог
        }
        else
        {
            winsInRow = 0;                      // При програші серія перемог обнуляється
            return rating;
        }
    }
}