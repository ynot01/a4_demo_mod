using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using UnityEngine;
using UnityEngine.SceneManagement;
using HarmonyLib;

namespace demon_mode
{

	public class DemonMode_Component : MonoBehaviour 
	{
		void Awake() {
			Harmony.CreateAndPatchAll(typeof(DemonMode_Component));
		}

		[HarmonyPostfix]
		[HarmonyPatch(typeof(UI.HUD.EntityHighlighter), nameof(UI.HUD.EntityHighlighter.Activate))]
		static void OverrideActivate(UI.HUD.EntityHighlighter __instance) {
			__instance._text = "DEMON";
			__instance.label.color = new Color(1f, 0f, 0f, 1f);
			__instance.image.color = new Color(1f, 0f, 0f, 1f);
        }
	}

	[BepInPlugin("demon_mode", "Demon Mode", "0.0.3")]
	public class DemonMode : BasePlugin
	{
		internal static new ManualLogSource Log;

		public override void Load()
		{
			Log = base.Log;

			AddComponent<DemonMode_Component>();

			Log.LogInfo($"Plugin demon_mode loaded successfully.");
		}
	}
}