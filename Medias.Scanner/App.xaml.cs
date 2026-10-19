using Medias.Scanner.Pages;

namespace Medias.Scanner;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        //MainPage = new NavigationPage(new ScannerPage());
        return new Window(new AppShell());
    }
}