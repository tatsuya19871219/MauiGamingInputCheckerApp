
namespace MauiGamingInputCheckerApp.Models;

public class GamingInput
{
    public enum KEYS
    {
        None = 0,
        KEY_A,
        KEY_B,
        KEY_X,
        KEY_Y,
        KEY_UP,
        KEY_DOWN,
        KEY_LEFT,
        KEY_RIGHT
    }


    public int? DeviceId { get; private set; }

    public Action<GamingInputArgs> KeyDown;
    public Action<GamingInputArgs> KeyUp;

    public void OnKeyDown(GamingInputArgs args) => KeyDown?.Invoke(args);
    public void OnKeyUp(GamingInputArgs args) => KeyUp?.Invoke(args);


    public void SetDeviceID(int id) => DeviceId = id;

}
