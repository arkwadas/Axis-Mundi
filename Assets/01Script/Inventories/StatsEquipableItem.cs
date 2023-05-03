
using System.Collections.Generic;
using GameDevTV.Inventories;
using RPG.Customization;
using RPG.Stats;
using RPG.Stats;
using UnityEngine;

namespace RPG.Invetories
{
    [CreateAssetMenu(menuName = ("RPG/Inventory/Equipable Item"))]
    public class StatsEquipableItem : EquipableItem, IModifierProvide
    {
        [SerializeField]
        Modifier[] additiveModifiers;
        [SerializeField]
        Modifier[] percentageModifiers;
        public SpawnArmor spawnArmor;

        [System.Serializable]
        struct Modifier
        {
            public Stats.Stat stat;
            public float value;
        }

        ;

        /*    private void Awake()
            {

                if (equipment)
                    {
                         equipment.equipmentUpdated += UpdateWeapon;
                    //SetManHelmetId();
                     }
        }



            private void SetManHelmetId()
            {
                CharacterCustomization characterCustomization = FindObjectOfType<CharacterCustomization>();
                characterCustomization.SetManHelmetId(newHelmetId);
            }
        */

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

