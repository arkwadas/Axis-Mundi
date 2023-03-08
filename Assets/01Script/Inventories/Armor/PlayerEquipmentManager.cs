using GameDevTV.Inventories;
using MoreMountains.TopDownEngine;
using RPG.Customization;
using RPG.Invetories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour
{
    Equipment equipment;
    [SerializeField] Health player;

    [Header("Equipment Model Changer")]
     
    HelmetModelChanger helmetModelChanger;
    CharacterCustomization characterCustomization;
    TorsoModelChanger torsoModelChanger;
    
    // leg
    // Hand itp

    [Header("Default Naked Models")]
    public string nakedHelmetModel;
    public string nakedTorseModel;

    private void Awake()
    {
        characterCustomization = GetComponentInParent<CharacterCustomization>();
        helmetModelChanger = GetComponentInChildren<HelmetModelChanger>();
        torsoModelChanger = GetComponentInChildren<TorsoModelChanger>();

    }

    private void Start()
    {
        player = GetComponent<Health>();
        EquipAllEquipmentModelsOnStart();
    }

    private void EquipAllEquipmentModelsOnStart()
    {
        //Helmet
        helmetModelChanger.UnEquipAllHelmetModels();
        var helmet = equipment.GetItemInSlot(EquipLocation.Helmet) as HelmetEquipment;
        if (helmet != null)
        {
            helmetModelChanger.EquipHelmetModelByName(characterCustomization.currentHelmetEquipment.helmetModelName);
        }
        else
        {
            helmetModelChanger.EquipHelmetModelByName(nakedHelmetModel);
        }

        //Next Pancerz
        torsoModelChanger.UnEquipAllTorsotModels();
        var torse = equipment.GetItemInSlot(EquipLocation.Trousers) as TorseEquipment;
        if (torse != null)
        {
            torsoModelChanger.EquipTorsoModelByName(characterCustomization.currentTorseEquipment.torseModelName);
        }
        else
        {
            torsoModelChanger.EquipTorsoModelByName(nakedTorseModel);
        }
    }


    public void OpenBlockingColider()
    {
        // kod dlaa 2 recznosci
    }

   
}
