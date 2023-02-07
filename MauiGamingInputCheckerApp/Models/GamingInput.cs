using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiGamingInputCheckerApp.Models;

public partial class GamingInput : ObservableObject
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

    [ObservableProperty] bool isPressedKeyA = false;
    [ObservableProperty] bool isPressedKeyB = false;
    [ObservableProperty] bool isPressedKeyX = false;
    [ObservableProperty] bool isPressedKeyY = false;


    public int? DeviceId { get; private set; }

    public string? DeviceName { get; private set; }


    public Action<GamingInputArgs> KeyDown;
    public Action<GamingInputArgs> KeyUp;


    public void OnKeyDown(GamingInputArgs args)
    {

        UpdateObservableProperties(args);
        //IsPressedKeyA = args.IsPressed(KEYS.KEY_A);
        //DeviceName = "hoge";

        KeyDown?.Invoke(args);
    }


    public void OnKeyUp(GamingInputArgs args)
    {
        UpdateObservableProperties(args);

        KeyUp?.Invoke(args);
    }



    public void SetDeviceID(int id) => DeviceId = id;

    public void SetDeviceName(string name) => DeviceName = name;


    private void UpdateObservableProperties(GamingInputArgs args)
    {
        IsPressedKeyA = args.IsPressed(KEYS.KEY_A);
        IsPressedKeyB = args.IsPressed(KEYS.KEY_B);
        IsPressedKeyX = args.IsPressed(KEYS.KEY_X);
        IsPressedKeyY = args.IsPressed(KEYS.KEY_Y);
    }

}
