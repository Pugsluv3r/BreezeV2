using BepInEx;
using BepInEx.Logging;
using BreezeV2.Menu;
using BreezeV2.Notifications;
using Fusion;
using GorillaLocomotion;
using GorillaNetworking;
using NanoSockets;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
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
        public static bool PLEASEFUCKINGWORK = false;

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
            if (ControllerInputPoller.instance.rightControllerGripFloat > 0.6f)
            {
                var GunData = RenderGun();
                GameObject NewPointer = GunData.NewPointer;
                if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f)
                {

                    if (canShoot && lastShootTime + 0.5f < Time.time)
                    {
                        lastShootTime = Time.time;
                        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = NewPointer.transform.position;
                    }
                }
            }
        }
        #region Gunlibfixfrfrfrfrfrf
        public static void GunLibfix()
        {
            GunLibfixStarter.EnsureStarted();
        }

        private static class GunLibfixStarter
        {
            private static GameObject _go;
            private const float DefaultPollInterval = 0.05f; 

            public static void EnsureStarted()
            {
                if (_go != null)
                    return;

                _go = new GameObject("Breeze_gunLibupdatet");
                UnityEngine.Object.DontDestroyOnLoad(_go);
                var comp = _go.AddComponent<GunLibfixBehaviour>();
                comp.PollInterval = DefaultPollInterval;
            }
        }
        private class GunLibfixBehaviour : MonoBehaviour
        {
            public float PollInterval = 0.05f;
            private bool _prevRightGrab = false;
            private bool _initialized = false;

            private void Start()
            {
                StartCoroutine(Polldatshizx());
            }

            private IEnumerator Polldatshizx()
            {

                while (ControllerInputPoller.instance == null)
                {
                    yield return null; 
                }

                _prevRightGrab = ControllerInputPoller.instance.rightGrab;
                _initialized = true;

                var wait = new WaitForSecondsRealtime(Mathf.Max(0.001f, PollInterval));
                while (true)
                {
                    bool currRightGrab = ControllerInputPoller.instance.rightGrab;


                    if (currRightGrab && !_prevRightGrab)
                    {
                        try
                        {
                            Movement.Yesyesgunfrfrfrfrfrfrfrfrfrfrfrfr();
                        }
                        catch (Exception)
                        {
                            
                        }
                    }
                    else if (!currRightGrab && _prevRightGrab)
                    {
                        try
                        {
                            Movement.Nonomoregunfrfrfrfrfrfrfrfrfrfrfr();
                        }
                        catch (Exception)
                        {

                        }
                    }

                    _prevRightGrab = currRightGrab;

                    yield return wait;
                }
            }
            private void OnDestroy()
            {
                StopAllCoroutines();
            }
            #endregion
        }
    }
}

