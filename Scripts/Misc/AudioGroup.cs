using System;
using UnityAudioManager.Data;
using UnityEngine;

/// <summary>
/// Unity audio manager namespace
/// </summary>
namespace UnityAudioManager
{
    /// <summary>
    /// Audio group data class
    /// </summary>
    public class AudioGroup
    {
        /// <summary>
        /// Audio sources
        /// </summary>
        private AudioSource[] audioSources;

        /// <summary>
        /// Current sounds index
        /// </summary>
        private uint currentSoundsIndex;

        /// <summary>
        /// Is muted
        /// </summary>
        public bool IsMuted { get; set; }

        /// <summary>
        /// Audio sources
        /// </summary>
        private AudioSource[] AudioSources
        {
            get
            {
                if (audioSources == null)
                {
                    audioSources = Array.Empty<AudioSource>();
                }
                return audioSources;
            }
        }

        /// <summary>
        /// Volume
        /// </summary>
        public float Volume
        {
            get
            {
                return ((AudioSources.Length > 0) ? AudioSources[0].volume : 0.0f);
            }
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
            get
            {
                return ((AudioSources.Length > 0) ? AudioSources[0].spatialize : false);
            }
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
            get
            {
                return ((AudioSources.Length > 0) ? AudioSources[0].spatialBlend : 0.0f);
            }
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
        /// Apply settings
        /// </summary>
        /// <param name="audioSettings">Audio settings</param>
        public void ApplySettings(AudioSettingsData audioSettings)
        {
            if (audioSettings != null)
            {
                foreach (AudioSource audio_source in AudioSources)
                {
                    audioSettings.ApplySettings(audio_source);
                }
            }
        }

        /// <summary>
        /// Play
        /// </summary>
        /// <param name="clip"></param>
        public void Play(AudioClip clip)
        {
            if (AudioSources.Length > 0)
            {
                AudioSource audio_source = AudioSources[currentSoundsIndex];
                if (audio_source != null)
                {
                    audio_source.clip = clip;
                    if (!IsMuted)
                    {
                        audio_source.Play();
                        ++currentSoundsIndex;
                    }
                    if (currentSoundsIndex >= AudioSources.Length)
                    {
                        currentSoundsIndex = 0U;
                    }
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="audioSources">Audio sources</param>
        private AudioGroup(AudioSource[] audioSources)
        {
            this.audioSources = audioSources;
        }

        /// <summary>
        /// Create audio group
        /// </summary>
        /// <param name="gameObject">Game object</param>
        /// <param name="soundChannelCount">Sound channel count</param>
        /// <param name="audioSettings">Audio settings</param>
        /// <returns>Audio group if successful, otherwise "null"</returns>
        public static AudioGroup CreateAudioGroup(GameObject gameObject, uint soundChannelCount, AudioSettingsData audioSettings)
        {
            AudioGroup ret = null;
            if ((gameObject != null) && (soundChannelCount > 0U))
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
        public static AudioGroup CreateAudioGroup(GameObject gameObject, uint soundChannelCount)
        {
            return CreateAudioGroup(gameObject, soundChannelCount, null);
        }
    }
}
