using GorillaLocomotion;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using static HandLink;

namespace BreezeV2.Mods
{
    internal class HandlinkhelpersV2
    {
        public static bool Islefthandlinked => VRRig.LocalRig.leftHandLink.grabbedLink;
        public static bool Isrighthandlinked => VRRig.LocalRig.rightHandLink.grabbedLink;

        public static bool Groundright => VRRig.LocalRig.rightHandLink.isGroundedHand = true;
        public static bool Groundleft => VRRig.LocalRig.leftHandLink.isGroundedHand = true;

    }
}
