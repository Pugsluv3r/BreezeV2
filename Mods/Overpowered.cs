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
                GTPlayer.Instance.RightHand.controllerTransform.position = new Vector3(0, -299f, 0);
                GTPlayer.Instance.LeftHand.controllerTransform.position = new Vector3(0, -299f, 0);
            }
        }
        #region PrivateMethods
        public static void RandomTpPlayer()
        {
            if (LeftX)
            {
                GTPlayer.Instance.RightHand.controllerTransform.localPosition = new Vector3(0, 0, 999f);
                GTPlayer.Instance.LeftHand.controllerTransform.localPosition = new Vector3(0, 0, 999f);
            }
        }
        #endregion
    }
}
