using UnityAudioManager.Data;
using UnityAudioManager.Objects;
using UnityEngine;
using UnityPatterns;

/// <summary>
/// Unity audio manager namespace
/// </summary>
namespace UnityAudioManager
{
    /// <summary>
    /// An interface that represents an audio manager
    /// </summary>
    public interface IAudioManager : IManager
    {
        /// <summary>
        /// Sound channel count
        /// </summary>
        uint SoundChannelCount { get; set; }

        /// <summary>
        /// Resources path
        /// </summary>
        string ResourcesPath { get; set; }

        /// <summary>
        /// Is muted
        /// </summary>
        bool IsMuted { get; set; }

        /// <summary>
        /// Is starting muted if game runs in mobile
        /// </summary>
        bool IsStartingMutedIfMobile { get; set; }

        /// <summary>
        /// Is loading playlist from resources
        /// </summary>
        bool IsLoadingPlaylistFromResources { get; set; }

        /// <summary>
        /// Is anlayzing music audio clip samples
        /// </summary>
        bool IsAnalyzingMusicAudioClipSamples { get; set; }

        /// <summary>
        /// Music audio settings
        /// </summary>
        IAudioSettingsData MusicAudioSettings { get; }

        /// <summary>
        /// Sound effects audio settings
        /// </summary>
        IAudioSettingsData SoundEffectsAudioSettings { get; }

        /// <summary>
        /// Playlist
        /// </summary>
        IMusicTitleData[] Playlist { get; set; }

        /// <summary>
        /// Music audio source
        /// </summary>
        AudioSource MusicAudioSource { get; }

        /// <summary>
        /// Sound effects
        /// </summary>
        IAudioGroup SoundEffectsAudioGroup { get; }

        /// <summary>
        /// Music volume
        /// </summary>
        float MusicVolume { get; set; }

        /// <summary>
        /// Sound effects volume
        /// </summary>
        float SoundEffectsVolume { get; set; }

        /// <summary>
        /// Is playing music
        /// </summary>
        bool IsPlayingMusic { get; }

        /// <summary>
        /// Music time
        /// </summary>
        /// <remarks>This property is inconsistent, if audio is compressed!</remarks>
        float MusicTime { get; set; }

        /// <summary>
        /// Music time in samples
        /// </summary>
        /// <remarks>This property is inconsistent, if audio is compressed!</remarks>
        int MusicTimeSamples { get; set; }

        /// <summary>
        /// Music frequency
        /// </summary>
        int MusicFrequency { get; }

        /// <summary>
        /// Music audio clip samples
        /// </summary>
        int MusicAudioClipSamples { get; }

        /// <summary>
        /// Music audio clip
        /// </summary>
        AudioClip MusicAudioClip { get; }

        /// <summary>
        /// Plays next music
        /// </summary>
        void PlayNextMusic();

        /// <summary>
        /// Plays sound effect
        /// </summary>
        /// <param name="soundEffectAudioClip">Sound effect audio clip</param>
        void PlaySoundEffect(AudioClip soundEffectAudioClip);

        /// <summary>
        /// Plays music
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        void PlayMusic(IMusicTitleData musicTitle);

        /// <summary>
        /// Plays music
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        void PlayMusic(MusicTitleObjectScript musicTitle);

        /// <summary>
        /// Plays music
        /// </summary>
        /// <param name="musicAudioClip">Music audio clip</param>
        void PlayMusic(AudioClip musicAudioClip);

        /// <summary>
        /// Plays music delayed
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="delayTime">Delay time</param>
        void PlayMusicDelayed(IMusicTitleData musicTitle, float delayTime);

        /// <summary>
        /// Plays music delayed
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="delayTime">Delay time</param>
        void PlayMusicDelayed(MusicTitleObjectScript musicTitle, float delayTime);

        /// <summary>
        /// Plays music
        /// </summary>
        /// <param name="musicAudioClip">Music audio clip</param>
        /// <param name="delayTime">Delay time</param>
        void PlayMusicDelayed(AudioClip musicAudioClip, float delayTime);

        /// <summary>
        /// Replays music
        /// </summary>
        void ReplayMusic();

        /// <summary>
        /// Stops music
        /// </summary>
        void StopMusic();

        /// <summary>
        /// Shuffles playlist
        /// </summary>
        void ShufflePlaylist();

        /// <summary>
        /// Loads playlist from resources
        /// </summary>
        /// <param name="path">Path</param>
        void LoadPlaylistFromResources(string path);

        /// <summary>
        /// Load playlist from resources
        /// </summary>
        void LoadPlaylistFromResources();
    }
}
