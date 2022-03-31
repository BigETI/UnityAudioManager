using System;
using UnityEngine;
using UnityPatterns;

/// <summary>
/// Unity audio manager namespace
/// </summary>
namespace UnityAudioManager
{
    /// <summary>
    /// An interface that represents an audio clip player controller
    /// </summary>
    public interface IAudioClipPlayerController : IController
    {
        /// <summary>
        /// Audio clip
        /// </summary>
        AudioClip AudioClip { get; set; }

        /// <summary>
        /// Plays sound effect
        /// </summary>
        void PlaySoundEffect();

        /// <summary>
        /// Plays sound effect
        /// </summary>
        /// <param name="soundEffectAudioClip">Sound effect audio clip</param>
        /// <exception cref="ArgumentNullException">When "soundEffectAudioClip" is "null"</exception>
        void PlaySoundEffect(AudioClip soundEffectAudioClip);

        /// <summary>
        /// Plays music
        /// </summary>
        void PlayMusic();

        /// <summary>
        /// Plays music
        /// </summary>
        /// <param name="musicAudioClip">Music audio clip</param>
        /// <exception cref="ArgumentNullException">When "musicAudioClip" is "null"</exception>
        void PlayMusic(AudioClip musicAudioClip);

        /// <summary>
        /// Plays music delayed
        /// </summary>
        /// <param name="delayTime">Delay time</param>
        void PlayMusicDelayed(float delayTime);

        /// <summary>
        /// Plays music delayed
        /// </summary>
        /// <param name="musicAudioClip">Music audio clip</param>
        /// <param name="delayTime">Delay time</param>
        /// <exception cref="ArgumentNullException">When "musicAudioClip" is "null"</exception>
        void PlayMusicDelayed(AudioClip musicAudioClip, float delayTime);
    }
}
