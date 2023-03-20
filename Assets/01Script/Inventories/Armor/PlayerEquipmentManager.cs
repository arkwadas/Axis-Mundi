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

    



    private int activeHelmetIndex = -1;
    private int activeTorseIndex = -1;
    // leg
    // Hand itp

    [Header("Default Naked Models")]
    public string nakedHelmetModel;
    public string nakedTorseModel;

    [SerializeField] TextMeshProUGUI CurrentHelmet = null;

//MAN EQUIPMENT
    //Head
    LazyValue<float> helmet;   
    [SerializeField]GameObject[] Helmets;
    public List<GameObject> hideWhenHelmetActivate;

    //Torse
    LazyValue<float> torse;
    [SerializeField] GameObject[] Torse;

    [SerializeField] GameObject[] RightArm;

    [SerializeField] GameObject[] LeftArm;

    [SerializeField] GameObject[] LowerRightArm;

    [SerializeField] GameObject[] LowerLeftArm;

    [SerializeField] GameObject[] Hips;


    //Hands
    LazyValue<float> hands;
    [SerializeField] GameObject[] RightHands;

    [SerializeField] GameObject[] LeftHands;

    //Shoes
    LazyValue<float> shoes;
    [SerializeField] GameObject[] RightShoes;

    [SerializeField] GameObject[] LeftShoes;

    //MAN EQUIPMENT
    //Head
    [SerializeField] GameObject[] fameleHelmets;

    //Torse
    [SerializeField] GameObject[] fameleTorse;

    [SerializeField] GameObject[] fameleRightArm;

    [SerializeField] GameObject[] fameleLeftArm;

    [SerializeField] GameObject[] fameleLowerRightArm;

    [SerializeField] GameObject[] fameleLowerLeftArm;

    [SerializeField] GameObject[] fameleHips;


    //Hands
    [SerializeField] GameObject[] fameleRightHands;

    [SerializeField] GameObject[] fameleLeftHands;


    //Shoes

    [SerializeField] GameObject[] fameleRightShoes;

    [SerializeField] GameObject[] fameleLeftShoes;

    //Peleryna
    LazyValue<float> pelerynas;
    [SerializeField] GameObject[] peleryna;

    //shield
    LazyValue<float> shields;
    [SerializeField] GameObject[] shield;

    private void Awake()
    {
        torse = new LazyValue<float>(GetMaxTorse);
        helmet = new LazyValue<float>(GetMaxHelmet);
        //characterCustomization = GetComponentInParent<CharacterCustomization>();
        //helmetModelChanger = GetComponentInChildren<HelmetModelChanger>();
       

        
    }

    private void Update()
    {
        int index = Mathf.RoundToInt(GetMaxHelmet()) - 1;
        if (index != activeHelmetIndex)
        {
            ActivateHelmet();
        }
        if (index > 1)
        {
            UnEquipAllHelmetModels();
        }
        else
        {
            EquipAllHelmetModels();
        }

        int indexTotse = Mathf.RoundToInt(GetMaxTorse()) - 1;
        if (indexTotse != activeTorseIndex)
        {
            ActivateTorse();
        }
        
    }

    private void Start()
    {
        ActivateHelmet();
        ActivateTorse();
       // EquipAllEquipmentModelsOnStart();
    }

    void SetActive(GameObject[] objects, int index)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (i == index)
            {
                objects[i].SetActive(true);
            }
            else if (objects[i].activeSelf)
            {
                objects[i].SetActive(false);
            }
        }
    }

    void ActivateHelmet()
    {
        int index = Mathf.RoundToInt(GetMaxHelmet()) - 1;
        if (index >= 0 && index < Torse.Length && index != activeTorseIndex)
        {
            activeTorseIndex = index;
            //man
            SetActive(Helmets, index);
            //Famele
            SetActive(fameleHelmets, index);

        }
       
        /*if (index >= 0 && index < Helmets.Length && index != activeHelmetIndex)
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
        }*/
    }

    public void UnEquipAllHelmetModels()
    {
        foreach (GameObject hide in hideWhenHelmetActivate)
        {
            hide.SetActive(false);
        }
    }

    public void EquipAllHelmetModels()
    {
        foreach (GameObject hide in hideWhenHelmetActivate)
        {
            hide.SetActive(true);
        }
    }

    void ActivateTorse()
    {
        int index = Mathf.RoundToInt(GetMaxTorse()) - 1;

        if (index >= 0 && index < Torse.Length && index != activeTorseIndex)
        {
            activeTorseIndex = index;
            //man
            SetActive(Torse, index);
            SetActive(RightArm, index);
            SetActive(LeftArm, index);
            SetActive(Hips, index);
            //famele
            SetActive(fameleTorse, index);
            SetActive(fameleRightArm, index);
            SetActive(fameleLeftArm, index);
            SetActive(fameleHips, index);
        }
    }

    void ActivateHands()
    {
        int index = Mathf.RoundToInt(GetMaxHands()) - 1;

        if (index >= 0 && index < RightHands.Length && index != activeTorseIndex)
        {
            activeTorseIndex = index;
            //man
            SetActive(RightHands, index);
            SetActive(LeftHands, index);
            SetActive(fameleLeftHands, index);
            SetActive(fameleRightHands, index);
        }
    }

    void ActivateShoes()
    {
        int index = Mathf.RoundToInt(GetMaxShoes()) - 1;

        if (index >= 0 && index < Torse.Length && index != activeTorseIndex)
        {
            activeTorseIndex = index;
            //man
            SetActive(Torse, index);
            SetActive(Torse, index);
            SetActive(Torse, index);
            SetActive(Torse, index);
        }
    }

    void ActivatePeleryna()
    {
        int index = Mathf.RoundToInt(GetMaxPeleryna()) - 1;

        if (index >= 0 && index < Torse.Length && index != activeTorseIndex)
        {
            activeTorseIndex = index;
            //man
            SetActive(Torse, index);
        }
    }

    void ActivateShield()
    {
        int index = Mathf.RoundToInt(GetMaxShield()) - 1;

        if (index >= 0 && index < Torse.Length && index != activeTorseIndex)
        {
            activeTorseIndex = index;
            //man
            SetActive(Torse, index);
        }
    }

    void ActivateHelmetNoHair()
    {
        int index = Mathf.RoundToInt(GetMaxHelmetNoHair()) - 1;

        if (index >= 0 && index < Torse.Length && index != activeTorseIndex)
        {
            activeTorseIndex = index;
            //man
            SetActive(Torse, index);
        }
    }

    void ActivateHelmetDodatki()
    {
        int index = Mathf.RoundToInt(GetMaxHelmetDodatki()) - 1;

        if (index >= 0 && index < Torse.Length && index != activeTorseIndex)
        {
            activeTorseIndex = index;
            //man
            SetActive(Torse, index);
        }
    }

    void ActivateMask()
    {
        int index = Mathf.RoundToInt(GetMaxMask()) - 1;

        if (index >= 0 && index < Torse.Length && index != activeTorseIndex)
        {
            activeTorseIndex = index;
            //man
            SetActive(Torse, index);
        }
    }

    public float GetMaxHelmet()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Helmet);
    }
    public float GetMaxTorse()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Torse);
    }
    public float GetMaxPeleryna()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Peleryna);
    }
    public float GetMaxHands()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Hands);
    }
    public float GetMaxShoes()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Shoes);
    }
    public float GetMaxShield()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Shield);
    }
    //Inne
    public float GetMaxHelmetNoHair()
    {
        return GetComponent<BaseStats>().GetStat(Stat.HelmetNoHair);
    }
    public float GetMaxHelmetDodatki()
    {
        return GetComponent<BaseStats>().GetStat(Stat.HelmetDodatek);
    }
    public float GetMaxMask()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Mask);
    }
    public float GetMaxDefense()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Defence);
    }

    public void OpenBlockingColider()
    {
        // kod dlaa 2 recznosci
    }

    public object CaptureState()
    {
        return helmet.value;
        return torse.value;
    }

    public void RestoreState(object state)
    {
        torse.value = (float)state;
        helmet.value = (float)state;
    }


}
