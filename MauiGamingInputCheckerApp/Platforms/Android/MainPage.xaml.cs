namespace MauiGamingInputCheckerApp;

public partial class MainPage : ContentPage
{
    async partial void InitializePlatformSpecificSettings()
    {
        while(true)
        {
            if (this.Handler != null) break;
            await Task.Delay(100);
        }

        var view = this.Handler.PlatformView as Android.Views.View;


        //while(true)
        //{
        //    MyLayout.Focus();
        //    await Task.Delay(1000);
        //}
    }

}

