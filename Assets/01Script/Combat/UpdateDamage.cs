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
    public class UpdateDamage : MonoBehaviour, ISaveable
    {
        public GameObject playerCharacter;
        public GameObject targetObject;
        public DamageOnTouch _damage;
        LazyValue<float> minDamage;
        LazyValue<float> maxDamage;

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
            minDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
            maxDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MaxDamage);
            _damage.MinDamageCaused = minDamage.value;
            _damage.MaxDamageCaused = maxDamage.value;
        }


        public object CaptureState()
        {
            throw new System.NotImplementedException();
        }

        public void RestoreState(object state)
        {
            throw new System.NotImplementedException();
        }
    }
}
