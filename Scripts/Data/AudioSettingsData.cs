using System;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Unity audio manager data namespace
/// </summary>
namespace UnityAudioManager.Data
{
    /// <summary>
    /// Audio settings data
    /// </summary>
    [Serializable]
    public class AudioSettingsData
    {
        /// <summary>
        /// Audio clip
        /// </summary>
        [SerializeField]
        private AudioClip audioClip = default;

        /// <summary>
        /// Output
        /// </summary>
        [SerializeField]
        private AudioMixerGroup output = default;

        /// <summary>
        /// Mute
        /// </summary>
        [SerializeField]
        private bool mute = default;

        /// <summary>
        /// Bypass effects
        /// </summary>
        [SerializeField]
        private bool bypassEffects = default;

        /// <summary>
        /// Bypass listener effects
        /// </summary>
        [SerializeField]
        private bool bypassListenerEffects = default;

        /// <summary>
        /// Bypass reverb zones
        /// </summary>
        [SerializeField]
        private bool bypassReverbZones = default;

        /// <summary>
        /// Play on awake
        /// </summary>
        [SerializeField]
        private bool playOnAwake = true;

        /// <summary>
        /// Loop
        /// </summary>
        [SerializeField]
        private bool loop = default;

        /// <summary>
        /// Priority
        /// </summary>
        [SerializeField]
        [Range(0, 256)]
        private int priority = 128;

        /// <summary>
        /// Volume
        /// </summary>
        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float volume = 1.0f;

        /// <summary>
        /// Pitch
        /// </summary>
        [SerializeField]
        [Range(-3.0f, 3.0f)]
        private float pitch = 1.0f;

        /// <summary>
        /// Stereo pan
        /// </summary>
        [SerializeField]
        [Range(-1.0f, 1.0f)]
        private float stereoPan = 0.0f;

        /// <summary>
        /// Spatial blend
        /// </summary>
        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float spatialBlend = default;

        /// <summary>
        /// Reverb zone mix
        /// </summary>
        [SerializeField]
        [Range(0.0f, 1.1f)]
        private float reverbZoneMix = 1.0f;

        /// <summary>
        /// Doppler level
        /// </summary>
        [SerializeField]
        [Range(0.0f, 5.0f)]
        private float dopplerLevel = 1.0f;

        /// <summary>
        /// Spread
        /// </summary>
        [SerializeField]
        [Range(0.0f, 360.0f)]
        private float spread = default;

        /// <summary>
        /// Volume roloff
        /// </summary>
        [SerializeField]
        private AudioRolloffMode volumeRolloff = AudioRolloffMode.Logarithmic;

        /// <summary>
        /// Minimum distance
        /// </summary>
        [SerializeField]
        private float minDistance = 1.0f;

        /// <summary>
        /// Maximum distance
        /// </summary>
        [SerializeField]
        private float maxDistance = 500.0f;

        /// <summary>
        /// Apply settings
        /// </summary>
        /// <param name="audioSource">Audio source</param>
        public void ApplySettings(AudioSource audioSource)
        {
            if (audioSource != null)
            {
                audioSource.clip = audioClip;
                audioSource.outputAudioMixerGroup = output;
                audioSource.mute = mute;
                audioSource.bypassEffects = bypassEffects;
                audioSource.bypassListenerEffects = bypassListenerEffects;
                audioSource.bypassReverbZones = bypassReverbZones;
                audioSource.playOnAwake = playOnAwake;
                audioSource.loop = loop;
                audioSource.priority = priority;
                audioSource.volume = volume;
                audioSource.pitch = pitch;
                audioSource.panStereo = stereoPan;
                audioSource.spatialBlend = spatialBlend;
                audioSource.reverbZoneMix = reverbZoneMix;
                audioSource.dopplerLevel = dopplerLevel;
                audioSource.spread = spread;
                audioSource.rolloffMode = volumeRolloff;
                audioSource.minDistance = minDistance;
                audioSource.maxDistance = maxDistance;
            }
        }
    }
}
