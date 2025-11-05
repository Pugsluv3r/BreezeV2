using BreezeV2.Notifications;
using BreezeV2.Patches.Internal;
using GorillaLocomotion;
using Oculus.Platform;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace BreezeV2.Mods
{
    internal class Advantage
    {
        public static float range = 5f;
        public static float Notifdelay;
        public static void NotifyWhenLavaIsNear()
        {
            if (PhotonNetwork.InRoom)
            try
            {
                foreach (VRRig vRRig in GorillaParent.instance.vrrigs)
                    if (vRRig.isLocal)
                    {
                        float playerpos = UnityEngine.Vector3.Distance(vRRig.bodyTransform.position, GTPlayer.Instance.transform.position);
                        if (playerpos < range) 
                            if (Time.time > Notifdelay)
                                if (((GorillaTagManager)GorillaGameManager.instance).currentInfected.Contains(vRRig.Creator))
                            {
                                Notifdelay = Time.time + 0.6f;
                                NotifiLib.SendNotification("<color=purple>[WARNING]</color> Lava near you");
                            }
                    }
            }
            catch { } // no reason
        }
       public static void RaiseFov(float amount)
        {

            GTPlayer.Instance.mainCamera.fieldOfView = amount;
        }
    }
}
