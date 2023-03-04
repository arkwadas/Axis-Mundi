using System.Collections;
using System.Collections.Generic;
using GameDevTV.Inventories;
using UnityEngine;

namespace RPG.Control
{
    [RequireComponent(typeof(Pickup))]
    public class ClickablePickup : MonoBehaviour
    {
        Pickup pickup;
        public GameObject pickupIcon;
        private bool pickedUp = false;

        private void Awake()
        {
            pickup = GetComponent<Pickup>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                pickupIcon.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                pickupIcon.SetActive(false);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.T) && pickup.CanBePickedUp() && !pickedUp)
            {
                pickup.PickupItem();
                pickedUp = true;
            }
        }
    }
}
