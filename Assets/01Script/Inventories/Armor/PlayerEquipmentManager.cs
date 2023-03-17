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
    public List<GameObject> hideWhenTorseActivate;
    LazyValue<float> rightArm;
    [SerializeField] GameObject[] RightArm;
    public List<GameObject> hideWhenRightArmActivate;
    LazyValue<float> leftArm;
    [SerializeField] GameObject[] LeftArm;
    public List<GameObject> hideWhenLeftArmActivate;
    LazyValue<float> hips;
    [SerializeField] GameObject[] Hips;
    public List<GameObject> hideWhenHipsActivate;

    //Hands
    LazyValue<float> rightHands;
    [SerializeField] GameObject[] RightHands;
    public List<GameObject> hideWhenRightHandsActivate;
    LazyValue<float> leftHands;
    [SerializeField] GameObject[] LeftHands;
    public List<GameObject> hideWhenLeftHandsActivate;

    //Shoes
    LazyValue<float> rightShoes;
    [SerializeField] GameObject[] RightShoes;
    public List<GameObject> hideWhenRightShoesActivate;
    LazyValue<float> leftShoes;
    [SerializeField] GameObject[] LeftShoes;
    public List<GameObject> hideWhenLeftShoesActivate;

    //MAN EQUIPMENT
    //Head
    LazyValue<float> famelehelmet;
    [SerializeField] GameObject[] fameleHelmets;
    public List<GameObject> famelehideWhenHelmetActivate;

    //Torse
    LazyValue<float> fameletorse;
    [SerializeField] GameObject[] fameleTorse;
    public List<GameObject> famelehideWhenTorseActivate;
    LazyValue<float> famelerightArm;
    [SerializeField] GameObject[] fameleRightArm;
    public List<GameObject> famelehideWhenRightArmActivate;
    LazyValue<float> fameleleftArm;
    [SerializeField] GameObject[] fameleLeftArm;
    public List<GameObject> famelehideWhenLeftArmActivate;
    LazyValue<float> famelehips;
    [SerializeField] GameObject[] fameleHips;
    public List<GameObject> famelehideWhenHipsActivate;

    //Hands
    LazyValue<float> famelerightHands;
    [SerializeField] GameObject[] fameleRightHands;
    public List<GameObject> famelehideWhenRightHandsActivate;
    LazyValue<float> fameleleftHands;
    [SerializeField] GameObject[] fameleLeftHands;
    public List<GameObject> famelehideWhenLeftHandsActivate;

    //Shoes
    LazyValue<float> famelerightShoes;
    [SerializeField] GameObject[] fameleRightShoes;
    public List<GameObject> famelehideWhenRightShoesActivate;
    LazyValue<float> fameleleftShoes;
    [SerializeField] GameObject[] fameleLeftShoes;
    public List<GameObject> famelehideWhenLeftShoesActivate;

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
