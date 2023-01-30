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

    ////public override bool OnKeyLongPress([GeneratedEnum] Keycode keyCode, KeyEvent e)
    ////{
    ////    return true;
    ////    //return base.OnKeyLongPress(keyCode, e);
    ////}

    ////public override bool OnKeyMultiple([GeneratedEnum] Keycode keyCode, int repeatCount, KeyEvent e)
    ////{
    ////    return true;
    ////    //return base.OnKeyMultiple(keyCode, repeatCount, e);
    ////}

    ////public override bool OnKeyShortcut([GeneratedEnum] Keycode keyCode, KeyEvent e)
    ////{
    ////    return true;
    ////    //return base.OnKeyShortcut(keyCode, e);
    ////}


    ////public override void TakeKeyEvents(bool get)
    ////{
    ////    base.TakeKeyEvents(get);
    ////}

    ////public override bool DispatchKeyEvent(KeyEvent e)
    ////{
    ////    // Unfocused(or disabled?) before calling this event
    ////    return base.DispatchKeyEvent(e);
    ////}

    ////public override bool DispatchKeyShortcutEvent(KeyEvent e)
    ////{
    ////    return base.DispatchKeyShortcutEvent(e);
    ////}

    ////public override bool SuperDispatchKeyEvent(KeyEvent e)
    ////{
    ////    return base.SuperDispatchKeyEvent(e);
    ////}

    //public override bool DispatchGenericMotionEvent(MotionEvent ev)
    //{
    //    //return true;
    //    return base.DispatchGenericMotionEvent(ev);
    //}

    public override bool OnGenericMotionEvent(MotionEvent e)
    {

        //KeyEvent keyEvent = new(e.DownTime, e.EventTime, e.ActionIndex);
        

        //return true;
        return base.OnGenericMotionEvent(e);
    }
}
