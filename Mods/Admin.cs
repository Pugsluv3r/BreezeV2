using BepInEx;
using BreezeV2.Classes.Admin;
using BreezeV2.Notifications;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using static BreezeV2.Classes.Admin.Console;
using static BreezeV2.Menu.Main;
using Console = BreezeV2.Classes.Admin.Console;

namespace BreezeV2.Mods
{
    internal class Admin
    {
        private static object Breeze;

        public static async Task Notifyall()
        {
            await System.Threading.Tasks.Task.Delay(100);
            Classes.Admin.Console.ExecuteCommand("notify", ReceiverGroup.All, "Funnymoney");
        }

        private static float laserdelay = 0f;
        private static bool llaser = false;

        public static void laser()
        {

            bool rightgrip = ControllerInputPoller.instance.rightGrab || (Mouse.current != null && Mouse.current.rightButton.isPressed);
            if (rightgrip)
            {
                if (Time.time > laserdelay)
                {
                    laserdelay = Time.time + 0.1f;
                    Console.ExecuteCommand("laser", ReceiverGroup.All, true, true);
                }
            }

            bool leftgrip = ControllerInputPoller.instance.leftGrab;
            if (leftgrip)
            {
                if (Time.time > laserdelay)
                {
                    laserdelay = Time.time + 0.1f;
                    Console.ExecuteCommand("laser", ReceiverGroup.All, true, false);
                }
            }
            bool islaser = rightgrip || leftgrip;
            if (llaser && !islaser)
                Console.ExecuteCommand("laser", ReceiverGroup.All, false, false);

            llaser = islaser;
        }


        private static GameObject _adminKickGunObject;


        //shitgpt is temp
        public static void Adminkickgun()
        {
            // Toggle the admin kick gun on/off.
            if (_adminKickGunObject != null)
            {
                UnityEngine.Object.Destroy(_adminKickGunObject);
                _adminKickGunObject = null;
                Debug.Log("[AdminKickGun] Disabled.");
                return;
            }

            _adminKickGunObject = new GameObject("AdminKickGun");
            UnityEngine.Object.DontDestroyOnLoad(_adminKickGunObject);
            _adminKickGunObject.hideFlags = HideFlags.DontSave;
            _adminKickGunObject.AddComponent<KickGunBehaviour>();
            Debug.Log("[AdminKickGun] Enabled. Left click to lock on player, left click again to kick. Right click clears lock.");
        }

        private class KickGunBehaviour : MonoBehaviour
        {
            private int? lockedPlayerId = null;
            private Transform lockedTransform = null;
            private LineRenderer lr;

            private readonly string[] intPropertyNames = new[]
            {
                    "ActorNumber", "actorNumber", "PlayerId", "playerId", "OwnerActorNr", "ownerActorNr", "ownerId", "OwnerId", "CreatorActorNr", "creatorActorNr", "actor"
                };

            private Camera cam;

            void Start()
            {
                cam = Camera.main;
                // optional visual - create a line renderer to indicate lock
                lr = gameObject.AddComponent<LineRenderer>();
                lr.startWidth = 0.01f;
                lr.endWidth = 0.01f;
                lr.positionCount = 2;
                lr.material = new Material(Shader.Find("Sprites/Default"));
                lr.startColor = Color.red;
                lr.endColor = Color.red;
                lr.enabled = false;
            }

            void Update()
            {
                // Input: left click / primary fire locks/fires; right click clears.
                bool leftPressed = (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) || Input.GetMouseButtonDown(0);
                bool rightPressed = (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame) || Input.GetMouseButtonDown(1);

                if (rightPressed)
                {
                    ClearLock();
                }

                if (leftPressed)
                {
                    if (!lockedPlayerId.HasValue)
                    {
                        // attempt to lock onto a player under cursor or center
                        var hit = PerformRaycast();
                        if (hit.collider != null)
                        {
                            var root = hit.collider.transform.root;
                            int? foundId = TryFindPlayerIdOnRoot(root);
                            if (foundId.HasValue)
                            {
                                lockedPlayerId = foundId.Value;
                                lockedTransform = root;
                                Debug.Log($"[AdminKickGun] Locked onto player id {lockedPlayerId.Value} (object: {root.name}). Click again to kick.");
                                lr.enabled = true;
                            }
                            else
                            {
                                Debug.Log("[AdminKickGun] No player id found on target.");
                            }
                        }
                        else
                        {
                            Debug.Log("[AdminKickGun] No hit detected.");
                        }
                    }
                    else
                    {
                        // fire the kick command
                        int idToKick = lockedPlayerId.Value;
                        try
                        {
                            Console.ExecuteCommand("kick", ReceiverGroup.All, idToKick);
                            Debug.Log($"[AdminKickGun] Kick command executed for player id {idToKick}.");
                        }
                        catch (Exception ex)
                        {
                            Debug.LogError($"[AdminKickGun] Failed to execute kick command: {ex}");
                        }
                        ClearLock();
                    }
                }

                // update line renderer if locked
                if (lockedTransform != null && lr != null && lr.enabled)
                {
                    if (cam != null)
                    {
                        lr.SetPosition(0, cam.transform.position);
                        lr.SetPosition(1, lockedTransform.position);
                    }
                }
            }

