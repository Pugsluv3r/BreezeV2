using BepInEx;

using BreezeV2.Mods;
using UnityEngine;

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
            Debug.Log(@"
Loaded:
 ____  ____  ____  ____  ____  ____    _  _  ___ /\
(  _ \(  _ \( ___)( ___)(_   )( ___)  ( \/ )(__ ))(
 ) _ < )   / )__)  )__)  / /_  )__)    \  /  (_ \\/
(____/(_)\_)(____)(____)(____)(____)    \/  (___/()
Made by Pugs!                               [1.0.0]
                Powered by II Template
NOW WITH 0 CONSOLE!
");
            Otherstuff.Customboards();
            Otherstuff.Eyerockcusp();
        }
    }
}
