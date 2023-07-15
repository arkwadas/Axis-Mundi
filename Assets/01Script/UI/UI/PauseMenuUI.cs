using MoreMountains.TopDownEngine;
using RPG.Control;
using RPG.SceneManagement;
using UnityEngine;

namespace RPG.UI
{
    public class PauseMenuUI : MonoBehaviour
    {

        Attack playerController;
        [SerializeField] GameObject wylaczGdyAktywnyIUruchom = null;

        private void Start() {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
            wylaczGdyAktywnyIUruchom.SetActive(true);
        }

        private void OnEnable()
        {
            wylaczGdyAktywnyIUruchom.SetActive(false);
            if (playerController == null) return;
            Time.timeScale = 0;
            playerController.enabled = false;
            

        }

        private void OnDisable()
        {
            //wylaczGdyAktywnyIUruchom.SetActive(true);
            if (playerController == null) return;
            Time.timeScale = 1;
            playerController.enabled = true;
            
        }

        public void Save()
        {
            SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();
            savingWrapper.Save();
        }

        public void SaveAndQuit()
        {
            SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();
            savingWrapper.Save();
            savingWrapper.LoadMenu();
        }
    }
}