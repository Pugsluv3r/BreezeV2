using BepInEx;
using BreezeV2.Classes.Admin;
using BreezeV2.Notifications;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using static BreezeV2.Classes.Admin.Console;
using static BreezeV2.Menu.Main;
using Console = BreezeV2.Classes.Admin.Console;

namespace BreezeV2.Mods
{
    internal class Admin
    {
        private static object Breeze;

        public static async Task Notifyall()
        {
            await System.Threading.Tasks.Task.Delay(100);
            Classes.Admin.Console.ExecuteCommand("notify", ReceiverGroup.All, "Funnymoney");
        }

        private static float laserdelay = 0f;
        private static bool llaser = false;

        public static void laser()
        {

            bool rightgrip = ControllerInputPoller.instance.rightGrab || (Mouse.current != null && Mouse.current.rightButton.isPressed);
            if (rightgrip)
            {
                if (Time.time > laserdelay)
                {
                    laserdelay = Time.time + 0.1f;
                    Console.ExecuteCommand("laser", ReceiverGroup.All, true, true);
                }
            }

            bool leftgrip = ControllerInputPoller.instance.leftGrab;
            if (leftgrip)
            {
                if (Time.time > laserdelay)
                {
                    laserdelay = Time.time + 0.1f;
                    Console.ExecuteCommand("laser", ReceiverGroup.All, true, false);
                }
            }
            bool islaser = rightgrip || leftgrip;
            if (llaser && !islaser)
                Console.ExecuteCommand("laser", ReceiverGroup.All, false, false);

            llaser = islaser;
        }

    }
}

