using MauiGamingInputCheckerApp.Models;
using MauiGamingInputCheckerApp.Services;
using Microsoft.Maui.Controls.Shapes;

namespace MauiGamingInputCheckerApp;

public partial class MainPage : ContentPage
{

	GamingInputService? _service;
	List<GamingInput>? _controllers;
	
	public MainPage()
	{
		InitializeComponent();

		InitializeGamingInputService();

	}


	async void InitializeGamingInputService()
	{
		_service = new GamingInputService();

		StatusLabel.Text = "No controller device is detected yet.";

		while(true)
		{
			if (_service.GamingInputs is not null) break;
			await Task.Delay(100);
		}

		_controllers = _service.GamingInputs;

		foreach(var controller in _controllers)
		{
            controller.KeyDown += KeyDownEvent;
			controller.KeyUp += KeyUpEvent;
        }

		ControllerSelectSlider.Maximum = (double)_controllers.Count;

		if (_controllers.Count == 1)
		{
            StatusLabel.Text = $"Controller is detected.";

			ControllerSelectSlider.IsEnabled = false;
        }
        else
		{
            StatusLabel.Text = $"{_controllers.Count} controllers are detected.";

        }
    }


	void KeyDownEvent(GamingInputArgs args) => MyInput.KeyDown(args);
	void KeyUpEvent(GamingInputArgs args) => MyInput.KeyUp(args);


    //
    protected override void OnSizeAllocated(double width, double height)
    {
		double density = DeviceDisplay.Current.MainDisplayInfo.Density;

		// resize buttons
		//foreach(VisualElement button in ControllerGUIButtons.Children)
		//{
		//	button.Scale /= density;
		//	button.TranslationX /= density;
		//	button.TranslationY /= density;
		//}

//#if WINDOWS
//		ControllerGUIContainer.Scale = 1;
//#elif ANDROID
//		ControllerGUIContainer.Scale = 2;
//#endif

		base.OnSizeAllocated(width, height);
    }
}

