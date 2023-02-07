namespace MauiGamingInputCheckerApp.Models;

public class GamingInputArgs
{
    public GamingInput.KEYS Keys { get; init; }


    public GamingInputArgs(GamingInput.KEYS keys)
    {
        Keys = keys;
    }

    // Utility methods
    public bool IsPressed(GamingInput.KEYS key) => Keys.HasFlag(key);

}
