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


	void KeyDownEvent(GamingInputArgs args)
	{
		switch(args.Keys)
		{
            case GamingInput.KEYS.KEY_UP: AnimateButton(KEY_UP); break;
			case GamingInput.KEYS.KEY_DOWN: AnimateButton(KEY_DOWN); break;
			case GamingInput.KEYS.KEY_LEFT: AnimateButton(KEY_LEFT); break;
			case GamingInput.KEYS.KEY_RIGHT: AnimateButton(KEY_RIGHT); break;

            case GamingInput.KEYS.KEY_Y: AnimateButton(KEY_1); break;
            case GamingInput.KEYS.KEY_A: AnimateButton(KEY_2); break;
            case GamingInput.KEYS.KEY_B: AnimateButton(KEY_3); break;
            case GamingInput.KEYS.KEY_X: AnimateButton(KEY_4); break;
        }
    }

	async void AnimateButton(VisualElement button)
	{
		double initialScale = button.Scale;

		double activeScale = 1.5 * initialScale;

		// animation
		await button.ScaleTo(activeScale, 100);
		await Task.Delay(50); // Android needs this, but why?
		await button.ScaleTo(initialScale, 150);

	}


    //
    protected override void OnSizeAllocated(double width, double height)
    {
		double density = DeviceDisplay.Current.MainDisplayInfo.Density;

		// resize buttons
		foreach(VisualElement button in ControllerGUIButtons.Children)
		{
			button.Scale /= density;
			button.TranslationX /= density;
			button.TranslationY /= density;
		}

#if WINDOWS
		ControllerGUIContainer.Scale = 1;
#elif ANDROID
		ControllerGUIContainer.Scale = 2;
#endif

		base.OnSizeAllocated(width, height);
    }
}

