using MauiGamingInputCheckerApp.Models;
using MauiGamingInputCheckerApp.Services;

namespace MauiGamingInputCheckerApp;

public partial class MainPage : ContentPage
{

    GamingInputService? _service;

    List<GamingInput>? _controllers;

    public MainPage()
    {
        InitializeComponent();

        InitializeGamingInputService();

#if WINDOWS
        DummyEntryForFocusing.IsVisible = false;
#elif ANDROID
        InitializeFocus();
#endif

    }


    async void InitializeFocus()
    {
        while (true)
        {
            if (MyLayout.Handler != null) break;
            await Task.Delay(100);
        }

        MyLayout.Focus();
    }


    async void InitializeGamingInputService()
    {
        _service = new GamingInputService();

        StatusLabel.Text = "No controller device is detected yet.";

        while (true)
        {
            if (_service.GamingInputs is not null) break;
            await Task.Delay(100);
        }

        _controllers = _service.GamingInputs;

        ControllerSelector.IsVisible = true;
        ControllerSelectStepper.Minimum = 1;
        ControllerSelectStepper.Value = 1;

        if (_controllers.Count > 1)
        {
            ControllerSelectStepper.Maximum = _controllers.Count;

            ControllerSelectStepper.IsEnabled = true;
        }


        if (_controllers.Count == 1) StatusLabel.Text = $"Controller is detected.";
        else StatusLabel.Text = $"{_controllers.Count} controllers are detected.";

    }

    //
    protected override void OnSizeAllocated(double width, double height)
    {
        double density = DeviceDisplay.Current.MainDisplayInfo.Density;

        base.OnSizeAllocated(width, height);
    }

    private void ControllerSelectStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        for (int k = 0; k < _controllers.Count; k++)
        {
            //if(e.OldValue == k+1) _controllers[k].Disable();
            if (e.NewValue == k + 1)
            {
                //_controllers[k].Enable();
                MyInput.Controller = _controllers[k];
            }
            //else _controllers[k].Disable();
        }
    }


    //  //
    //  protected override void OnHandlerChanged()
    //  {
    //      base.OnHandlerChanged();

    ////this.Focus();
    //MyLayout.Focus();
    //  }
}