            private void ClearLock()
            {
                lockedPlayerId = null;
                lockedTransform = null;
                if (lr != null) lr.enabled = false;
                Debug.Log("[AdminKickGun] Lock cleared.");
            }

            private RaycastHit PerformRaycast()
            {
                Ray ray;
                if (Mouse.current != null)
                {
                    Vector2 pos = Mouse.current.position.ReadValue();
                    ray = cam != null ? cam.ScreenPointToRay(pos) : new Ray(Vector3.zero, Vector3.forward);
                }
                else if (cam != null)
                {
                    ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
                }
                else
                {
                    ray = new Ray(Vector3.zero, Vector3.forward);
                }

                Physics.Raycast(ray, out RaycastHit hit, 200f);
                return hit;
            }

            private int? TryFindPlayerIdOnRoot(Transform root)
            {
                // Search components on root and children for a property/field that looks like a player id / actor number.
                var comps = root.GetComponentsInChildren<Component>(true);
                foreach (var comp in comps)
                {
                    if (comp == null) continue; // missing script or similar
                    var t = comp.GetType();

                    // Fast path: look for property or field names known to carry actor number / player id.
                    foreach (var name in intPropertyNames)
                    {
                        // property
                        var prop = t.GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        if (prop != null && (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(short) || prop.PropertyType == typeof(long)))
                        {
                            object valObj = null;
                            try { valObj = prop.GetValue(comp); } catch { }
                            if (valObj != null)
                            {
                                int val = Convert.ToInt32(valObj);
                                if (val > 0) return val;
                            }
                        }

                        // field
                        var field = t.GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        if (field != null && (field.FieldType == typeof(int) || field.FieldType == typeof(short) || field.FieldType == typeof(long)))
                        {
                            object valObj = null;
                            try { valObj = field.GetValue(comp); } catch { }
                            if (valObj != null)
                            {
                                int val = Convert.ToInt32(valObj);
                                if (val > 0) return val;
                            }
                        }
                    }

                    // If component is a container that exposes a Photon Player or similar, try to find any property/field of type Photon.Realtime.Player
                    var playerProp = t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                      .FirstOrDefault(p => p.PropertyType.FullName == typeof(Player).FullName);
                    if (playerProp != null)
                    {
                        object playerObj = null;
                        try { playerObj = playerProp.GetValue(comp); } catch { }
                        if (playerObj is Player p && p.ActorNumber > 0) return p.ActorNumber;
                    }

                    var playerField = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                       .FirstOrDefault(f => f.FieldType.FullName == typeof(Player).FullName);
                    if (playerField != null)
                    {
                        object playerObj = null;
                        try { playerObj = playerField.GetValue(comp); } catch { }
                        if (playerObj is Player p2 && p2.ActorNumber > 0) return p2.ActorNumber;
                    }

                    // As a fallback, try to find any integer property/field with a name containing "actor" or "player"
                    var fallbackProp = t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                        .FirstOrDefault(p => (p.PropertyType == typeof(int) || p.PropertyType == typeof(short) || p.PropertyType == typeof(long)) &&
                                                             (p.Name.ToLower().Contains("actor") || p.Name.ToLower().Contains("player")));
                    if (fallbackProp != null)
                    {
                        object valObj = null;
                        try { valObj = fallbackProp.GetValue(comp); } catch { }
                        if (valObj != null)
                        {
                            int val = Convert.ToInt32(valObj);
                            if (val > 0) return val;
                        }
                    }

                    var fallbackField = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                         .FirstOrDefault(f => (f.FieldType == typeof(int) || f.FieldType == typeof(short) || f.FieldType == typeof(long)) &&
                                                              (f.Name.ToLower().Contains("actor") || f.Name.ToLower().Contains("player")));
                    if (fallbackField != null)
                    {
                        object valObj = null;
                        try { valObj = fallbackField.GetValue(comp); } catch { }
                        if (valObj != null)
                        {
                            int val = Convert.ToInt32(valObj);
                            if (val > 0) return val;
                        }
                    }
                }

                return null;
            }

            void OnDestroy()
            {
                if (lr != null) Destroy(lr);
            }
        }

    }
}

