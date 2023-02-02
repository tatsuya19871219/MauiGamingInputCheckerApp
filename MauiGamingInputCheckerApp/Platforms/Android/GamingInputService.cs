using Android.Views;
using MauiGamingInputCheckerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiGamingInputCheckerApp.Services;

public partial class GamingInputService
{
    async private partial Task<List<GamingInput>> GetGamingInputsAsync()
    {

        List<InputDevice> gamepads = new();
        List<GamingInput> gamingInputs = new();

        while (true)
        {

            

            int[] deviceIds = InputDevice.GetDeviceIds();

            foreach (int deviceId in deviceIds)
            {
                InputDevice device = InputDevice.GetDevice(deviceId);

                // for test
                switch (device.Name) 
                {
                    case "SNES Controller":
                    case "Xbox Wireless Controller":
                    case "Razer Kishi":

                        gamepads.Add(device);
                        break;

                    default: 
                        
                        break;
                }

            }
            
            if (gamepads.Count > 0) break;

            await Task.Delay(100);
        }

        foreach (var gamepad in gamepads)
        {

            var gamingInput = new GamingInput();

            gamingInput.SetDeviceID(gamepad.Id);

            gamingInputs.Add(gamingInput);
        }

        for (int k = 0; k < gamepads.Count; k++)
        {
            EvokeService(gamepads[k], gamingInputs[k]);
        }

        return gamingInputs;
    }


    async void EvokeService(InputDevice gamepad, GamingInput gamingInput)
    {

        MainActivity activity = MainActivity.Instance;

        activity.ConvertToKeyEnum += ConvertToKeyEnum;
        activity.KeyDown += gamingInput.OnKeyDown;
        activity.KeyUp += gamingInput.OnKeyUp;

    }

    GamingInput.KEYS ConvertToKeyEnum(Keycode keycode)
    {

        switch (keycode)
        {
            case Keycode.DpadUp: return GamingInput.KEYS.KEY_UP;
            case Keycode.DpadDown: return GamingInput.KEYS.KEY_DOWN;
            case Keycode.DpadLeft: return GamingInput.KEYS.KEY_LEFT;
            case Keycode.DpadRight: return GamingInput.KEYS.KEY_RIGHT;

            case Keycode.ButtonY: return GamingInput.KEYS.KEY_Y;
            case Keycode.ButtonA: return GamingInput.KEYS.KEY_A;
            case Keycode.ButtonB: return GamingInput.KEYS.KEY_B;
            case Keycode.ButtonX: return GamingInput.KEYS.KEY_X;

            case Keycode.ButtonL1: return GamingInput.KEYS.KEY_LEFTSHOULDER;
            case Keycode.ButtonR1: return GamingInput.KEYS.KEY_RIGHTSHOULDER;

            case Keycode.ButtonStart: return GamingInput.KEYS.KEY_START;
            case Keycode.ButtonSelect: return GamingInput.KEYS.KEY_SELECT;
        }

        return GamingInput.KEYS.None;
    }
}
