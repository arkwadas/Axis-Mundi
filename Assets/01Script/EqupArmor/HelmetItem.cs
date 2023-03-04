using RPG.Customization;
using UnityEngine;

namespace GameDevTV.Inventories
{
    /// <summary>
    /// An inventory item that can be equipped to the player. Weapons could be a
    /// subclass of this.
    /// </summary>
    [CreateAssetMenu(menuName = ("GameDevTV/GameDevTV.UI.InventorySystem/Helmet"))]
    public class HelmetItem : InventoryItem
    {
        // CONFIG DATA
        [Tooltip("Where are we allowed to put this item.")]
        [SerializeField] EquipLocation allowedEquipLocation = EquipLocation.Weapon;

        [SerializeField] int newHelmetId;

        private void Awake()
        {
           // SetManHelmetId();
        }

        // PUBLIC

        private void SetManHelmetId()
        {
            CharacterCustomization characterCustomization = FindObjectOfType<CharacterCustomization>();
            characterCustomization.SetManHelmetId(newHelmetId);
        }
        public EquipLocation GetAllowedEquipLocation()
        {
            return allowedEquipLocation;
        }
    }
}