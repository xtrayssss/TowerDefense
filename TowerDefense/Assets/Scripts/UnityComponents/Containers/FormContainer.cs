using System.Collections.Generic;
using System.Linq;
using UnityComponents.Containers.Data;
using UnityComponents.Windows;
using UnityEngine;

namespace UnityComponents.Containers
{
    internal class FormContainer : ReferenceContainer
    {
        [SerializeField] private Data.Data[] forms;

        private Dictionary<FormTypeId, BaseWindow> _allTilemap;

        public BaseWindow GetForm(FormTypeId formTypeId) =>
            _allTilemap[formTypeId];

        public override void Initialize() =>
            _allTilemap = forms.ToDictionary(x => x.formTypeId, x => x.Value);
    }
}