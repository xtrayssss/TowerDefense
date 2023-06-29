using System;
using Infrastructure.Services.Factories;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnityComponents.Configurations
{
    [Serializable]
    public class TowerData
    {
        [SerializeField] private TowerTypeId towerTypeId;
        [SerializeField] private Button button;
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text price;

        public Image Icon => icon;
        public TMP_Text Price => price;
        public TowerTypeId TowerTypeId => towerTypeId;
        public Button Button => button;
    }
}