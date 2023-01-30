using MauiGamingInputCheckerApp.Models;
using Windows.Gaming.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Certificates;

namespace MauiGamingInputCheckerApp.Services;

public partial class GamingInputService
{

    int _samplingInterval = 100;

    async private partial Task<List<GamingInput>> GetGamingInputsAsync()
    {

        List<Gamepad> gamepads = new();
        List<GamingInput> gamingInputs = new();

        while (true)
        {
            if (Gamepad.Gamepads.Count > 0) break;
            await Task.Delay(1000);
        }


        foreach(var gamepad in Gamepad.Gamepads)
        {
            gamepads.Add(gamepad);

            var gamingInput = new GamingInput();

            gamingInputs.Add(gamingInput);
        }

        for(int k = 0; k < gamepads.Count; k++)
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

            if (currentReading.Equals(lastReading))
            {
                // no input or long input
                if (currentReading.Equals(new GamepadReading()))
                {
                    // no input
                }
                else
                {
                    // long input && no additional input
                }
            }
            else
            {
                // key down or key up
                var lastButtons = lastReading.Buttons;
                var currentButtons = currentReading.Buttons;

                if (lastButtons.Equals(GamepadButtons.None))
                {
                    // key down
                    gamingInput.OnKeyDown(new GamingInputArgs(ConvertToKeyEnum(currentButtons)));
                }
                else
                {
                    // key up
                    gamingInput.OnKeyUp(new GamingInputArgs(ConvertToKeyEnum(currentButtons)));
                }
            }

            await Task.Delay(_samplingInterval);

            lastReading = currentReading;
        }

    }

    GamingInput.KEYS ConvertToKeyEnum(GamepadButtons buttons)
    {
        switch(buttons)
        {
            case GamepadButtons.DPadUp: return GamingInput.KEYS.KEY_UP;
            case GamepadButtons.DPadDown: return GamingInput.KEYS.KEY_DOWN;
            case GamepadButtons.DPadLeft: return GamingInput.KEYS.KEY_LEFT;
            case GamepadButtons.DPadRight: return GamingInput.KEYS.KEY_RIGHT;

            case GamepadButtons.Y: return GamingInput.KEYS.KEY_Y;
            case GamepadButtons.A: return GamingInput.KEYS.KEY_A;
            case GamepadButtons.B: return GamingInput.KEYS.KEY_B;
            case GamepadButtons.X: return GamingInput.KEYS.KEY_X;

            case GamepadButtons.LeftShoulder: return GamingInput.KEYS.KEY_LEFTSHOULDER;
            case GamepadButtons.RightShoulder: return GamingInput.KEYS.KEY_RIGHTSHOULDER;

            case GamepadButtons.Menu: return GamingInput.KEYS.KEY_START;
            case GamepadButtons.View: return GamingInput.KEYS.KEY_SELECT;
        }

        return GamingInput.KEYS.None;
    }
}
