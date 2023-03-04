using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        CanvasGroup canvasGroup;
        Coroutine coroutineActiveFade = null;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();

        }
        
        public void FadeOutImmediate()
        {
            canvasGroup.alpha = 1;
        }

        public Coroutine FadeOut(float time)
        {
            return Fade(1, time);
        }

        public Coroutine FadeIn(float time)
        {
            return Fade(0, time);
        }

        public Coroutine Fade(float target, float time)
        {
            // Cancel runing  coroutines
            if (coroutineActiveFade != null)
            {
                StopCoroutine(coroutineActiveFade);
            }
            // run fadeout corotine
            coroutineActiveFade = StartCoroutine(FadeRoutine(target, time));
            return coroutineActiveFade;
        }

        private IEnumerator FadeRoutine(float target, float time)
        {
            while (!Mathf.Approximately(canvasGroup.alpha, target)) // alpha is not 1
            {
                canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, target, Time.deltaTime / time);
                yield return null;
            }
        }
    }
}




