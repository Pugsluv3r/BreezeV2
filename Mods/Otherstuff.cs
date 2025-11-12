using NanoSockets;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace BreezeV2.Mods
{
    internal class Otherstuff
    {
        
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
            motdTc.text = "Breeze Alpha 2!";
            
        }
        public static GameObject messageofthedih;
    }
}
