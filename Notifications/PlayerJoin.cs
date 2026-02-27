using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using BreezeV2.Notifications;
using UnityEngine;

namespace BreezeV2.Patches
{
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerEnteredRoom")]
    public class JoinPatch : MonoBehaviour
    {
        private static void Prefix(Player newPlayer)
        {
            if (newPlayer != oldnewplayer)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=green>New:</color><color=grey>] </color><color=white> " + newPlayer.NickName + "</color>");
                oldnewplayer = newPlayer;
            }
        }

        private static Player oldnewplayer;
    }
}