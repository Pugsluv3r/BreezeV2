using GorillaLocomotion;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static BreezeV2.Classes.RigManager;
using static BreezeV2.Classes.SimpleInputs;

namespace BreezeV2.Mods
{
    internal class Overpowered
    {
        public static void Fling()
        {
            if (LeftX)
            {
                GTPlayer.Instance.RightHand.controllerTransform.localPosition = new Vector3(0, -235f, 0f);
                GTPlayer.Instance.LeftHand.controllerTransform.localPosition = new Vector3(0, -235f, 0f);
            }
        }

        public static void RandomTpPlayer()
        {
            if (LeftX)
            {
                GTPlayer.Instance.RightHand.controllerTransform.localPosition = new Vector3(0, 0, 999f);
                GTPlayer.Instance.LeftHand.controllerTransform.localPosition = new Vector3(0, 0, 999f);
            }
        }
        public static async void BetterFling()
        {
            if (LeftX)
            {
                GTPlayer.Instance.RightHand.controllerTransform.localPosition = new Vector3(0, -235f, 0f);
                GTPlayer.Instance.LeftHand.controllerTransform.localPosition = new Vector3(0, -235f, 0f);
                await System.Threading.Tasks.Task.Delay(5);
                //nuh uh
                await System.Threading.Tasks.Task.Delay(2);
                //Nuh uh

                // Once again, wait for the full menu like good bois :3
            }
        }
    }
}
