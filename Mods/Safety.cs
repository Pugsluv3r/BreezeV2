using BreezeV2.Notifications;
using GorillaLocomotion;
using System;
using UnityEngine;
using static BreezeV2.Classes.SimpleInputs;
using static BreezeV2.Mods.HandlinkhelpersV2;

namespace BreezeV2.Mods
{
    public class Safety
    {
        public static float Lastreporttime = 0f;
        public static float threshold = 0.005f;
        public static int reportcount = 0;
        public static bool Leaveafter7reports = true;
        public static float Thing1 { get; private set; }
        public static float Thing2 { get; private set; }
        public static void AntiReport()
        {
            try
            {
                foreach (GorillaPlayerScoreboardLine line in GorillaScoreboardTotalUpdater.allScoreboardLines)
                {
                    if (line.linePlayer == NetworkSystem.Instance.LocalPlayer)
                    {
                        Transform report = line.reportButton.gameObject.transform;

                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            if (vrrig != VRRig.LocalRig)
                            {
                                Thing1 = Vector3.Distance(vrrig.rightHandTransform.position, report.position);
                                Thing2 = Vector3.Distance(vrrig.leftHandTransform.position, report.position);
                            }
                            if (Thing1 < threshold || Thing2 < threshold && Lastreporttime + 1f < Time.time)
                            {
                                reportcount ++;
                                NotifiLib.SendNotification("<color=grey>[</color><color=purple>You've been reported</color><color=grey>]:</color>" + reportcount + "times (Note this may be inacurate)" );
                            }
                            if (Leaveafter7reports = true && reportcount > 6)
                            {
                                NetworkSystem.Instance.ReturnToSinglePlayer();
                                NotifiLib.SendNotification("color=red>[Notif]: You have been reported more than 7 times</color> to disable this feature go into menu settings");
                                reportcount = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred in AntiReport: {ex.Message}"); //eyerock reborn code btw :sob:
            }
        }
        public static void ReturnToStump()
        {
            if (RightB)
            {
                UnityEngine.Vector3 targetPosition = new UnityEngine.Vector3(-66.9039f, 11.8661f, -82.1227f);
                UnityEngine.Quaternion targetRotation = UnityEngine.Quaternion.identity;
                GTPlayer.Instance.TeleportTo(targetPosition, targetRotation);

            }

        }
        public static void Antihandlink()
        {
            if (RightTrigger || RightGrab || LeftTrigger || LeftGrab)
            {

                VRRig.LocalRig.leftHandLink.RejectGrabsFor(10f);
                VRRig.LocalRig.rightHandLink.RejectGrabsFor(10f);
            }
        }
        public static void Dominantmonke()
        {
            if (Isrighthandlinked || Islefthandlinked)
            {
                VRRig.LocalRig.rightHandLink.isGroundedHand = true;
                VRRig.LocalRig.leftHandLink.isGroundedHand = true;
            }
        }
        public static void LTdisconnect()
        {
            if (LeftTrigger)
            {
                NetworkSystem.Instance.ReturnToSinglePlayer();
            }
        }
    }
}
