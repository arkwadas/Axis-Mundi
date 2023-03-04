using GameDevTV.Inventories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEqup : MonoBehaviour
{

    Equipment equipmentHelmet;
    HelmetItem itemHelmet;
    private void Awake()
    {
        equipmentHelmet = GetComponent<Equipment>();
        if (equipmentHelmet)
        {
            equipmentHelmet.equipmentUpdated += UpdateHelmet;
        }
    }

    private void UpdateHelmet()
    {
      //  var helmetItem = equipmentHelmet.GetItemInSlot(EquipLocation.Helmet) as HelmetItem;
    }
    
}


