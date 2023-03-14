using GameDevTV.Utils;
//using RPG.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Stats;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using MoreMountains.TopDownEngine;
using RPG.Combat;
using GameDevTV.Inventories;
using RPG.Invetories;
using TMPro;

//namespace RPG.Stats
namespace MoreMountains.Tools
{
    /// <summary>
    /// TODO_DESCRIPTION
    /// </summary>
    //[AddComponentMenu("More Mountains/Tools/GUI/MMHealthBar")]

    public class BaseStats : MonoBehaviour
    {
        [Range(1, 99)]
        [SerializeField] int startingLevel = 1;
        public CharacterClass characterClass;
        public Progression progression = null;
        [SerializeField] GameObject levelUpParticle = null; // WYWO£ANIE EFFEKTU!!! PONI¯EJ METODA I WYWO£ANIE DO NIEGO
        [SerializeField] bool shouldUseModifires = false;


        public event Action onLevelUp;

        LazyValue<int> currentLevel;
        Experience experience;

        protected Health _health;



        public virtual void Awake()
        {
            // Initialization();
            experience = GetComponent<Experience>();
            currentLevel = new LazyValue<int>(CalculateLevel);
            
        }

        private void Start()
        {
            currentLevel.ForceInit();
            //GetHealth();
        }

        private void Update()
        {
            //currentLevel.ForceInit(); //dla lazy value

            //UpdateHealth();
            // SetActiveHelmet();


        }
        private void OnEnable()
        {
            if (experience != null)
            {
                experience.onExperienceGained += UpdateLevel;
            }
        }

        private void OnDisable()
        {
            if (experience != null)
            {
                experience.onExperienceGained -= UpdateLevel;
            }
        }

        private void UpdateLevel()
        {
            int newLevel = CalculateLevel();
            if (newLevel > currentLevel.value)
            {
                currentLevel.value = newLevel;
                LevelUpEffect(); // WYWO£ANIE W UPDACIE LEVELU ALE TAK SMAO MO¯E BYÆ DO UFERZENIA!
                onLevelUp(); // metoda która da wszystko co daje level up
            }

        }

        private void LevelUpEffect()    // METODA WYTWORZENIA EFEKTU W  EMPTY OBIEKCIE + PARTICLE WEWNATRZ NEIGO
        { // Aktuala instacja sprawia ¿e efetkza obiektem pod¹¿a
            Instantiate(levelUpParticle, transform);    // Instantiate pozwala np okreœliæ pozycje wywo³ania efektu, mo¿na to ustawiæ an hit Effect
        }

        
        public float GetStat(Stat stat)
        {
            return (GetBaseStat(stat) + GetAdditiveModifier(stat)) * (1 + GetProcentageModifire(stat) / 100);
        }



        public float GetBaseStat(Stat stat)
        {
            return progression.GetStat(stat, characterClass, GetLevel());
        }


        public int GetLevel()
        {

            return currentLevel.value;
        }

        
            private float GetAdditiveModifier(Stat stat)
            {
                if (!shouldUseModifires) return 0;

                float total = 0;
                foreach (IModifierProvide provider in GetComponents<IModifierProvide>())
                {
                    foreach (float modifier in provider.GetAdditiveModifier(stat))
                    {
                        total += modifier;
                    }
                }
                return total;
            }
        

        private float GetProcentageModifire(Stat stat)
        {
            if (!shouldUseModifires) return 0;
            float total = 0;
            foreach (IModifierProvide provide in GetComponents<IModifierProvide>())
            {
                foreach (float modifiers in provide.GetProcentageModifire(stat))
                {
                    total += modifiers;
                }
            }
            return total;
        }

        public int CalculateLevel()
        {
            Experience experience = GetComponent<Experience>();

            if (experience == null) return startingLevel;

            float currentXP = GetComponent<Experience>().GetPoints();
            int penultimateLevel = progression.GetLevels(Stat.ExperienceToLevelUp, characterClass);
            for (int level = 1; level <= penultimateLevel; level++)
            {
                float XPToLevelUP = progression.GetStat(Stat.ExperienceToLevelUp, characterClass, level);
                if (XPToLevelUP > currentXP)
                {
                    return level;
                }
                if (XPToLevelUP > currentXP)
                {
                   
                    return level;
                }
            }
            return penultimateLevel + 1;
        }
        
    }
}
