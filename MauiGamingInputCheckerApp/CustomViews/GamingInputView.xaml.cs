using MauiGamingInputCheckerApp.Models;
using System.Net;

namespace MauiGamingInputCheckerApp.CustomViews;

public partial class GamingInputView : ContentView
{
	public GamingInputView()
	{
		InitializeComponent();

        KEY_UP.Opacity= 0;
        KEY_DOWN.Opacity= 0;
        KEY_LEFT.Opacity= 0;
        KEY_RIGHT.Opacity= 0;
	}

	
	public void KeyDown(GamingInputArgs args)
	{
        switch (args.Keys)
        {
            case GamingInput.KEYS.KEY_UP: AnimateDpad(KEY_UP); break;
            case GamingInput.KEYS.KEY_DOWN: AnimateDpad(KEY_DOWN); break;
            case GamingInput.KEYS.KEY_LEFT: AnimateDpad(KEY_LEFT); break;
            case GamingInput.KEYS.KEY_RIGHT: AnimateDpad(KEY_RIGHT); break;

            case GamingInput.KEYS.KEY_Y: AnimateActionButton(KEY_Y); break;
            case GamingInput.KEYS.KEY_A: AnimateActionButton(KEY_A); break;
            case GamingInput.KEYS.KEY_B: AnimateActionButton(KEY_B); break;
            case GamingInput.KEYS.KEY_X: AnimateActionButton(KEY_X); break;

            case GamingInput.KEYS.KEY_SELECT: AnimateOption(KEY_SELECT); break;
            case GamingInput.KEYS.KEY_START: AnimateOption(KEY_START); break;

            case GamingInput.KEYS.KEY_LEFTSHOULDER: AnimateTrigger(KEY_L1, -1); break;
            case GamingInput.KEYS.KEY_RIGHTSHOULDER: AnimateTrigger(KEY_R1, 1); break;
        }
    }

    // Image parts are same size as body, therefore the default anchor of animation is set to be origin.
    //
    async void AnimateButton(VisualElement button)
    {
        double initialScale = button.Scale;

        double activeScale = 1.5 * initialScale;

        // animation
        await button.ScaleTo(activeScale, 100);
        await Task.Delay(50); // Android needs this, but why?
        await button.ScaleTo(initialScale, 150);

    }

    async void AnimateDpad(VisualElement dpad)
    {
        await dpad.FadeTo(100, 100);
        await dpad.FadeTo(0, 50);
    }

    async void AnimateTrigger(VisualElement trigger, int direction)
    {
        await trigger.RotateTo(direction*10, 50);
        await trigger.RotateTo(0, 100);
    }

    async void AnimateOption(VisualElement button)
    {
        await button.FadeTo(0, 100);
        await button.FadeTo(100, 50);
    }

    async void AnimateActionButton(VisualElement button)
    {
        await button.FadeTo(0, 100);
        await button.FadeTo(100, 50);
    }
}