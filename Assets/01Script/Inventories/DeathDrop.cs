using MoreMountains.TopDownEngine;
using RPG.Inventories;
using UnityEngine;

public class DeathDrop : MonoBehaviour
{
    public Health health;
    public RandomDropper dropper;

    private void Update()
    {
        IfDeath();
    }

    private void IfDeath()
    {
        if (health.CurrentHealth <= 0)
        {
            dropper.RandomDrop();
        }
    }
}
