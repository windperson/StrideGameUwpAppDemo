using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Stride.Engine;
using Stride.Games;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestGameMainPage : Page
    {
        Game Game;

        public TestGameMainPage()
        {
            this.InitializeComponent();
            
            Game = new Game();
            Game.UnhandledException += Game_UnhandledException;
            Game.Run(new GameContextUWPXaml(SwapChainPanel));
        }

        private async void Game_UnhandledException(object sender, GameUnhandledExceptionEventArgs e)
        {
            // If something went wrong (i.e. GPU feature level is not enough), display an error message instead of crashing to properly pass certifications
            var exception = e.ExceptionObject as Exception;
            if (exception != null)
            {
                // Display error message
                var messageDialog = new MessageDialog(exception.Message);
                await messageDialog.ShowAsync();

                // Exit application
                Application.Current.Exit();
            }
        }
    }
}
