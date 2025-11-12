using BreezeV2.Notifications;
using BreezeV2.Patches.Internal;
using GorillaExtensions;
using GorillaLocomotion;
using GorillaTag.DebugTools;
using HarmonyLib;
using Oculus.Platform;
using Photon.Pun;
using System;
using System.Collections.Generic;
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
      
        public static void Tracers()
        {
            if (!PhotonNetwork.InRoom)
            {
                foreach (VRRig vRRig in GorillaParent.instance.vrrigs)
                {
                    if (VRRig.LocalRig.isLocal)
                        continue;


                    LineRenderer tracer = Camera.current.gameObject.GetComponent<LineRenderer>();
                    if (tracer == null)
                    {
                        tracer = Camera.current.gameObject.AddComponent<LineRenderer>();
                    }

                    tracer.startWidth = 0.01f;
                    tracer.endWidth = 0.01f;
                    tracer.positionCount = 2;
                    tracer.material.color = Color.ghostWhite;
                    tracer.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                    tracer.SetPosition(1, vRRig.bodyTransform.position);
                } // can someone please fix ts
            }
        }
        public static void RemoveFlicklimit()
        {
            GorillaTagger.Instance.maxTagDistance = 2.5f; // this may be detected by anti-cheat mb /:
        }

        public static void BoxEsp()
        {
            foreach (VRRig vRRig in GorillaParent.instance.vrrigs)
            {
                GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (VRRig.LocalRig.isLocal)
                    continue;
                {
                    //not yet implemented
                }
            }
        }


    }
}

