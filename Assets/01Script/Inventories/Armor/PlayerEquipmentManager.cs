using RPG.Customization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour
{
    [Header("Equipment Model Changer")]
     
    HelmetModelChanger helmetModelChanger;
    CharacterCustomization characterCustomization;
    //Chest
    // leg
    // Hand itp

    private void Awake()
    {
        characterCustomization = GetComponentInParent<CharacterCustomization>();
        helmetModelChanger = GetComponentInChildren<HelmetModelChanger>();
    }

    private void Start()
    {
        helmetModelChanger.UnEquipAllHelmetModels();
        helmetModelChanger.EquipHelmetModelByName(characterCustomization.currentHelmetEquipment.helmetModelName);
    }

    private void Update()
    {
        helmetModelChanger.EquipHelmetModelByName(characterCustomization.currentHelmetEquipment.helmetModelName);
    }
}
