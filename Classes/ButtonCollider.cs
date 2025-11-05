using UnityEngine;
using static BreezeV2.Menu.Main;
using static BreezeV2.Settings;

namespace BreezeV2.Classes
{
	public class Button : MonoBehaviour
	{
		public string relatedText;

		public static float buttonCooldown = 0f;
		
		public void OnTriggerEnter(Collider collider)
		{
			if (Time.time > buttonCooldown && collider == buttonCollider && menu != null)
			{
                buttonCooldown = Time.time + 0.2f;
                GorillaTagger.Instance.StartVibration(rightHanded, GorillaTagger.Instance.tagHapticStrength / 2f, GorillaTagger.Instance.tagHapticDuration / 2f);
                VRRig.LocalRig.PlayHandTapLocal(8, rightHanded, 0.4f);
				Toggle(this.relatedText);
            }
		}
	}
}
