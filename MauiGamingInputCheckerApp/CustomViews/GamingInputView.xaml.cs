using MauiGamingInputCheckerApp.Models;
using System.Net;
using static MauiGamingInputCheckerApp.Models.GamingInput;

namespace MauiGamingInputCheckerApp.CustomViews;

public partial class GamingInputView : ContentView
{

    // bindable gaming input
    public static BindableProperty GamingInputProperty
        = BindableProperty.Create(nameof(Controller), typeof(GamingInput), typeof(GamingInputView), null);

    public GamingInput? Controller
    {
        get => (GamingInput)GetValue(GamingInputProperty);
        set
        {
            if (Controller != null)
            {
                var ControllerLast = Controller;
                ControllerLast.KeyDown -= KeyDown;
                ControllerLast.KeyUp -= KeyUp;
            }

            SetValue(GamingInputProperty, value);

            // Overwrite actions for animation
            Controller.KeyDown += KeyDown;
            Controller.KeyUp += KeyUp;

            // Update binding context
            BindingContext = Controller;
        }
    }

	public GamingInputView()
	{
		InitializeComponent();


        KEY_UP.Opacity= 0;
        KEY_DOWN.Opacity= 0;
        KEY_LEFT.Opacity= 0;
        KEY_RIGHT.Opacity= 0;
	}

	
	public void KeyDown(GamingInputArgs args) => KeyAnimate(args, true);
    public void KeyUp(GamingInputArgs args) => KeyAnimate(args, false);

    void KeyAnimate(GamingInputArgs args, bool IsHold)
    {
        if (args.IsPressed(KEYS.KEY_UP)) AnimateDpad(KEY_UP, IsHold);
        if (args.IsPressed(KEYS.KEY_DOWN)) AnimateDpad(KEY_DOWN, IsHold);
        if (args.IsPressed(KEYS.KEY_LEFT)) AnimateDpad(KEY_LEFT, IsHold);
        if (args.IsPressed(KEYS.KEY_RIGHT)) AnimateDpad(KEY_RIGHT, IsHold);

        if (args.IsPressed(KEYS.KEY_A)) AnimateActionButton(KEY_A, IsHold);
        if (args.IsPressed(KEYS.KEY_B)) AnimateActionButton(KEY_B, IsHold);
        if (args.IsPressed(KEYS.KEY_X)) AnimateActionButton(KEY_X, IsHold);
        if (args.IsPressed(KEYS.KEY_Y)) AnimateActionButton(KEY_Y, IsHold);

        if (args.IsPressed(KEYS.KEY_SELECT)) AnimateOption(KEY_SELECT, IsHold);
        if (args.IsPressed(KEYS.KEY_START)) AnimateOption(KEY_START, IsHold);

        if (args.IsPressed(KEYS.KEY_LEFTSHOULDER)) AnimateTrigger(KEY_L1, -1, IsHold);
        if (args.IsPressed(KEYS.KEY_RIGHTSHOULDER)) AnimateTrigger(KEY_R1, 1, IsHold);

    }

    // Image parts are same size as body, therefore the default anchor of animation is set to be origin.
    //
    //async void AnimateButton(VisualElement button)
    //{
    //    double initialScale = button.Scale;

    //    double activeScale = 1.5 * initialScale;

    //    // animation
    //    await button.ScaleTo(activeScale, 100);
    //    await Task.Delay(50); // Android needs this, but why?
    //    await button.ScaleTo(initialScale, 150);

    //}

    async void AnimateDpad(VisualElement dpad, bool IsHold)
    {
        if(IsHold) await dpad.FadeTo(100, 100);
        else await dpad.FadeTo(0, 50);
    }

    async void AnimateTrigger(VisualElement trigger, int direction, bool IsHold)
    {
        if(IsHold) await trigger.RotateTo(direction*10, 50);
        else await trigger.RotateTo(0, 100);
    }

    async void AnimateOption(VisualElement button, bool IsHold)
    {
        if(IsHold) await button.FadeTo(0, 100);
        else await button.FadeTo(100, 50);
    }

    async void AnimateActionButton(VisualElement button, bool IsHold)
    {
        if(IsHold) await button.FadeTo(0, 100);
        else await button.FadeTo(100, 50);
    }
}