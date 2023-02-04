
namespace MauiGamingInputCheckerApp.Models;

public class GamingInput
{
    [Flags]
    public enum KEYS
    {
        None = 0,
        KEY_A = 1,
        KEY_B = 2,
        KEY_X = 4,
        KEY_Y = 8,
        KEY_UP = 16,
        KEY_DOWN = 32,
        KEY_LEFT = 64,
        KEY_RIGHT = 128,
        KEY_START = 256,
        KEY_SELECT = 512,
        KEY_LEFTSHOULDER = 1024,
        KEY_RIGHTSHOULDER = 2048
    }


    public int? DeviceId { get; private set; }

    public string? DeviceName { get; private set; }

    //public bool IsEnable { get; private set; }

    public Action<GamingInputArgs> KeyDown;
    public Action<GamingInputArgs> KeyUp;

    //public void Enable() => IsEnable = true;
    //public void Disable() => IsEnable = false;

    public void OnKeyDown(GamingInputArgs args)
    {
        //if (IsEnable) 
        KeyDown?.Invoke(args);
    }

    public void OnKeyUp(GamingInputArgs args)
    {
        //if (IsEnable)
        KeyUp?.Invoke(args);
    }


    
    public void SetDeviceID(int id) => DeviceId = id;

    public void SetDeviceName(string name) => DeviceName = name;
}
