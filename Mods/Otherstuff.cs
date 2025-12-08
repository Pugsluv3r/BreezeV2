using GorillaLocomotion;
using NanoSockets;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using BreezeV2.Menu;
using static BreezeV2.Menu.Main;

namespace BreezeV2.Mods
{
    internal class Otherstuff
    {
        public static GameObject messageofthedih;
        private static List<TextMeshPro> udTMP = new List<TextMeshPro>();

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
            motdTc.text = "Breeze Alpha 1.5 dec 8th patch!";

        }
    }
}
