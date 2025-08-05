using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace demon_mode
{

	public class DemonMode_Component : MonoBehaviour 
	{
		void Update()
		{
			Scene uiScene = SceneManager.GetSceneByName("UserInterface");
            if (uiScene.loadingState == Scene.LoadingState.Loaded)
            {
                GameObject[] uiObjs = uiScene.GetRootGameObjects();
                foreach (GameObject obj in uiObjs)
                {
                    UI.HUD.EntityHighlighter[] ehis = obj.GetComponentsInChildren<UI.HUD.EntityHighlighter>(false);
                    foreach (UI.HUD.EntityHighlighter ehi in ehis)
                    {
                        ehi._text = "DEMON";
                        ehi.label.color = new Color(1f, 0f, 0f, 1f);
                        ehi.image.color = new Color(1f, 0f, 0f, 1f);
                    }
                }
            }
        }
	}

	[BepInPlugin("demon_mode", "Demon Mode", "0.0.1")]
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