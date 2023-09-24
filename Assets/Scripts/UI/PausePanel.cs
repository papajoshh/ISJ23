using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class PausePanel : MonoBehaviour
    {
        [Header("[References]")]
        [SerializeField] private AudioMixer audiomixer;
        [SerializeField] private Slider volumeSlider;

        private void OnEnable()
        {
            audiomixer.GetFloat("Master", out float currentVolume);
            volumeSlider.value = Mathf.Pow(10, currentVolume / 20);

            volumeSlider.onValueChanged.AddListener(SetMusicVolume);

            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            volumeSlider.onValueChanged.RemoveListener(SetMusicVolume);
            Time.timeScale = 1;
        }

        private void SetMusicVolume(float sliderValue)
        {
            audiomixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);

            if (sliderValue <= 0)
                audiomixer.SetFloat("Master", -80);
        }

        public void OnClick_Resume()
        {
            gameObject.SetActive(false);
        }

        public void OnClick_Settings()
        {
            Debug.Log("(TODO) Programar opciones ingame");
        }

        public void OnClick_MainMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
