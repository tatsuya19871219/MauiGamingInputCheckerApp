using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MauiGamingInputCheckerApp.Models;
using Xamarin.Google.Crypto.Tink.Signature;

namespace MauiGamingInputCheckerApp;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density, ScreenOrientation = ScreenOrientation.Landscape)]
public class MainActivity : MauiAppCompatActivity
{
    static public MainActivity Instance { get; private set; }

    public Func<Keycode, GamingInput.KEYS> ConvertToKeyEnum;
    public Action<GamingInputArgs> KeyDown;
    public Action<GamingInputArgs> KeyUp;

    protected override void OnStart()
    {
        Instance = this;
        base.OnStart();
    }

    public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
    {

        var key = ConvertToKeyEnum?.Invoke(keyCode) ?? new GamingInput.KEYS();

        var source = e.Source;

        var isGamepad = source.HasFlag(InputSourceType.Gamepad); 

        KeyDown?.Invoke(new GamingInputArgs(key));

        return true;
        //return base.OnKeyDown(keyCode, e);
    }

    public override bool OnKeyUp([GeneratedEnum] Keycode keyCode, KeyEvent e)
    {

        var key = ConvertToKeyEnum?.Invoke(keyCode) ?? new GamingInput.KEYS();

        KeyUp?.Invoke(new GamingInputArgs(key));

        return true;
        //return base.OnKeyUp(keyCode, e);
    }

    public override bool OnGenericMotionEvent(MotionEvent e)
    {

        //if (e.Source == InputSourceType.Joystick)
        //    return base.OnGenericMotionEvent(e);

        
        // for analog sticks

        float xaxis = e.GetAxisValue(Axis.X);
        float yaxis = e.GetAxisValue(Axis.Y);



        //return true;
        return base.OnGenericMotionEvent(e);
    }


    

}
