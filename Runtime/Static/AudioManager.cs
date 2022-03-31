using System;
using UnityAudioManager.Managers;
using UnityAudioManager.Objects;
using UnityEngine;

/// <summary>
/// Unity audio manager namespace
/// </summary>
namespace UnityAudioManager
{
    /// <summary>
    /// Audio manager class
    /// </summary>
    public static class AudioManager
    {
        /// <summary>
        /// Playlist
        /// </summary>
        public static IMusicTitleData[] Playlist
        {
            get => AudioManagerScript.Instance ? AudioManagerScript.Instance.Playlist : Array.Empty<IMusicTitleData>();
            set
            {
                if (AudioManagerScript.Instance)
                {
                    AudioManagerScript.Instance.Playlist = value;
                }
            }
        }

        /// <summary>
        /// Music audio source
        /// </summary>
        public static AudioSource MusicAudioSource => AudioManagerScript.Instance ? AudioManagerScript.Instance.MusicAudioSource : null;

        /// <summary>
        /// Sound effects
        /// </summary>
        public static IAudioGroup SoundEffectsAudioGroup => AudioManagerScript.Instance ? AudioManagerScript.Instance.SoundEffectsAudioGroup : null;

        /// <summary>
        /// Is muted
        /// </summary>
        public static bool IsMuted
        {
            get => !AudioManagerScript.Instance || AudioManagerScript.Instance.IsMuted;
            set
            {
                if (AudioManagerScript.Instance)
                {
                    AudioManagerScript.Instance.IsMuted = value;
                }
            }
        }

        /// <summary>
        /// Music volume
        /// </summary>
        public static float MusicVolume
        {
            get => AudioManagerScript.Instance ? AudioManagerScript.Instance.MusicVolume : 0.0f;
            set
            {
                if (AudioManagerScript.Instance)
                {
                    AudioManagerScript.Instance.MusicVolume = value;
                }
            }
        }

        /// <summary>
        /// Sound effects volume
        /// </summary>
        public static float SoundEffectsVolume
        {
            get => AudioManagerScript.Instance ? AudioManagerScript.Instance.SoundEffectsVolume : 0.0f;
            set
            {
                if (AudioManagerScript.Instance)
                {
                    AudioManagerScript.Instance.SoundEffectsVolume = value;
                }
            }
        }

        /// <summary>
        /// Resources path
        /// </summary>
        public static string ResourcesPath => AudioManagerScript.Instance ? AudioManagerScript.Instance.ResourcesPath : "MusicTitles";

        /// <summary>
        /// Music time
        /// </summary>
        /// <remarks>This property is inconsistent, if audio is compressed!</remarks>
        public static float MusicTime
        {
            get => AudioManagerScript.Instance ? AudioManagerScript.Instance.MusicTime : 0.0f;
            set
            {
                if (AudioManagerScript.Instance)
                {
                    AudioManagerScript.Instance.MusicTime = value;
                }
            }
        }

        /// <summary>
        /// Music time in samples
        /// </summary>
        /// <remarks>This property is inconsistent, if audio is compressed!</remarks>
        public static int MusicTimeSamples
        {
            get => AudioManagerScript.Instance ? AudioManagerScript.Instance.MusicTimeSamples : 0;
            set
            {
                if (AudioManagerScript.Instance)
                {
                    AudioManagerScript.Instance.MusicTimeSamples = value;
                }
            }
        }

        /// <summary>
        /// Music frequency
        /// </summary>
        public static int MusicFrequency => AudioManagerScript.Instance ? AudioManagerScript.Instance.MusicFrequency : 0;

        /// <summary>
        /// Music audio clip samples
        /// </summary>
        public static int MusicAudioClipSamples => (AudioManagerScript.Instance) ? AudioManagerScript.Instance.MusicAudioClipSamples : 0;

        /// <summary>
        /// Music audio clip
        /// </summary>
        public static AudioClip MusicAudioClip => AudioManagerScript.Instance ? AudioManagerScript.Instance.MusicAudioClip : null;

        /// <summary>
        /// Is playing music
        /// </summary>
        public static bool IsPlayingMusic => AudioManagerScript.Instance && AudioManagerScript.Instance.IsPlayingMusic;

