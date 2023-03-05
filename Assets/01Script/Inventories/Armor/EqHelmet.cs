using GameDevTV.Inventories;
using RPG.Customization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Invetories
{
    public class EqHelmet : MonoBehaviour
    {

        StatsEquipableItem helmet;
        Equipment equipmentHelmet;


        [SerializeField] int newHelmetId;
        int defaultHelmetId = 0;

        private void Update()
        {
            equipmentHelmet = GetComponent<Equipment>();
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
            characterCustomization.SetManArmorPancerzId(newHelmetId);
        }
        private void DeafoultManHelmetId()
        {
            CharacterCustomization characterCustomization = FindObjectOfType<CharacterCustomization>();
            characterCustomization.SetManArmorPancerzId(defaultHelmetId);
        }
    }
    

}
