
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
        [SerializeField] int newHelmetId;
        [SerializeField]
        Modifier[] additiveModifiers;
        [SerializeField]
        Modifier[] percentageModifiers;
        [SerializeField] GameObject Helmet = null; 

        [System.Serializable]
        struct Modifier
        {
            public Stats.Stat stat;
            public float value;
        }

        ;
        /*[SerializeField] private bool activateScript;

        private void Awake()
        {
            
            if (equipment)
        {
               // equipment.equipmentUpdated += UpdateWeapon;
                SetManHelmetId();
            //activateScript = false;
        }
    }

        // PUBLIC

        private void SetManHelmetId()
        {
            CharacterCustomization characterCustomization = FindObjectOfType<CharacterCustomization>();
            characterCustomization.SetManHelmetId(newHelmetId);
        }*/


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

