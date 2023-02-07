# MauiGamingInputCheckerApp
An application for checking game controllers (gamepads) to confirm button operation.

![Controller image](./images/controller_fullcomponent.svg)

## Files edited

 - CustomViews/
     - [GamingInputView.xaml](./MauiGamingInputCheckerApp/CustomViews/GamingInputView.xaml)
     - [GamingInputView.xaml.cs](./MauiGamingInputCheckerApp/CustomViews/GamingInputView.xaml.cs)
 - Models/
     - [GamingInput.cs](./MauiGamingInputCheckerApp/Models/GamingInput.cs)
     - [GamingInputArgs.cs](./MauiGamingInputCheckerApp/Models/GamingInputArgs.cs)
 - Platforms/
     - Android/
         - [GamingInputService.cs](./MauiGamingInputCheckerApp/Platforms/Android/GamingInputService.cs)
         - [MainActivity.cs](./MauiGamingInputCheckerApp/Platforms/Android/MainActivity.cs)
     - Windows/
         - [GamingInputService.cs](./MauiGamingInputCheckerApp/Platforms/Windows/GamingInputService.cs)
 - Resources/
     - Images/
         - Controller/
 - Services/
     - [GamingInputService.cs](./MauiGamingInputCheckerApp/Services/GamingInputService.cs)
 - [MainPage.xaml](./MauiGamingInputCheckerApp/MainPage.xaml)
 - [MainPage.xaml.cs](./MauiGamingInputCheckerApp/MainPage.xaml.cs)

## What I learnt from this project

- How to access input devices (in different platforms)
- How to debug remotely on Android
- How to draw simple shapes in Inkscape
- Basic ways to work with Visual studio and Github
- Breakpoint debugging in Visual studio
- How to use Enum with Flags attribute

## Known Issues

- ~~Page view turns darker after generic motion event triggered by directional keys or left analog stick~~
- ~~Animation of right shoulder (Path) shows unexpected behavior (off-centered)~~

## TODO

- [x] Multiple controllers support 
- [ ] Analog sticks support
- [ ] Switch controllers support