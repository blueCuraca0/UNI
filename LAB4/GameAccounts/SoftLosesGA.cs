using System;

// аккаунт, у якого знімається вдвоє менше балів при програші

public class SoftLosesGA : GameAccount
{
    public SoftLosesGA(string name) : base(name) { } // Ініціалізація для аккаунту із зменшеними балами за програш

    public override int CalculateRating(int rating)
    {
        if (rating < 0) return rating / 2;
        else return rating;
    }
}