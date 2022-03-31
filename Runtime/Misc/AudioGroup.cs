using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity audio manager namespace
/// </summary>
namespace UnityAudioManager
{
    /// <summary>
    /// A class that describes an audio group
    /// </summary>
    internal class AudioGroup : IAudioGroup
    {
        /// <summary>
        /// Audio sources
        /// </summary>
        private AudioSource[] audioSources;

        /// <summary>
        /// Audio sources
        /// </summary>
        public IReadOnlyList<AudioSource> AudioSources => audioSources ?? Array.Empty<AudioSource>();

        /// <summary>
        /// Current sounds index
        /// </summary>
        public uint CurrentSoundsIndex { get; private set; }

        /// <summary>
        /// Is muted
        /// </summary>
        public bool IsMuted { get; set; }

        /// <summary>
        /// Volume
        /// </summary>
        public float Volume
        {
            get => (AudioSources.Count > 0) ? AudioSources[0].volume : 0.0f;
            set
            {
                foreach (AudioSource audio_source in AudioSources)
                {
                    if (audio_source != null)
                    {
                        audio_source.volume = Mathf.Clamp(value, 0.0f, 1.0f);
                    }
                }
            }
        }

        /// <summary>
        /// Spatialize
        /// </summary>
        public bool Spatialize
        {
            get => (AudioSources.Count > 0) ? AudioSources[0].spatialize : false;
            set
            {
                foreach (AudioSource audio_source in AudioSources)
                {
                    if (audio_source != null)
                    {
                        audio_source.spatialize = value;
                    }
                }
            }
        }

        /// <summary>
        /// Spatial blend
        /// </summary>
        public float SpatialBlend
        {
            get => (AudioSources.Count > 0) ? AudioSources[0].spatialBlend : 0.0f;
            set
            {
                foreach (AudioSource audio_source in AudioSources)
                {
                    if (audio_source != null)
                    {
                        audio_source.spatialBlend = Mathf.Clamp(value, 0.0f, 1.0f);
                    }
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="audioSources">Audio sources</param>
        private AudioGroup(AudioSource[] audioSources) => this.audioSources = audioSources;

        /// <summary>
        /// Apply settings
        /// </summary>
        /// <param name="audioSettings">Audio settings</param>
        public void ApplySettings(IAudioSettingsData audioSettings)
        {
            if (audioSettings == null)
            {
                throw new ArgumentNullException(nameof(audioSettings));
            }
            foreach (AudioSource audio_source in AudioSources)
            {
                audioSettings.ApplySettings(audio_source);
            }
        }

        /// <summary>
        /// Play
        /// </summary>
        /// <param name="clip"></param>
        public void Play(AudioClip clip)
        {
            if (AudioSources.Count > 0)
            {
                AudioSource audio_source = AudioSources[(int)CurrentSoundsIndex];
                if (audio_source != null)
                {
                    audio_source.clip = clip;
                    if (!IsMuted)
                    {
                        audio_source.Play();
                        ++CurrentSoundsIndex;
                    }
                    if (CurrentSoundsIndex >= AudioSources.Count)
                    {
                        CurrentSoundsIndex = 0U;
                    }
                }
            }
        }

        /// <summary>
        /// Create audio group
        /// </summary>
        /// <param name="gameObject">Game object</param>
        /// <param name="soundChannelCount">Sound channel count</param>
        /// <param name="audioSettings">Audio settings</param>
        /// <returns>Audio group if successful, otherwise "null"</returns>
        public static AudioGroup CreateAudioGroup(GameObject gameObject, uint soundChannelCount, IAudioSettingsData audioSettings)
        {
            if (!gameObject)
            {
                throw new ArgumentNullException(nameof(gameObject));
            }
            AudioGroup ret = null;
            if (soundChannelCount > 0U)
            {
                AudioSource[] audio_sources = new AudioSource[soundChannelCount];
                for (uint i = 0U; i != soundChannelCount; i++)
                {
                    AudioSource audio_source = gameObject.AddComponent<AudioSource>();
                    if (audioSettings != null)
                    {
                        audioSettings.ApplySettings(audio_source);
                    }
                    audio_sources[i] = audio_source;
                }
                ret = new AudioGroup(audio_sources);
            }
            return ret;
        }

        /// <summary>
        /// Create audio group
        /// </summary>
        /// <param name="gameObject">Game object</param>
        /// <param name="soundChannelCount">Sound channel count</param>
        /// <returns>Audio group if successful, otherwise "null"</returns>
        public static AudioGroup CreateAudioGroup(GameObject gameObject, uint soundChannelCount) => CreateAudioGroup(gameObject, soundChannelCount, null);
    }
}
