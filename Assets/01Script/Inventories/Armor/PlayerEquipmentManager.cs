using GameDevTV.Inventories;
using GameDevTV.Saving;
using GameDevTV.Utils;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using RPG.Customization;
using RPG.Invetories;
using RPG.Stats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour, ISaveable
{
    [SerializeField]Equipment equipment;

    [Header("Equipment Model Changer")]

    public List<GameObject> hideWhenHelmetActivate;

    HelmetModelChanger helmetModelChanger;
    CharacterCustomization characterCustomization;
    TorsoModelChanger torsoModelChanger;

    private int activeHelmetIndex = -1;
    // leg
    // Hand itp

    [Header("Default Naked Models")]
    public string nakedHelmetModel;
    public string nakedTorseModel;

    [SerializeField] TextMeshProUGUI CurrentHelmet = null;
    LazyValue<float> helmet;

    [SerializeField]GameObject[] Helmets;

 

    private void Awake()
    {

        helmet = new LazyValue<float>(GetMaxHelmet);
        //characterCustomization = GetComponentInParent<CharacterCustomization>();
        //helmetModelChanger = GetComponentInChildren<HelmetModelChanger>();
       

        
    }

    private void Update()
    {
        //CurrentHelmet.text = Mathf.FloorToInt(GetMaxHelmet()).ToString();
        int index = Mathf.RoundToInt(GetMaxHelmet()) - 1;
        if (index != activeHelmetIndex)
        {
            ActivateHelmet();
        }
        if (index > 1)
        {
            UnEquipAllHelmetModels();
        }
    }

    private void Start()
    {
        ActivateHelmet();
       // EquipAllEquipmentModelsOnStart();
    }


    public void UnEquipAllHelmetModels()
    {
        foreach (GameObject hide in hideWhenHelmetActivate)
        {
            hide.SetActive(false);
        }
    }

    void ActivateHelmet()
    {
        int index = Mathf.RoundToInt(GetMaxHelmet()) - 1;
        if (index >= 0 && index < Helmets.Length && index != activeHelmetIndex)
        {
            activeHelmetIndex = index;
            for (int i = 0; i < Helmets.Length; i++)
            {
                if (i == index)
                {
                    Helmets[i].SetActive(true);
                }
                else if (Helmets[i].activeSelf)
                {
                    Helmets[i].SetActive(false);
                }
            }
        }
    }


    public float GetMaxHelmet()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Helmet);
    }

    private void EquipAllEquipmentModelsOnStart()
     {
         //Helmet
         //currentHelmetEquipment = equipment.GetItemInSlot(EquipLocation.Helmet) as HelmetEquipment;
        // helmetModelChanger.UnEquipAllHelmetModels();
         if (characterCustomization.currentHelmetEquipment !=null)
         {
             helmetModelChanger.EquipHelmetModelByName(characterCustomization.currentHelmetEquipment.helmetModelName);
         }
         else
         {
             helmetModelChanger.EquipHelmetModelByName(nakedHelmetModel);
         }

         //Next Pancerz
        /* torsoModelChanger.UnEquipAllTorsotModels();
         var torse = equipment.GetItemInSlot(EquipLocation.Trousers) as TorseEquipment;
         if (torse != null)
         {
             torsoModelChanger.EquipTorsoModelByName(characterCustomization.currentTorseEquipment.torseModelName);
         }
         else
         {
             torsoModelChanger.EquipTorsoModelByName(nakedTorseModel);
         }*/
     }

   
    public void OpenBlockingColider()
    {
        // kod dlaa 2 recznosci
    }

    public object CaptureState()
    {
        return helmet.value;
    }

    public void RestoreState(object state)
    {
        helmet.value = (float)state;
    }


}
