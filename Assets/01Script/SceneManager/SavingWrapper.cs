using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using RPG.Saving;
using RPG.Core;
using UnityEngine.SceneManagement;
using MoreMountains.TopDownEngine;
using RPG.SceneManagement;
using GameDevTV.Saving;


// W TYM MIEJSCU ZAPISUJEMY WSZELKEI SKRÓTY I LOGIKE ZAPISYWANIA GRY NP F5 TO SZYBKI ZAPIS
namespace RPG.Saving
{
    public class SavingWrapper : MonoBehaviour
    {
        const string defaultSaveFile = "Save";
        [SerializeField] float fadeInTime = 0.2f;

        private void Awake()
        {
            StartCoroutine(LoadLastScene());
        }

        IEnumerator LoadLastScene()
        {
            yield return GetComponent<SavingSystem>().LoadLastScene(defaultSaveFile);

            //MO¯E TRZEBA DODA
            Fader fader = FindObjectOfType<Fader>();
            fader.FadeOutImmediate();
            yield return fader.FadeIn(fadeInTime);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Load");
                Load();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("sawe");
                Save();
            }
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Delete();
            }
        }

        public void Save()
        {
            GetComponent<SavingSystem>().Save(defaultSaveFile);
        } 

        public void Load()
        {
            // call to saving system load
            GetComponent<SavingSystem>().Load(defaultSaveFile);
        }
        public void Delete()
        //   private void OnApplicationPause(bool pause)
        {

            GetComponent<SavingSystem>().Delete(defaultSaveFile);
        }

        /*public void OnClick()
        {
            StartCoroutine(Transtion());
        }

        private IEnumerator Transtion()
        {
            if (1<0)
            {
                yield break;
            }

            //Fader fader = FindObjectOfType<Fader>();
            DontDestroyOnLoad(gameObject);

            SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
            wrapper.Save();

            yield return SceneManager.LoadSceneAsync(1);
            wrapper.Load();

            wrapper.Save();

            Destroy(gameObject);
        }*/
    }

}
