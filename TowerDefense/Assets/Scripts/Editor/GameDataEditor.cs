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

            GameConfiguration gameConfiguration = (GameConfiguration) target;

            if (GUILayout.Button("Collect"))
            {
                gameConfiguration.levelData =
                    Resources.LoadAll<LevelConfiguration>(AssetPaths.LevelDataPath).ToList();
            }

            EditorUtility.SetDirty(target);
        }
    }
}