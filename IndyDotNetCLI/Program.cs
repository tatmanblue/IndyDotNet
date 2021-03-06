﻿using System;
using Terminal.Gui;

using IndyDotNetCLI.Views;
using NLog.Config;
using NLog.Targets;

namespace IndyDotNetCLI
{
    class Program
    {
        private static Window _mainWindow = null;
        private static Label _poolStatus = new Label(3, 2, "Pool: not open");
        private static Label _walletStatus = new Label(3, 4, "Wallet: not open");
        private static Label _didStatus = new Label(3, 6, "Did: none");

        private static PoolHandler _poolHanlder = new PoolHandler();

        static bool ConfirmQuit()
        {
            var n = MessageBox.Query(50, 7, "Quit IndyDotNetCLI", "Are you sure you want to quit?", "Yes", "No");
            return n == 0;
        }

        static void InitializeLogging()
        {
            var config = new LoggingConfiguration();
            var debuggerTarget = new DebuggerTarget("debugger")
            {
                Layout = @"${date:format=HH\:mm\:ss} ${level} ${message} ${exception}"
            };
            config.AddTarget(debuggerTarget);
            config.AddRuleForAllLevels(debuggerTarget);
            IndyDotNet.Utils.Logger.Init();
        }

        static void Main(string[] args)
        {


            try
            {
                InitializeLogging();
                IndyDotNet.Utils.Logger.Info("application started");

                Application.Init();
                Toplevel top = Application.Top;

                _mainWindow = new Window(new Rect(0, 1, top.Frame.Width, top.Frame.Height - 1), "IndyDotNet Command Line");
                top.Add(_mainWindow);

                MenuBar menu = new MenuBar(new MenuBarItem[] 
                {
                    new MenuBarItem ("_Application", new MenuItem [] 
                        {
                            new MenuItem ("_Quit", "", () => { if (ConfirmQuit ()) top.Running = false; })
                        }),
                        _poolHanlder.CreateMenu()
                });
                top.Add(menu);

                _mainWindow.Add(
                    _poolStatus,
                    _walletStatus,
                    _didStatus,
                    new Label(3, top.Frame.Height - 5, "Press ESC and 9 to activate the menubar"),
                    new Label(3, top.Frame.Height - 6, System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
                );

                Application.Run();
                IndyDotNet.Utils.Logger.Info("application ended");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Fatal Exception kills process: {ex.Message}";
                // since this is a console app, force output to the console because the app is terminating anyways.
                // this will ensure users have a chance to see the error regardless of logging
                Console.WriteLine(errorMessage);
                // and follow through with logger, which could possible blow up :(
                IndyDotNet.Utils.Logger.Error(errorMessage);
            }
        }
    }
}
