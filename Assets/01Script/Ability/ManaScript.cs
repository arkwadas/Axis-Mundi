
using GameDevTV.Saving;
using GameDevTV.Utils;
using MoreMountains.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
   
{

public class ManaScript : MonoBehaviour, ISaveable
    {
        public Image manaBar = null;
        [SerializeField] TextMeshProUGUI manaText = null;

        /*[SerializeField] public float currentMana = 100f;

        [SerializeField] public float maxMana = 100f;
        [SerializeField] public float regenerateSpeed = 0.1f;

        private void Start()
        {
            currentMana = maxMana;
            InvokeRepeating("RegenerateMana", 1f, 1f);
        }
        private void Update()
            {
                Mana();
            }

            private void Mana()
            {
                  if (currentMana < maxMana)
                  {
                      manaBar.fillAmount = Mathf.MoveTowards(manaBar.fillAmount, 1f, Time.deltaTime * 0.01f);
                      currentMana = Mathf.MoveTowards(currentMana / maxMana, 1f, Time.deltaTime * 0.01f) * maxMana;
                  }

                  if (currentMana < 0)
                  {
                      currentMana = 0;
                  }
                manaBar.fillAmount = currentMana / maxMana;
                manaText.text = Mathf.FloorToInt(currentMana).ToString();

              }

            private void RegenerateMana()
        {
            currentMana += regenerateSpeed;
            currentMana = Mathf.Clamp(currentMana, 0, maxMana);
        }

        public void ReduceMana(float mana)
        {
            if (mana <= currentMana)
            {
                currentMana -= mana;
                manaBar.fillAmount -= mana / maxMana;
            }
            else
            {
                // noth enounth mana!
            }
               // manaBar.fillAmount = currentMana / maxMana;

            }*/
        LazyValue<float> mana;

        private void Awake()
        {
            mana = new LazyValue<float>(GetMaxMana);
        }

        private void Update()
        {
            if (mana.value < GetMaxMana())
            {
                mana.value += GetRegenRate() * Time.deltaTime;
                if (mana.value > GetMaxMana())
                {
                    mana.value = GetMaxMana();
                }
            }
            manaBar.fillAmount = GetMana() / GetMaxMana();
            manaText.text = Mathf.FloorToInt(GetMana()).ToString();
        }

        public float GetMana()
        {
            return mana.value;
        }

        public float GetMaxMana()
        {
            return GetComponent<BaseStats>().GetStat(Stats.Stat.Mana);
        }

        public float GetRegenRate()
        {
            return GetComponent<BaseStats>().GetStat(Stats.Stat.ManaRegenRate);
        }

        public bool UseMana(float manaToUse)
        {
            if (manaToUse > mana.value)
            {
                return false;
            }
            mana.value -= manaToUse;
            return true;
        }

        public object CaptureState()
        {
            return mana.value;
        }

        public void RestoreState(object state)
        {
            mana.value = (float)state;
        }
    }
}