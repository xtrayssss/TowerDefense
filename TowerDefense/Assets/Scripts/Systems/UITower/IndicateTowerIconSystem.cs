using Systems.Build;
using Components.Forms;
using Components.UITower;
using Infrastructure.Services.Factories;
using Leopotam.Ecs;
using UnityComponents.Configurations;
using UnityComponents.Windows;
using UnityEngine;

namespace Systems.UITower
{
    internal class IndicateTowerIconSystem : IEcsRunSystem
    {
        private readonly EcsFilter<FormComponent<BuildWindow>, Diamante, IndicateTowerIconSelfRequest> _filter;

        private static readonly Color NotAvailableColor = new Color(0.89f, 0.36f, 0.36f);
        private static readonly Color DefaultColor = Color.white;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var formComponent = ref _filter.Get1(index);
                ref var diamante = ref _filter.Get2(index);

                foreach (TowerData towerData in formComponent.Form.TowerData)
                {
                    towerData.Icon.color = int.Parse(towerData.Price.text) > diamante.Value
                        ? NotAvailableColor
                        : DefaultColor;
                }
            }
        }
    }
}