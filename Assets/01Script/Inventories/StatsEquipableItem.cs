
using System.Collections.Generic;
using GameDevTV.Inventories;
using RPG.Customization;
using RPG.Stat;
using RPG.Stats;
using UnityEngine;

namespace RPG.Invetories
{
    [CreateAssetMenu(menuName = ("RPG/Inventory/Equipable Item"))]
    public class StatsEquipableItem : EquipableItem, IModifierProvide
    {
        private Equipment equipment;
        //[SerializeField] int newHelmetId;
        [SerializeField]
        Modifier[] additiveModifiers;
        [SerializeField]
        Modifier[] percentageModifiers;

        [System.Serializable]
        struct Modifier
        {
            public Stats.Stat stat;
            public float value;
        }

        ;

        StatsEquipableItem helmet;
        Equipment equipmentHelmet;


        [SerializeField] int newHelmetId;
        int defaultHelmetId = 0;

        private void Awake()
        {
            
            if (equipmentHelmet)
            {
                equipmentHelmet.equipmentUpdated += UpdateHelmet;
            }
        }

        private void UpdateHelmet()
        {
            var helmet = equipmentHelmet.GetItemInSlot(EquipLocation.Helmet) as StatsEquipableItem;
            if (helmet == null)
            {
                SetManHelmetId();
            }
            else
            {
                DeafoultManHelmetId();
            }
        }
        private void SetManHelmetId()
        {
            CharacterCustomization characterCustomization = FindObjectOfType<CharacterCustomization>();
            characterCustomization.SetManHelmetId(newHelmetId);
        }
        private void DeafoultManHelmetId()
        {
            CharacterCustomization characterCustomization = FindObjectOfType<CharacterCustomization>();
            characterCustomization.SetManHelmetId(defaultHelmetId);
        }

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

