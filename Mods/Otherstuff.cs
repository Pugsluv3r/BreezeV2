using BepInEx;
using BreezeV2.Menu;
using GorillaLocomotion;
using NanoSockets;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using static BreezeV2.Menu.Main;

namespace BreezeV2.Mods
{
    internal class Otherstuff
    {
        public static GameObject messageofthedih;
        private static List<TextMeshPro> udTMP = new List<TextMeshPro>();

        //Lastshootshizzzy
        private static float lastShootTime = 0f;
        private static bool canShoot = true;

        public static void Customboards()
        {
            if (messageofthedih == null)
            {
                GameObject motdObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdHeadingText");
                messageofthedih = UnityEngine.Object.Instantiate(motdObject, motdObject.transform.parent);
                motdObject.SetActive(false);
            }

            TextMeshPro motdTc = messageofthedih.GetComponent<TextMeshPro>();
            if (!udTMP.Contains(motdTc))
                udTMP.Add(motdTc);

            motdTc.richText = true;
            motdTc.fontSize = 70;
            motdTc.text = "Breeze V3!";

        }
        public static void Eyerockcusp()
        {
            Breeze["Stop using mod checkers they are stupid"] = "";
            PhotonNetwork.SetPlayerCustomProperties(Breeze);
        }
        private static ExitGames.Client.Photon.Hashtable Breeze = PhotonNetwork.LocalPlayer.CustomProperties;

        public static void Buildgun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                var GunData = RenderGun();
                GameObject NewPointer = GunData.NewPointer;
             
                if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f || Input.GetKeyDown(KeyCode.R))
                {

                    if (canShoot && lastShootTime + 0.5f < Time.time)
                    {
                        lastShootTime = Time.time;
                        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = NewPointer.transform.position;
                    }
                }
            }
        }
    }
}
