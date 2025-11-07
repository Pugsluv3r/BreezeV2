using GorillaLocomotion;
 
using BreezeV2.Classes;
using BreezeV2.Notifications;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using GorillaNetworking;
using GorillaExtensions;
using static BreezeV2.Classes.RigManager;
using static BreezeV2.Menu.Main;
using static BreezeV2.Classes.SimpleInputs;
using static HandLink;
using static BreezeV2.Mods.HandlinkhelpersV2;

namespace BreezeV2.Mods
{
    public class Safety
    {
        public static VRRig reportRig;
        public static void AntiReport(System.Action<VRRig, Vector3> onReport)
        {
            if (!NetworkSystem.Instance.InRoom) return;

            if (reportRig != null)
            {
                onReport?.Invoke(reportRig, reportRig.transform.position);
                reportRig = null;
                return;
            }

            foreach (GorillaPlayerScoreboardLine line in GorillaScoreboardTotalUpdater.allScoreboardLines)
            {
                if (line.linePlayer != NetworkSystem.Instance.LocalPlayer) continue;
                Transform report = line.reportButton.gameObject.transform;

                foreach (var vrrig in from vrrig in GorillaParent.instance.vrrigs where !vrrig.isLocal let D1 = Vector3.Distance(vrrig.rightHandTransform.position, report.position) let D2 = Vector3.Distance(vrrig.leftHandTransform.position, report.position) where D1 < 0.35f || D2 < 0.35f select vrrig)
                    onReport?.Invoke(vrrig, report.transform.position);
            }
        }

        public static float antiReportDelay;
        public static void AntiReportDisconnect()
        {
            AntiReport((vrrig, position) =>
            {

                if (!(Time.time > antiReportDelay)) return;
                antiReportDelay = Time.time + 1f;
                NotifiLib.SendNotification("<color=grey>[</color><color=purple>ANTI-REPORT</color><color=grey>]</color> " + GetPlayerFromVRRig(vrrig).NickName + " Has reported you.");
            });
        }
        public static void ReturnToStump() //hey if your reading this i hope you know. i try my best to make mods that arent bad. i really do.
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
    }
}
