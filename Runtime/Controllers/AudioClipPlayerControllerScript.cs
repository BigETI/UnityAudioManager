using System;
using UnityEngine;
using UnityPatterns.Controllers;

/// <summary>
/// Unity audio manager controllers namespace
/// </summary>
namespace UnityAudioManager.Controllers
{
    /// <summary>
    /// A class that describes an audio clip player controller script
    /// </summary>
    public class AudioClipPlayerControllerScript : AControllerScript, IAudioClipPlayerController
    {
        /// <summary>
        /// Audio clip
        /// </summary>
        [SerializeField]
        private AudioClip audioClip;

        /// <summary>
        /// Audio clip
        /// </summary>
        public AudioClip AudioClip
        {
            get => audioClip;
            set => audioClip = value;
        }

        /// <summary>
        /// Plays sound effect
        /// </summary>
        public void PlaySoundEffect()
        {
            if (audioClip)
            {
                PlaySoundEffect(audioClip);
            }
        }

        /// <summary>
        /// Plays sound effect
        /// </summary>
        /// <param name="soundEffectAudioClip">Sound effect audio clip</param>
        /// <exception cref="ArgumentNullException">When "soundEffectAudioClip" is "null"</exception>
        public void PlaySoundEffect(AudioClip soundEffectAudioClip)
        {
            if (!soundEffectAudioClip)
            {
                throw new ArgumentNullException(nameof(soundEffectAudioClip));
            }
            AudioManager.PlaySoundEffect(soundEffectAudioClip);
        }

        /// <summary>
        /// Plays music
        /// </summary>
        public void PlayMusic()
        {
            if (audioClip)
            {
                PlayMusic(audioClip);
            }
        }

        /// <summary>
        /// Plays music
        /// </summary>
        /// <param name="musicAudioClip">Music audio clip</param>
        /// <exception cref="ArgumentNullException">When "musicAudioClip" is "null"</exception>
        public void PlayMusic(AudioClip musicAudioClip)
        {
            if (!musicAudioClip)
            {
                throw new ArgumentNullException(nameof(musicAudioClip));
            }
            AudioManager.PlayMusic(musicAudioClip);
        }

        /// <summary>
        /// Plays music delayed
        /// </summary>
        /// <param name="delayTime">Delay time</param>
        public void PlayMusicDelayed(float delayTime)
        {
            if (audioClip)
            {
                PlayMusicDelayed(audioClip, delayTime);
            }
        }

        /// <summary>
        /// Plays music delayed
        /// </summary>
        /// <param name="musicAudioClip">Music audio clip</param>
        /// <param name="delayTime">Delay time</param>
        /// <exception cref="ArgumentNullException">When "musicAudioClip" is "null"</exception>
        public void PlayMusicDelayed(AudioClip musicAudioClip, float delayTime)
        {
            if (!musicAudioClip)
            {
                throw new ArgumentNullException(nameof(musicAudioClip));
            }
            AudioManager.PlayMusicDelayed(musicAudioClip, delayTime);
        }
    }
}
