using System.Collections.Generic;
using UnityComponents.Configurations.Level;
using UnityEngine;

namespace UnityComponents.Configurations.Game
{
    [CreateAssetMenu(fileName = "newGameData", menuName = "Data/Game")]
    public class GameConfiguration : ScriptableObject
    {
        public List<LevelConfiguration> levelData;
    }
}