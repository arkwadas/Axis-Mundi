using System.Collections;
using System.Collections.Generic;
using GameDevTV.Utils;
using UnityEngine;
using RPG.Stats;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;
using UnityEngine.Events;
using RPG.Core;
using GameDevTV.Saving;

namespace RPG.Combat
{
    public class UpdateDamage : MonoBehaviour//, ISaveable
    {
        public GameObject playerCharacter;
        public GameObject targetObject;
        public DamageOnTouch _damage;
        LazyValue<float> minDamage;
        LazyValue<float> maxDamage;
        DamageOnTouch damageComponen;

        private void Awake()
        {

            //_damage = GetComponent<DamageOnTouch>();
            minDamage = new LazyValue<float>(GetInitialMinDamage);
            maxDamage = new LazyValue<float>(GetInitialMaxDamage);
        }

        private void Start()
        {
            //ToSameDamage();
        }

        // Update is called once per frame
        void Update()
        {
            ToSameDamage();
        }

        public float GetInitialMinDamage()
        {
            return playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
           // return GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
        }
        public float GetInitialMaxDamage()
        {
            return playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MaxDamage);
            //return GetComponent<BaseStats>().GetStat(Stats.Stat.MaxDamage);
        }

        public void ToSameDamage()
        {
            _damage = targetObject.GetComponent<DamageOnTouch>();
            float defence = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.Defence); 
            minDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
            maxDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MaxDamage);
            _damage.MinDamageCaused = minDamage.value;
            minDamage.value /= 1 + defence / minDamage.value;
            _damage.MaxDamageCaused = maxDamage.value;
            maxDamage.value /= 1 + defence / maxDamage.value;
        }
        private void OnCollisionEnter(Collision collision)
        {
            GameObject targetObject = collision.gameObject;
            DamageOnTouch damageComponent = targetObject.GetComponent<DamageOnTouch>();

            if (damageComponent != null)
            {
                float defence = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.Defence);
                float minDamage = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
                float maxDamage = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MaxDamage);

                damageComponent.MinDamageCaused = minDamage;
                damageComponent.MaxDamageCaused = maxDamage;

                // Zmiana ataku na podstawie obrony gracza
                minDamage /= 1 + defence / minDamage;
                maxDamage /= 1 + defence / maxDamage;
            }
        }

        /* public object CaptureState()
         {
             throw new System.NotImplementedException();
         }

         public void RestoreState(object state)
         {
             throw new System.NotImplementedException();
         }*/
    }
}
