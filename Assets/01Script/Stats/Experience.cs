
using UnityEngine;
using RPG.Saving;
using System;
using UnityEngine.UI;
using MoreMountains.Tools;
using GameDevTV.Saving;

namespace RPG.Stats

{
    public class Experience : MonoBehaviour, ISaveable
    {
        [SerializeField] float experiencePoint = 0;


        BaseStats baseStats;
        public event Action onExperienceGained;

        
        public void GainExperience(float experience)
        {
            experiencePoint += experience;
            onExperienceGained();
        }
        public float GetPoints()
        {
            return experiencePoint;
        }

        public object CaptureState()
        {
            return experiencePoint;
        }

        public void RestoreState(object state)
        {
            experiencePoint = (float)state;
        }

        private void UpdateExperienceSlider()
        {
            BaseStats baseStat = GetComponent<BaseStats>();
            float currentXP = GetComponent<Experience>().GetPoints();
            int currentLevel = baseStat.CalculateLevel();

            float XPToLevelUP = baseStat.progression.GetStat(Stat.ExperienceToLevelUp, baseStat.characterClass, currentLevel);
            float XPPercent = currentXP / XPToLevelUP;
            //experienceSlider.value = XPPercent;
            
        }

        
    }
}


