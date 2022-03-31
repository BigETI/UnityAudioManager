using UnityEngine;

/// <summary>
/// Unity audio manager namespace
/// </summary>
namespace UnityAudioManager
{
    /// <summary>
    /// An interface that represents UI sound effect data
    /// </summary>
    public interface IUISoundEffectData
    {
        /// <summary>
        /// Sound effect audio clip
        /// </summary>
        AudioClip SoundEffectAudioClip { get; }

        /// <summary>
        /// Event trigger type
        /// </summary>
        EEventTriggerType EventTriggerType { get; }
    }
}
