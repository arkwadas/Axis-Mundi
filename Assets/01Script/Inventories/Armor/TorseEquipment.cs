
using System.Collections.Generic;
using GameDevTV.Inventories;
using RPG.Customization;
using RPG.Stat;
using RPG.Stats;
using UnityEngine;

namespace RPG.Invetories
{
    [CreateAssetMenu(menuName = ("RPG/Inventory/Torse Equipment"))]
    public class TorseEquipment : EquipableItem, IModifierProvide
    {
        [SerializeField]
        Modifier[] additiveModifiers;
        [SerializeField]
        Modifier[] percentageModifiers;


        [Header("Podaj nazwe gameObjectu")]
        public string torseModelName;

        [System.Serializable]
        struct Modifier
        {
            public Stats.Stat stat;
            public float value;
        }

        ;




        public IEnumerable<float> GetAdditiveModifier(Stats.Stat stat)
        {
            foreach (var modifier in additiveModifiers)
            {
                if (modifier.stat == stat)
                {
                    yield return modifier.value;
                }
            }
        }

        public IEnumerable<float> GetProcentageModifire(Stats.Stat stat)
        {
            foreach (var modifier in percentageModifiers)
            {
                if (modifier.stat == stat)
                {
                    yield return modifier.value;
                }
            }
        }
    }
}
