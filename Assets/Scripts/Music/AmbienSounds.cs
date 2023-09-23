using System;
using System.Collections;
using UnityEngine;

namespace Music
{
    public class AmbienSounds : MonoBehaviour
    {

        [SerializeField] private AudioSource audioSourceDay;
        [SerializeField] private AudioSource audioSourceNigth;

        private void OnEnable()
        {
            StartCoroutine(StartFade(audioSourceDay, 2f, 0.2f));
        }

        private void OnDisable()
        {
            audioSourceDay.Stop();
        }

        private IEnumerator StartFade(AudioSource audioS, float duration, float targetVolume)
        {
            audioS.Play();
            float currentTime = 0;
            float start = audioS.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioS.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }

        private IEnumerator FadeOut(AudioSource audioS, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioS.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioS.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }
        
        public void ChangeMusic()
        {
            StartCoroutine(FadeOut(audioSourceDay, 3f, 0f));
            StartCoroutine(StartFade(audioSourceNigth, 4f, 0.15f));
        }
        
    }
}
