using System;
using UnityEngine;

/// <summary>
/// Unity audio manager data namespace
/// </summary>
namespace UnityAudioManager.Data
{
    /// <summary>
    /// UI sound effect data
    /// </summary>
    [Serializable]
    public class UISoundEffectData
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
        public AudioClip SoundEffectAudioClip
        {
            get
            {
                return soundEffectAudioClip;
            }
        }

        /// <summary>
        /// Event trigger type
        /// </summary>
        public EEventTriggerType EventTriggerType
        {
            get
            {
                return eventTriggerType;
            }
        }
    }
}
