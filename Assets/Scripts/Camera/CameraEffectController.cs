using System;
using Cinemachine;
using UnityEngine;

namespace Camera
{
    public class CameraEffectController : MonoBehaviour
    {

        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        private CinemachineBasicMultiChannelPerlin effect;

        private void Start()
        {
            effect = virtualCamera.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();
        }

        private void Update()
        {
            effect.m_AmplitudeGain = 1f;
            effect.m_FrequencyGain = 1f;
        }
    }
}
