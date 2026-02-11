using GorillaLocomotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TMPro;
using UnityEngine;
using static BreezeV2.Classes.SimpleInputs;


namespace BreezeV2.Mods
{
    internal class Visual
    {
        public static void Tracersifrighttrigger() 
        {
            if (RightTrigger && NetworkSystem.Instance.InRoom)
            {
                foreach (var vrrig in GorillaParent.instance.vrrigs)
                {
                    if (vrrig.isLocal) continue;
                    UnityEngine.LineRenderer line = vrrig.gameObject.GetComponent<UnityEngine.LineRenderer>();
                    if (line == null) line = vrrig.gameObject.AddComponent<UnityEngine.LineRenderer>();
                    line.SetPosition(0, GTPlayer.Instance.RightHand.controllerTransform.position);
                    line.SetPosition(1, vrrig.transform.position);
                    line.startWidth = 0.01f;
                    line.endWidth = 0.01f;
                    line.material.color = UnityEngine.Color.red;
                    line.name = "BreezeTracers";
                }
                NetworkSystem.Instance.OnReturnedToSinglePlayer += () => 
                {

                    GameObject.Destroy(GameObject.Find("breezeTracers"));
                };
            }

        }
            
    }
}