        /// <summary>
        /// Play next music
        /// </summary>
        public static void PlayNextMusic()
        {
            if (AudioManagerScript.Instance)
            {
                AudioManagerScript.Instance.PlayNextMusic();
            }
        }

        /// <summary>
        /// Play sound effect
        /// </summary>
        /// <param name="soundEffectAudioClip">Sound effect audio clip</param>
        public static void PlaySoundEffect(AudioClip soundEffectAudioClip)
        {
            if (!soundEffectAudioClip)
            {
                throw new ArgumentNullException(nameof(soundEffectAudioClip));
            }
            if (AudioManagerScript.Instance)
            {
                AudioManagerScript.Instance.PlaySoundEffect(soundEffectAudioClip);
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public static void PlayMusic(IMusicTitleData musicTitle)
        {
            if (musicTitle == null)
            {
                throw new ArgumentNullException(nameof(musicTitle));
            }
            if (AudioManagerScript.Instance)
            {
                AudioManagerScript.Instance.PlayMusic(musicTitle);
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public static void PlayMusic(MusicTitleObjectScript musicTitle)
        {
            if (!musicTitle)
            {
                throw new ArgumentNullException(nameof(musicTitle));
            }
            if (AudioManagerScript.Instance)
            {
                AudioManagerScript.Instance.PlayMusic(musicTitle);
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="musicAudioClip">Music audio clip</param>
        public static void PlayMusic(AudioClip musicAudioClip)
        {
            if (!musicAudioClip)
            {
                throw new ArgumentNullException(nameof(musicAudioClip));
            }
            if (AudioManagerScript.Instance)
            {
                AudioManagerScript.Instance.PlayMusic(musicAudioClip);
            }
        }

        /// <summary>
        /// Play music delayed
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="delay">Delay</param>
        public static void PlayMusicDelayed(IMusicTitleData musicTitle, float delay)
        {
            if (musicTitle == null)
            {
                throw new ArgumentNullException(nameof(musicTitle));
            }
            if (AudioManagerScript.Instance)
            {
                AudioManagerScript.Instance.PlayMusicDelayed(musicTitle, delay);
            }
        }

        /// <summary>
        /// Play music delayed
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="delay">Delay</param>
        public static void PlayMusicDelayed(MusicTitleObjectScript musicTitle, float delay)
        {
            if (!musicTitle)
            {
                throw new ArgumentNullException(nameof(musicTitle));
            }
            if (AudioManagerScript.Instance)
            {
                AudioManagerScript.Instance.PlayMusicDelayed(musicTitle, delay);
            }
        }

        /// <summary>
        /// Play music delayed
        /// </summary>
        /// <param name="musicAudioClip">Music audio clip</param>
        /// <param name="delay">Delay</param>
        public static void PlayMusicDelayed(AudioClip musicAudioClip, float delay)
        {
            if (!musicAudioClip)
            {
                throw new ArgumentNullException(nameof(musicAudioClip));
            }
            if (AudioManagerScript.Instance)
            {
                AudioManagerScript.Instance.PlayMusicDelayed(musicAudioClip, delay);
            }
        }

        /// <summary>
        /// Replay music
        /// </summary>
        public static void ReplayMusic()
        {
            if (AudioManagerScript.Instance)
            {
                AudioManagerScript.Instance.ReplayMusic();
            }
        }

        /// <summary>
        /// Stop music
        /// </summary>
        public static void StopMusic()
        {
            if (AudioManagerScript.Instance)
            {
                AudioManagerScript.Instance.StopMusic();
            }
        }

        /// <summary>
        /// Shuffle playlist
        /// </summary>
        public static void ShufflePlaylist()
        {
            if (AudioManagerScript.Instance)
            {
                AudioManagerScript.Instance.ShufflePlaylist();
            }
        }

        /// <summary>
        /// Load playlist from resources
        /// </summary>
        /// <param name="path">Path</param>
        public static void LoadPlaylistFromResources(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }
            if (AudioManagerScript.Instance)
            {
                AudioManagerScript.Instance.LoadPlaylistFromResources(path);
            }
        }
    }
}
