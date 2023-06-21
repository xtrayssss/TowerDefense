using System.Linq;
using Infrastructure.Services.AssetManagement;
using UnityComponents.Configurations.Game;
using UnityComponents.Configurations.Level;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GameConfiguration))]
    public class GameDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GameConfiguration gameConfiguration = target as GameConfiguration;

            if (GUILayout.Button("Collect"))
            {
                if (gameConfiguration != null)
                    gameConfiguration.levelData =
                        Resources.LoadAll<LevelConfiguration>(AssetPaths.LevelDataPath).ToList();
                else
                    Debug.LogError("GameDataNotExist");
            }

            EditorUtility.SetDirty(target);
        }
    }
}