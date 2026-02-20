using BreezeV2.Notifications;
using BreezeV2.Patches.Internal;
using Fusion.LagCompensation;
using GorillaExtensions;
using GorillaLocomotion;
using GorillaTag.DebugTools;
using HarmonyLib;
using Oculus.Platform;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.ProBuilder.Shapes;
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
                        if (vRRig.isLocal && ((GorillaTagManager)GorillaGameManager.instance).isCurrentlyTag == false) 
                        {
                            float playerpos = UnityEngine.Vector3.Distance(vRRig.bodyTransform.position, GTPlayer.Instance.transform.position);
                            if (playerpos < range)
                                if (Time.time > Notifdelay)
                                    if (((GorillaTagManager)GorillaGameManager.instance).currentInfected.Contains(vRRig.Creator))
                                    {
                                        Notifdelay = Time.time + 2f;
                                        NotifiLib.SendNotification("<color=purple>[WARNING]</color> Lava near you");
                                    }

                        }
                    if (VRRig.LocalRig.isLocal &&((GorillaTagManager)GorillaGameManager.instance).isCurrentlyTag == false)
                    {
                        return;
                        
                    }
                }
                catch { } // no reason

        }
        public static void RemoveFlicklimit()
        {
            GorillaTagger.Instance.maxTagDistance = 2.5f; // this may be detected by anti-cheat mb /:
        }
    }
};
