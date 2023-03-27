using GameDevTV.UI;
using RPG.Control;
using UnityEngine;

namespace GameDevTV.Inventories
{
    [RequireComponent(typeof(Inventory))]
    public class OtherInventory : MonoBehaviour
    {
        [SerializeField] GameObject player;
        public GameObject pickupIcon;
        [SerializeField] float interactDistance = 3f;
        public GameObject[] Disable;

        private bool isPlayerInRange = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player)
            {
                isPlayerInRange = true;
                pickupIcon.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == player)
            {
                isPlayerInRange = false;
                pickupIcon.SetActive(false);
            }
        }

        private void Update()
        {
            if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= interactDistance)
                {
                    FindObjectOfType<ShowHideUI>().ShowOtherInventory(gameObject);
                }
            }
        }
    }
}