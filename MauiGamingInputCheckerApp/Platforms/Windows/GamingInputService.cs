using MauiGamingInputCheckerApp.Models;
using Windows.Gaming.Input;

namespace MauiGamingInputCheckerApp.Services;

public partial class GamingInputService
{

    int _samplingInterval = 10;

    async private partial Task<List<GamingInput>> GetGamingInputsAsync()
    {

        List<Gamepad> gamepads = new();
        List<GamingInput> gamingInputs = new();

        while (true)
        {
            if (Gamepad.Gamepads.Count > 0) break;
            await Task.Delay(100);
        }

        int id = 0;

        foreach (var gamepad in Gamepad.Gamepads)
        {
            gamepads.Add(gamepad);

            var gamingInput = new GamingInput();

            gamingInput.SetDeviceID(++id);
            gamingInput.SetDeviceName($"Gamepad #{id}");

            gamingInputs.Add(gamingInput);
        }

        for (int k = 0; k < gamepads.Count; k++)
        {
            EvokeService(gamepads[k], gamingInputs[k]);
        }


        return gamingInputs;
    }

    async void EvokeService(Gamepad gamepad, GamingInput gamingInput)
    {

        GamepadReading lastReading = new();

        while (true)
        {
            var currentReading = gamepad.GetCurrentReading();

            var lastButtons = lastReading.Buttons;
            var currentButtons = currentReading.Buttons;

            if (currentButtons.Equals(lastButtons))
            {
                // nop
            }
            else
            {
                // separate key-down buttons & key-up buttons
                var currentDetectedButtons = ~lastButtons & currentButtons;
                var lastDetectedButtons = lastButtons & ~currentButtons;

                gamingInput.OnKeyUp(new GamingInputArgs(ConvertToKeyEnum(lastDetectedButtons)));
                gamingInput.OnKeyDown(new GamingInputArgs(ConvertToKeyEnum(currentDetectedButtons)));
            }

            await Task.Delay(_samplingInterval);

            lastReading = currentReading;
        }

    }

    GamingInput.KEYS ConvertToKeyEnum(GamepadButtons buttons)
    {

        GamingInput.KEYS keys = new();

        if (buttons.HasFlag(GamepadButtons.DPadUp)) keys |= GamingInput.KEYS.KEY_UP;
        if (buttons.HasFlag(GamepadButtons.DPadDown)) keys |= GamingInput.KEYS.KEY_DOWN;
        if (buttons.HasFlag(GamepadButtons.DPadLeft)) keys |= GamingInput.KEYS.KEY_LEFT;
        if (buttons.HasFlag(GamepadButtons.DPadRight)) keys |= GamingInput.KEYS.KEY_RIGHT;

        if (buttons.HasFlag(GamepadButtons.A)) keys |= GamingInput.KEYS.KEY_A;
        if (buttons.HasFlag(GamepadButtons.B)) keys |= GamingInput.KEYS.KEY_B;
        if (buttons.HasFlag(GamepadButtons.X)) keys |= GamingInput.KEYS.KEY_X;
        if (buttons.HasFlag(GamepadButtons.Y)) keys |= GamingInput.KEYS.KEY_Y;

        if (buttons.HasFlag(GamepadButtons.LeftShoulder)) keys |= GamingInput.KEYS.KEY_LEFTSHOULDER;
        if (buttons.HasFlag(GamepadButtons.RightShoulder)) keys |= GamingInput.KEYS.KEY_RIGHTSHOULDER;

        if (buttons.HasFlag(GamepadButtons.Menu)) keys |= GamingInput.KEYS.KEY_START;
        if (buttons.HasFlag(GamepadButtons.View)) keys |= GamingInput.KEYS.KEY_SELECT;

        return keys;
    }

}
