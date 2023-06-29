using System.Collections.Generic;
using UnityComponents.Configurations;
using UnityEngine;
using UnityEngine.UI;

namespace UnityComponents.Windows
{
    internal class BuildWindow : BaseWindow
    {
        [SerializeField] private Image[] towerIcons;
        [SerializeField] private TowerData[] towerData;

        public IEnumerable<TowerData> TowerData => towerData;

        public Image[] TowerIcons => towerIcons;
    }
}