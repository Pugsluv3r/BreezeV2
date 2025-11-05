using BepInEx;
using GorillaLocomotion;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BreezeV2.Mods
{
    internal class Temp
    {

        // Made by IIDK for testing purposes will be removed later


        public static float startX = -1f;
        public static float startY = -1f;

        public static float subThingy;
        public static float subThingyZ;

        public static Vector3 lastPosition = Vector3.zero;
        
        public static void WASDFly()
        {


            bool W = UnityInput.Current.GetKey(KeyCode.W);
            bool A = UnityInput.Current.GetKey(KeyCode.A);
            bool S = UnityInput.Current.GetKey(KeyCode.S);
            bool D = UnityInput.Current.GetKey(KeyCode.D);
            bool Space = UnityInput.Current.GetKey(KeyCode.Space);
            bool Ctrl = UnityInput.Current.GetKey(KeyCode.LeftControl);
            bool Shift = UnityInput.Current.GetKey(KeyCode.LeftShift);
            bool Alt = UnityInput.Current.GetKey(KeyCode.LeftAlt);

            if (true || W || A || S || D || Space || Ctrl)
                GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;

            if (true)
            {
                if (Mouse.current.rightButton.isPressed)
                {
                    Transform parentTransform = GTPlayer.Instance.GetControllerTransform(false).parent;
                    Quaternion currentRotation = parentTransform.rotation;
                    Vector3 euler = currentRotation.eulerAngles;

                    if (startX < 0)
                    {
                        startX = euler.y;
                        subThingy = Mouse.current.position.value.x / Screen.width;
                    }
                    if (startY < 0)
                    {
                        startY = euler.x;
                        subThingyZ = Mouse.current.position.value.y / Screen.height;
                    }

                    float newX = startY - (Mouse.current.position.value.y / Screen.height - subThingyZ) * 360 * 1.33f;
                    float newY = startX + (Mouse.current.position.value.x / Screen.width - subThingy) * 360 * 1.33f;

                    newX = newX > 180f ? newX - 360f : newX;
                    newX = Mathf.Clamp(newX, -90f, 90f);

                    parentTransform.rotation = Quaternion.Euler(newX, newY, euler.z);
                }
                else
                {
                    startX = -1;
                    startY = -1;
                }

                float speed = 6f;
                if (Shift)
                    speed *= 2f;
                else if (Alt)
                    speed /= 2;

                if (W)
                    GorillaTagger.Instance.rigidbody.transform.position += GTPlayer.Instance.GetControllerTransform(false).parent.forward * (Time.deltaTime * speed);

                if (S)
                    GorillaTagger.Instance.rigidbody.transform.position += GTPlayer.Instance.GetControllerTransform(false).parent.forward * (Time.deltaTime * -speed);

                if (A)
                    GorillaTagger.Instance.rigidbody.transform.position += GTPlayer.Instance.GetControllerTransform(false).parent.right * (Time.deltaTime * -speed);

                if (D)
                    GorillaTagger.Instance.rigidbody.transform.position += GTPlayer.Instance.GetControllerTransform(false).parent.right * (Time.deltaTime * speed);

                if (Space)
                    GorillaTagger.Instance.rigidbody.transform.position += new Vector3(0f, Time.deltaTime * speed, 0f);

                if (Ctrl)
                    GorillaTagger.Instance.rigidbody.transform.position += new Vector3(0f, Time.deltaTime * -speed, 0f);

                VRRig.LocalRig.head.rigTarget.transform.rotation = GorillaTagger.Instance.headCollider.transform.rotation;
            }

            if (!W && !A && !S && !D && !Space && !Ctrl && lastPosition != Vector3.zero)
                GorillaTagger.Instance.rigidbody.transform.position = lastPosition;
            else
                lastPosition = GorillaTagger.Instance.rigidbody.transform.position;

        }

    }
}



