﻿using System;
using Terminal.Gui;
using IndyDotNet.Pool;

namespace IndyDotNetCLI.Views
{
    public class PoolHandler
    {
        public PoolHandler()
        { }

        public MenuBarItem CreateMenu()
        {
            return new MenuBarItem("_Pool", new MenuItem[] {
                new MenuItem ("_Create", "", () => { CreatePool(); }),
                new MenuItem ("_Open", "", () => { OpenPool(); }),
                new MenuItem ("_Close", "", () => { ClosePool(); })
            });
        }

        private void CreatePool() 
        {
            try
            {
                IPool pool = Factory.GetPool("name");
                pool.Create();
            }
            catch(Exception ex)
            {
                MessageBox.Query(70, 7, "Pool Create Failed", $"Error: {ex.Message}", "Ok");
            }
        }

        private void OpenPool() 
        {
            MessageBox.Query(50, 7, "Menu Selected", "Open", "Yes");
        }

        private void ClosePool()
        {
            MessageBox.Query(50, 7, "Menu Selected", "Close", "Yes");
        }

    }
}
