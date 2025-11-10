using BepInEx;
using BreezeV2.Classes.Admin;

namespace BreezeV2
{
    [System.ComponentModel.Description(PluginInfo.Description)]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class HarmonyPatches : BaseUnityPlugin
    {
        private void Awake() =>
            GorillaTagger.OnPlayerSpawned(OnPlayerSpawned);

        public void OnPlayerSpawned() =>
            Patches.PatchHandler.PatchAll();
        void Start()
        {
            gameObject.AddComponent<Console>();
        }
    }
}
