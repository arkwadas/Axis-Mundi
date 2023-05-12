using MoreMountains.TopDownEngine;
using UnityEngine;

using UnityEngine.Events;

namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed = 1;
        [SerializeField] bool isHoming = true;
        [SerializeField] GameObject hitEffectUnknow = null;
        [SerializeField] GameObject hitEffectEnemy = null;

        [SerializeField] float maxLifeTime = 10;
        [SerializeField] GameObject[] destroyOnHit = null;
        [SerializeField] float lifeAfterImpact = 10;
        [SerializeField] UnityEvent onHit;
        Health target = null;
        Vector3 targetPoint;
        GameObject instigator = null;
        float damage = 5;



        [SerializeField] private Rigidbody rb;



        private void Update()
        {

            transform.Translate(Vector3.forward * speed * Time.deltaTime);


        }



        public void Init(Vector3 dir, GameObject instigator)
        {
            rb.velocity = dir * speed;
            this.instigator = instigator;

            Destroy(gameObject, maxLifeTime);// Prjectile zostanie zniszcozny po wyznaczonym czasi
            //transform.forward = dir;

        }

        public void SetTarget(Health target, GameObject instigator, float damage)
        {
            this.target = target;
            this.damage = damage;
            this.instigator = instigator;

            Destroy(gameObject, maxLifeTime);// Prjectile zostanie zniszcozny po wyznaczonym czasi
        }

        private Vector3 GetAimLocation()
        {
            CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
            if (targetCapsule == null)
            {
                return target.transform.position;
            }
            return target.transform.position + Vector3.up * targetCapsule.height / 2;
        }
        private void OnTriggerEnter(Collider other)
        {

             if (other.CompareTag("Enemy"))
            {
                Instantiate(hitEffectEnemy, transform.position, transform.rotation);
                //speed = 0;
                Invoke("DestroyHitEffectEnemy", 5.0f);
                Destroy(gameObject, 0.01f);
            }

            onHit.Invoke();

            Destroy(gameObject, 0.01f) ;


                if (hitEffectUnknow != null)
                {
                    Instantiate(hitEffectUnknow, transform.position, transform.rotation);
                    Invoke("DestroyHitEffectUnknow", 5.0f);
                    Destroy(gameObject, 0.1f);

            }


            foreach (GameObject toDestroy in destroyOnHit) // przypadki kiedy niszczymy projectile
                {
                    Destroy(toDestroy);
                }

                Destroy(gameObject, lifeAfterImpact);

            }
        private void DestroyHitEffectEnemy()
        {
            Destroy(hitEffectEnemy);
        }

        private void DestroyHitEffectUnknow()
        {
            Destroy(hitEffectUnknow);
        }
    }

    }
