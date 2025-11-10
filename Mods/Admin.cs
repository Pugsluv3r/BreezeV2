using BreezeV2.Classes.Admin;
using BreezeV2.Notifications;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using UnityEngine.Playables;
using static BreezeV2.Classes.Admin.Console;
using static BreezeV2.Menu.Main;
using BepInEx;
using Photon.Realtime;
using UnityEngine;

namespace BreezeV2.Mods
{
    internal class Admin
    {
        private static object Breeze;

        public static void Notifyall()
        {
            
            Classes.Admin.Console.ExecuteCommand("notify", ReceiverGroup.All, "Yeahippi");
        }
    }
}
