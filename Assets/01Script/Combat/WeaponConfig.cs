using UnityEngine;
using GameDevTV.Inventories;
using RPG.Stats;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using RPG.Control;
using System;
using RPG.Customization;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class WeaponConfig : EquipableItem, IModifierProvide
    {
        public CharacterClass characterClass;
        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] Weapon equippedPrefab = null;
        Equipment equipment;
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] float weaponMaxDamage = 5f;
        [SerializeField] float percentageBonus = 0;
        [SerializeField] float weaponRange = 2f;
        [SerializeField] bool isRightHanded = true;
        [SerializeField] Projectile projectile = null;
        [SerializeField] float timeBetweenShots = 0.5f;



        [SerializeField] int newId;

        const string weaponName = "Weapon";

        private void Awake()
        {
            
        }

        private void SetManArmorPancerzId()
        {
            CharacterCustomization characterCustomization = FindObjectOfType<CharacterCustomization>();
            characterCustomization.SetManArmorPancerzId(newId);
        }


        public Weapon Spawn(Transform rightHand, Transform leftHand, Animator animator)
         {
             DestroyOldWeapon(rightHand, leftHand);
            //ActivateOutfill();
             Weapon weapon = null;

             if (equippedPrefab != null)
             {
                 Transform handTransform = GetTransform(rightHand, leftHand);
                 weapon = Instantiate(equippedPrefab, handTransform);
                 weapon.gameObject.name = weaponName;
                 SetManArmorPancerzId();
                
            }


            Animator weaponAnimator = weapon.GetComponentInChildren<Animator>();
            if (weaponAnimator != null)
            {
                // If the Animator component is found, set it to the provided animator parameter.
                animator = weaponAnimator;
            }

            var overrideController = animator.runtimeAnimatorController as AnimatorOverrideController;
            if (animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride; 
            }
            else if (overrideController != null)
            {
                animator.runtimeAnimatorController = overrideController.runtimeAnimatorController;
            }

            return weapon;
        }


        private void DestroyOldWeapon(Transform rightHand, Transform leftHand)
        {
            Transform oldWeapon = rightHand.Find(weaponName);
            if (oldWeapon == null)
            {
                oldWeapon = leftHand.Find(weaponName);
            }
            if (oldWeapon == null) return;

            oldWeapon.name = "DESTROYING";
            Destroy(oldWeapon.gameObject);
        }

        private Transform GetTransform(Transform rightHand, Transform leftHand)
        {
            Transform handTransform;
            if (isRightHanded) handTransform = rightHand;
            else handTransform = leftHand;
            return handTransform;
        }

        public bool HasProjectile()
        {
            return projectile != null;
        }

        public void LaunchProjectile(Health target ,Transform rightHand, Transform leftHand, Transform target2, GameObject instigator, float calculateDamage)
        {
            Projectile projectileInstant = Instantiate(projectile, GetTransform(rightHand, leftHand).position, Quaternion.identity);
            projectileInstant.SetTarget(target, instigator, calculateDamage);
            projectileInstant.Init(target2.forward, instigator);
        }
        /*public void LaunchProjectile(Transform target, GameObject instigator, float calculateDamage)
        {
            Projectile projectileInstant = Instantiate(projectile, target.position, Quaternion.identity);
            projectileInstant.Init(target.forward, instigator);
        }*/


        private Vector3 GetMouseWorldPosition()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }

        public float GetDamage()
        {
            return weaponDamage;
        }

        public float GetMaxDamage()
        {
            return weaponMaxDamage;
        }

        public float GetPercentageBonus()
        {
            return percentageBonus;
        }

        public float GetRange()
        {
            return weaponRange;
        }

        public float GetTimeBetweenShots()
        {
            return timeBetweenShots;
        }

        public IEnumerable<float> GetAdditiveModifiers(Stats.Stat stat)
        {
            if (stat == Stats.Stat.MinDamage)
            {
                yield return weaponDamage;
            }
            if (stat == Stats.Stat.MaxDamage)
            {
                yield return weaponMaxDamage;
            }
        }

        public IEnumerable<float> GetPercentageModifiers(Stats.Stat stat)
        {
            if (stat == Stats.Stat.MinDamage)
            {
                yield return weaponDamage;
            }
            if (stat == Stats.Stat.MaxDamage)
            {
                yield return weaponMaxDamage;
            }
        }
        /*public float GetWeaponAnimTime(Animator animator)
        {
            return animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        }
        */
        public void PlayAttackSFX(Weapon weapons)
        {
           
            weapons.OnHit();
        }

        public IEnumerable<float> GetAdditiveModifier(Stats.Stat stat)
        {
            if (stat == Stats.Stat.MinDamage)
            {
                yield return percentageBonus;
            }
            if (stat == Stats.Stat.MaxDamage)
            {
                yield return percentageBonus;
            }
        }

            public IEnumerable<float> GetProcentageModifire(Stats.Stat stat)
        {
            if (stat == Stats.Stat.Health)
            {
                yield return weaponDamage;
            }
            
        }
        
    }
}
