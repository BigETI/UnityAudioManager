using System;
using UnityAudioManager.Data;
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
        public static MusicTitleData[] Playlist
        {
            get => ((AudioManagerScript.Instance == null) ? Array.Empty<MusicTitleData>() : AudioManagerScript.Instance.Playlist);
            set
            {
                if (AudioManagerScript.Instance != null)
                {
                    AudioManagerScript.Instance.Playlist = value;
                }
            }
        }

        /// <summary>
        /// Music audio source
        /// </summary>
        public static AudioSource MusicAudioSource => ((AudioManagerScript.Instance == null) ? null : AudioManagerScript.Instance.MusicAudioSource);

        /// <summary>
        /// Sound effects
        /// </summary>
        public static AudioGroup SoundEffectsAudioGroup => ((AudioManagerScript.Instance == null) ? null : AudioManagerScript.Instance.SoundEffectsAudioGroup);

        /// <summary>
        /// Is muted
        /// </summary>
        public static bool IsMuted
        {
            get => ((AudioManagerScript.Instance == null) ? true : AudioManagerScript.Instance.IsMuted);
            set
            {
                if (AudioManagerScript.Instance != null)
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
            get => ((AudioManagerScript.Instance == null) ? 0.0f : AudioManagerScript.Instance.MusicVolume);
            set
            {
                if (AudioManagerScript.Instance != null)
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
            get => ((AudioManagerScript.Instance == null) ? 0.0f : AudioManagerScript.Instance.SoundEffectsVolume);
            set
            {
                if (AudioManagerScript.Instance != null)
                {
                    AudioManagerScript.Instance.SoundEffectsVolume = value;
                }
            }
        }

        /// <summary>
        /// Resources path
        /// </summary>
        public static string ResourcesPath => ((AudioManagerScript.Instance == null) ? "MusicTitles" : AudioManagerScript.Instance.ResourcesPath);

        /// <summary>
        /// Music time
        /// </summary>
        /// <remarks>This property is inconsistent, if audio is compressed!</remarks>
        public static float MusicTime
        {
            get => ((AudioManagerScript.Instance == null) ? 0.0f : AudioManagerScript.Instance.MusicTime);
            set
            {
                if (AudioManagerScript.Instance != null)
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
            get => ((AudioManagerScript.Instance == null) ? 0 : AudioManagerScript.Instance.MusicTimeSamples);
            set
            {
                if (AudioManagerScript.Instance != null)
                {
                    AudioManagerScript.Instance.MusicTimeSamples = value;
                }
            }
        }

        /// <summary>
        /// Music frequency
        /// </summary>
        public static int MusicFrequency => ((AudioManagerScript.Instance == null) ? 0 : AudioManagerScript.Instance.MusicFrequency);

        /// <summary>
        /// Music audio clip samples
        /// </summary>
        public static int MusicAudioClipSamples => ((AudioManagerScript.Instance == null) ? 0 : AudioManagerScript.Instance.MusicAudioClipSamples);

        /// <summary>
        /// Music audio clip
        /// </summary>
        public static AudioClip MusicAudioClip => ((AudioManagerScript.Instance == null) ? null : AudioManagerScript.Instance.MusicAudioClip);

        /// <summary>
        /// Is playing music
        /// </summary>
        public static bool IsPlayingMusic => ((AudioManagerScript.Instance == null) ? false : AudioManagerScript.Instance.IsPlayingMusic);

        /// <summary>
        /// Play next music
        /// </summary>
        public static void PlayNextMusic()
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayNextMusic();
            }
        }

        /// <summary>
        /// Play sound effect
        /// </summary>
        /// <param name="clip"></param>
        public static void PlaySoundEffect(AudioClip clip)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlaySoundEffect(clip);
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public static void PlayMusic(MusicTitleData musicTitle)
        {
            if (AudioManagerScript.Instance != null)
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
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayMusic(musicTitle);
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="audioClip">Audio clip</param>
        public static void PlayMusic(AudioClip audioClip)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayMusic(audioClip);
            }
        }

        /// <summary>
        /// Play music delayed
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="delay">Delay</param>
        public static void PlayMusicDelayed(MusicTitleData musicTitle, float delay)
        {
            if (AudioManagerScript.Instance != null)
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
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayMusicDelayed(musicTitle, delay);
            }
        }

        /// <summary>
        /// Play music delayed
        /// </summary>
        /// <param name="audioClip">Audio clip</param>
        /// <param name="delay">Delay</param>
        public static void PlayMusicDelayed(AudioClip audioClip, float delay)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayMusicDelayed(audioClip, delay);
            }
        }

        /// <summary>
        /// Replay music
        /// </summary>
        public static void ReplayMusic()
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.ReplayMusic();
            }
        }

        /// <summary>
        /// Stop music
        /// </summary>
        public static void StopMusic()
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.StopMusic();
            }
        }

        /// <summary>
        /// Shuffle playlist
        /// </summary>
        public static void ShufflePlaylist()
        {
            if (AudioManagerScript.Instance != null)
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
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.LoadPlaylistFromResources(path);
            }
        }
    }
}
