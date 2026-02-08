using BepInEx;
using BreezeV2.Menu;
using GorillaLocomotion;
using UnityEngine;
using UnityEngine.XR;
using static BreezeV2.Menu.Main;

namespace BreezeV2.Mods
{
    public class Movement
    {
        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Settings.Movement.flySpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
            }
        }

        private static GameObject CreatePlatformOnHand(Transform handTransform)
        {

            GameObject plat = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plat.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);

            plat.transform.position = handTransform.position;
            plat.transform.rotation = handTransform.rotation;

            float h = (Time.frameCount / 180f) % 1f;
            plat.GetComponent<Renderer>().material.color = UnityEngine.Color.mintCream;
            return plat;
        }


        public static void Platforms()
        {
            if (ControllerInputPoller.instance.leftGrab && leftplat == null)
            {
                leftplat = CreatePlatformOnHand(GorillaTagger.Instance.leftHandTransform);
            }

            if (ControllerInputPoller.instance.rightGrab && rightplat == null)
            {
                rightplat = CreatePlatformOnHand(GorillaTagger.Instance.rightHandTransform);
            }

            if (ControllerInputPoller.instance.rightGrabRelease && rightplat != null)
            {
                rightplat.Disable();
                rightplat = null;
            }

            if (!ControllerInputPoller.instance.leftGrabRelease || leftplat == null)
            {
                return;
            }
            leftplat.Disable();
            ;
            leftplat = null;
        }
        private static GameObject leftplat;
        private static GameObject rightplat;

        public static bool previousTeleportTrigger;



        private static LineRenderer Gunline;

        public static void TeleportGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                var GunData = RenderGun();
                GameObject NewPointer = GunData.NewPointer;
                NewPointer.name = "BreezeTeleportPointer";

                if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f && !previousTeleportTrigger)
                {
                    GTPlayer.Instance.TeleportTo(NewPointer.transform.position + Vector3.up, GTPlayer.Instance.transform.rotation);
                    GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
                
                }
                    previousTeleportTrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f;
            }
        }

        public static void SlideControl(float Control)
        {
            GTPlayer.Instance.slideControl = Control;
        }

        public static void Nonomoregunfrfrfrfrfrfrfrfrfrfrfr()
        {
            GameObject.Find("iiMenu_GunLine").SetActive(false);
            GameObject.Find("BreezeTeleportPointer").SetActive(false);
        }
        public static void Yesyesgunfrfrfrfrfrfrfrfrfrfrfrfr()
        {
            GameObject.Find("iiMenu_GunLine").SetActive(true);
            GameObject.Find("BreezeTeleportPointer").SetActive(true);

        }
    }
}
