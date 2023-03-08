using GameDevTV.Inventories;
using RPG.Customization;
using RPG.Invetories;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetModelChanger : MonoBehaviour
{
    //CharacterCustomization helmetCharacter;
    public List<GameObject> helmetModels;
    Equipment equipment;
    CharacterCustomization characterCustomization;

    private void Awake()
    {
        GetAllHelmetModels();
        
        equipment = GetComponent<Equipment>();
        if (equipment)
        {
                // UpdateHelmet();
        }
        
    }

    

    private void GetAllHelmetModels()
    {
        int helmets = transform.childCount;

        for (int i = 0; i < helmets; i++)
        {
            helmetModels.Add(transform.GetChild(i).gameObject);
        }
    }

    public void UnEquipAllHelmetModels()
    {
        foreach (GameObject helmetModel in helmetModels)
        {
            helmetModel.SetActive(false);
        }
    }

    public void EquipHelmetModelByName(string helmetName)
    {
        for (int i = 0; i < helmetModels.Count; i++)
        {
            if (helmetModels[i].name == helmetName)
            {
                helmetModels[i].SetActive(true);
            }
        }
    }
    /*private void UpdateHelmet(GameObject currentManHelmet, string helmetModelName)
    {
        {
            var helmets = equipment.GetItemInSlot(EquipLocation.Helmet) as HelmetEquipment;
            if (helmets == null)
            {
                modelChanger.UnEquipAllHelmetModels();
            }
            else if (helmets != null)
            {
                EquipHelmetModelByName(helmetModelName);
            }


        }
    }*/
}
