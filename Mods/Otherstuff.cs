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
        public static GameObject Motdtext;
        public static GameObject CocHeader;
        
        private static List<TextMeshPro> udTMP = new List<TextMeshPro>();

        //Lastshootshizzzy
        private static float lastShootTime = 0f;
        private static bool canShoot = true;
        public static bool PLEASEFUCKINGWORK = false;
        //Build gun shizzy
        public static void Customboards()
        {
            if (messageofthedih == null && Motdtext == null && CocHeader == null)
            {
                GameObject motdObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdHeadingText");
                messageofthedih = UnityEngine.Object.Instantiate(motdObject, motdObject.transform.parent);
                motdObject.SetActive(false);
                GameObject MotdBody = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdBodyText");
                Motdtext = UnityEngine.Object.Instantiate(MotdBody, MotdBody.transform.parent);
                MotdBody.GetComponent<PlayFabTitleDataTextDisplay>().Destroy();
                MotdBody.SetActive(false);
                GameObject CoCheadingfr = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/CodeOfConductHeadingText");
                CocHeader = GameObject.Instantiate(CoCheadingfr, CoCheadingfr.transform.parent);
                CoCheadingfr.SetActive(false);

            }

            TextMeshPro motdTc = messageofthedih.GetComponent<TextMeshPro>();
            if (!udTMP.Contains(motdTc))
                udTMP.Add(motdTc);

            motdTc.richText = true;
            motdTc.fontSize = 70;
            motdTc.text = "Breeze V3!";


            TextMeshPro motdBodyTc = Motdtext.GetComponent<TextMeshPro>();
            if (!udTMP.Contains(motdBodyTc))
                udTMP.Add(motdBodyTc);
            GameObject Fuckoffplayfab = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdBodyText(Clone)");
            Fuckoffplayfab.GetComponent<PlayFabTitleDataTextDisplay>().Destroy();
            motdBodyTc.richText = true;
            motdBodyTc.fontSize = 90;
            motdBodyTc.text = "Thank you for choosing Breeze V3, version: " + PluginInfo.Version + " this is the most stable breeze has ever been" +
                " I hope you enjoy the menu."; 
            motdBodyTc.color = Color.pink;
            motdBodyTc.alignment = TextAlignmentOptions.Center;

            TextMeshPro cocHeaderTc = CocHeader.GetComponent<TextMeshPro>();
            if (!udTMP.Contains(cocHeaderTc))
                udTMP.Add(cocHeaderTc);
            cocHeaderTc.richText = true;
            cocHeaderTc.fontSize = 70;
            cocHeaderTc.text = "Breeze V3 " + PluginInfo.Version;

        }
        
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
                        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = NewPointer.transform.position;
                    }

                }
            }
        }
        public static void DestroyGun()
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

                        if (NewPointer != null)
                        {
                            for (int i = 0; i < NewPointer.transform.childCount; i++)
                            {
                                var child = NewPointer.transform.GetChild(i).gameObject;
                                if (child != null && child.activeSelf)
                                {
                                    child.SetActive(false);
                                }
                            }

                            var renderers = NewPointer.GetComponentsInChildren<Renderer>(true);
                            foreach (var rend in renderers)
                            {
                                if (rend == null)
                                    continue;

                                if (rend.gameObject == NewPointer )
                                    continue;

                                if (rend.enabled)
                                    rend.enabled = false;
                            }

                            var particleSystems = NewPointer.GetComponentsInChildren<ParticleSystem>(true);
                            foreach (var ps in particleSystems)
                            {
                                if (ps != null)
                                    ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                            }

                            var colliders = NewPointer.GetComponentsInChildren<Collider>(true);
                            foreach (var col in colliders)
                            {
                                if (col != null && col.enabled)
                                    col.enabled = false;
                            }
                        }
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

