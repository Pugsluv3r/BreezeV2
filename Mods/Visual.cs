using GorillaLocomotion;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using static BreezeV2.Classes.SimpleInputs;

namespace BreezeV2.Mods
{
    internal class Visual
    {
        private static readonly Dictionary<int, GameObject> _babyboo = new Dictionary<int, GameObject>();
        private static Material _dihboxMaterial;
        private static readonly Color _boxColor = new Color(1f, 0f, 0f, 0.18f);
        private static readonly Vector3 _fallbackSize = new Vector3(0.3f, 1.7f, 0.3f);

        public static void Esp()
        {
            try
            {
                if (!PhotonNetwork.InRoom)
                {
                    ClearAllBoxes();
                    return;
                }

                if (GorillaParent.instance == null || GorillaParent.instance.vrrigs == null)
                    return;

                Shegoncallmebabyboo();
                HashSet<int> currentRigIds = new HashSet<int>();

                foreach (VRRig vRRig in GorillaParent.instance.vrrigs)
                {
                    if (vRRig == null || vRRig.gameObject == null)
                        continue;

                    PhotonView pv = vRRig.GetComponent<PhotonView>();
                    if (pv != null && pv.IsMine)
                        continue;

                    int id = vRRig.gameObject.GetInstanceID();
                    currentRigIds.Add(id);


                    if (!_babyboo.ContainsKey(id) || _babyboo[id] == null)
                    {
                        GameObject box = CreateBox(id);
                        _babyboo[id] = box;
                    }

                    GameObject Dihbox = _babyboo[id];
                    if (Dihbox == null)
                        continue; 

                    Bounds bounds = GetBoundsFromRenderers(vRRig.transform);
                    Dihbox.transform.position = bounds.center;
                    Dihbox.transform.rotation = Quaternion.identity;
                    Dihbox.transform.localScale = bounds.size;
                }
                var keysToRemove = new List<int>();
                foreach (var kvp in _babyboo)
                {
                    if (!currentRigIds.Contains(kvp.Key) || kvp.Value == null)
                    {
                        if (kvp.Value != null)
                            UnityEngine.Object.Destroy(kvp.Value);
                        keysToRemove.Add(kvp.Key);
                    }
                }

                foreach (int k in keysToRemove)
                        _babyboo.Remove(k);
            }
            catch (Exception)
            {

            }
        }

        private static void Shegoncallmebabyboo()
        {
            if (_dihboxMaterial != null)
                return;

          
            Shader shader = Shader.Find("Standard");
            if (shader == null)
                shader = Shader.Find("Unlit/Color"); 

            _dihboxMaterial = new Material(shader)
            {
                name = "Shegoncallmebabyboo"
            };

            if (shader != null && shader.name.Contains("Standard"))
            {
                _dihboxMaterial.SetFloat("_Mode", 3f);
                _dihboxMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                _dihboxMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                _dihboxMaterial.SetInt("_ZWrite", 0);
                _dihboxMaterial.DisableKeyword("_ALPHATEST_ON");
                _dihboxMaterial.EnableKeyword("_ALPHABLEND_ON");
                _dihboxMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                _dihboxMaterial.renderQueue = 3000;
            }

            _dihboxMaterial.color = _boxColor;
        }

        private static GameObject CreateBox(int id)
        {
            GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
            box.name = $"BreezeBox_{id}";

            Collider col = box.GetComponent<Collider>();
            if (col != null)
            {
                UnityEngine.Object.Destroy(col);
            }

            if (GorillaParent.instance != null && GorillaParent.instance.transform != null)
            {
                box.transform.SetParent(GorillaParent.instance.transform, true);
            }

            MeshRenderer mr = box.GetComponent<MeshRenderer>();
            if (mr != null)
            {
                mr.sharedMaterial = _dihboxMaterial;
                mr.shadowCastingMode = ShadowCastingMode.Off;
                mr.receiveShadows = false;
                mr.lightProbeUsage = LightProbeUsage.Off;
                mr.reflectionProbeUsage = ReflectionProbeUsage.Off;
            }

           
            
            box.hideFlags = HideFlags.DontSave;

            return box;
        }

        private static Bounds GetBoundsFromRenderers(Transform root)
        {
            Renderer[] renderers = root.GetComponentsInChildren<Renderer>(true);
            if (renderers != null && renderers.Length > 0)
            {
                Bounds combined = renderers[0].bounds;
                for (int i = 1; i < renderers.Length; i++)
                {
                    try
                    {
                        combined.Encapsulate(renderers[i].bounds);
                    }
                    catch
                    {
                    }
                }
                Vector3 size = combined.size;
                size.x = Mathf.Max(size.x, 0.05f);
                size.y = Mathf.Max(size.y, 0.05f);
                size.z = Mathf.Max(size.z, 0.05f);
                combined.size = size;
                return combined;
            }

            return new Bounds(root.position, _fallbackSize);
        }

        private static void ClearAllBoxes()
        {
            foreach (var kvp in _babyboo)
            {
                if (kvp.Value != null)
                    UnityEngine.Object.Destroy(kvp.Value);
            }
            _babyboo.Clear();
        }
    }
}
