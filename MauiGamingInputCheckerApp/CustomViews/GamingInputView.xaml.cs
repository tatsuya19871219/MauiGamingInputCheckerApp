using MauiGamingInputCheckerApp.Models;
using System.Net;

namespace MauiGamingInputCheckerApp.CustomViews;

public partial class GamingInputView : ContentView
{
	public GamingInputView()
	{
		InitializeComponent();
	}

	
	public void KeyDown(GamingInputArgs args)
	{
        switch (args.Keys)
        {
            case GamingInput.KEYS.KEY_UP: AnimateButton(KEY_UP); break;
            case GamingInput.KEYS.KEY_DOWN: AnimateButton(KEY_DOWN); break;
            case GamingInput.KEYS.KEY_LEFT: AnimateButton(KEY_LEFT); break;
            case GamingInput.KEYS.KEY_RIGHT: AnimateButton(KEY_RIGHT); break;

            case GamingInput.KEYS.KEY_Y: AnimateButton(KEY_1); break;
            case GamingInput.KEYS.KEY_A: AnimateButton(KEY_2); break;
            case GamingInput.KEYS.KEY_B: AnimateButton(KEY_3); break;
            case GamingInput.KEYS.KEY_X: AnimateButton(KEY_4); break;

            case GamingInput.KEYS.KEY_SELECT: AnimateButton(KEY_VIEW); break;
            case GamingInput.KEYS.KEY_START: AnimateButton(KEY_MENU); break;

            case GamingInput.KEYS.KEY_LEFTSHOULDER: AnimateButton(KEY_LEFTSHOULDER); break;
            case GamingInput.KEYS.KEY_RIGHTSHOULDER: AnimateButton(KEY_RIGHTSHOULDER); break;
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
}