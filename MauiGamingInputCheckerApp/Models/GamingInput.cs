
namespace MauiGamingInputCheckerApp.Models;

public class GamingInput
{
    public enum KEYS
    {
        None = 0,
        KEY_1,  // Y for Xbox controller (test)
        KEY_2,  // A
        KEY_3,  // B
        KEY_4,  // X
        KEY_UP,
        KEY_DOWN,
        KEY_LEFT,
        KEY_RIGHT
    }


    public Action<GamingInputArgs> KeyDown;
    public Action<GamingInputArgs> KeyUp;

    public void OnKeyDown(GamingInputArgs args) => KeyDown?.Invoke(args);
    public void OnKeyUp(GamingInputArgs args) => KeyUp?.Invoke(args);

}
