using System;
using UnityEngine;

/// <summary>
/// Unity audio manager data namespace
/// </summary>
namespace UnityAudioManager.Data
{
    /// <summary>
    /// A class that describes UI sound effect data
    /// </summary>
    [Serializable]
    public class UISoundEffectData : IUISoundEffectData
    {
        /// <summary>
        /// Sound effect audio clip
        /// </summary>
        [SerializeField]
        private AudioClip soundEffectAudioClip = default;

        /// <summary>
        /// Event trigger type
        /// </summary>
        [SerializeField]
        private EEventTriggerType eventTriggerType = default;

        /// <summary>
        /// Sound effect audio clip
        /// </summary>
        public AudioClip SoundEffectAudioClip => soundEffectAudioClip;

        /// <summary>
        /// Event trigger type
        /// </summary>
        public EEventTriggerType EventTriggerType => eventTriggerType;
    }
}
