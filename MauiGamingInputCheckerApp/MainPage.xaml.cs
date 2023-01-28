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

		while(true)
		{
			if (_service.GamingInputs is not null) break;
			await Task.Delay(100);
		}

		_controllers = _service.GamingInputs;

		// for test
		_controllers[0].KeyDown += KeyDownEvent;
	}


	void KeyDownEvent(GamingInputArgs args)
	{
		switch(args.Keys)
		{
            case GamingInput.KEYS.KEY_UP: AnimateButton(KEY_UP); break;
			case GamingInput.KEYS.KEY_DOWN: AnimateButton(KEY_DOWN); break;
			case GamingInput.KEYS.KEY_LEFT: AnimateButton(KEY_LEFT); break;
			case GamingInput.KEYS.KEY_RIGHT: AnimateButton(KEY_RIGHT); break;

            case GamingInput.KEYS.KEY_1: AnimateButton(KEY_1); break;
            case GamingInput.KEYS.KEY_2: AnimateButton(KEY_2); break;
            case GamingInput.KEYS.KEY_3: AnimateButton(KEY_3); break;
            case GamingInput.KEYS.KEY_4: AnimateButton(KEY_4); break;
        }
    }

	async void AnimateButton(Ellipse ellipse)
	{
		await ellipse.ScaleTo(1.5, 100);
		await ellipse.ScaleTo(1.0, 150);
	}
}

