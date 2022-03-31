using System;
using System.Collections.Generic;
using UnityAudioManager.Data;
using UnityAudioManager.Objects;
using UnityEngine;
using UnityEngine.Serialization;
using UnityPatterns.Managers;
#if UNITY_ANALYTICS
using UnityEngine.Analytics;
#endif

/// <summary>
/// Unity audio manager managers namespace
/// </summary>
namespace UnityAudioManager.Managers
{
    /// <summary>
    /// Audio manager script class
    /// </summary>
    public class AudioManagerScript : AManagerScript<AudioManagerScript>, IAudioManager
    {
        /// <summary>
        /// Default resources path
        /// </summary>
        private static readonly string defaultResourcesPath = "MusicTitles";

        /// <summary>
        /// Sound channel count
        /// </summary>
        [SerializeField]
        [Min(1)]
        private uint soundChannelCount = 8;

        /// <summary>
        /// Resources path
        /// </summary>
        [SerializeField]
        private string resourcesPath = defaultResourcesPath;

        /// <summary>
        /// Is muted
        /// </summary>
        [SerializeField]
        private bool isMuted = default;

        /// <summary>
        /// Is starting muted if game runs in mobile
        /// </summary>
        [SerializeField]
        [FormerlySerializedAs("startMutedIfMobile")]
        private bool isStartingMutedIfMobile = default;

        /// <summary>
        /// Is loading playlist from resources
        /// </summary>
        [SerializeField]
        [FormerlySerializedAs("loadPlaylistFromResources")]
        private bool isLoadingPlaylistFromResources = true;

        /// <summary>
        /// Is anlayzing music audio clip samples
        /// </summary>
        [SerializeField]
        [FormerlySerializedAs("analyzeMusicAudioClipSamples")]
        private bool isAnalyzingMusicAudioClipSamples = default;

        /// <summary>
        /// Music audio settings
        /// </summary>
        [SerializeField]
        private AudioSettingsData musicAudioSettings = default;

        /// <summary>
        /// Sound effects audio settings
        /// </summary>
        [SerializeField]
        private AudioSettingsData soundEffectsAudioSettings = default;

        /// <summary>
        /// Current playlist index
        /// </summary>
        private uint currentPlaylistIndex;

        /// <summary>
        /// Is game paused
        /// </summary>
        private bool isGamePaused;

        /// <summary>
        /// Playlist
        /// </summary>
        private IMusicTitleData[] playlist;

        /// <summary>
        /// Analyze music audio source
        /// </summary>
        private AudioSource analyzeMusicAudioSource;

        /// <summary>
        /// Music audio clip samples
        /// </summary>
        private int musicAudioClipSamples;

        /// <summary>
        /// Analyzed samples
        /// </summary>
        private int analyzedSamples = 0;

        /// <summary>
        /// Analyze music numerator
        /// </summary>
        private long analyzeMusicNumerator;

        /// <summary>
        /// Analyze music denominator
        /// </summary>
        private long analyzeMusicDenominator;

        /// <summary>
        /// Sound channel count
        /// </summary>
        public uint SoundChannelCount
        {
            get => soundChannelCount;
            set => soundChannelCount = (uint)Mathf.Max((int)value, 1);
        }

        /// <summary>
        /// Resources path
        /// </summary>
        public string ResourcesPath
        {
            get => string.IsNullOrWhiteSpace(resourcesPath) ? defaultResourcesPath : resourcesPath;
            set => resourcesPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Is muted
        /// </summary>
        public bool IsMuted
        {
            get => isMuted;
            set
            {
                if (isMuted != value)
                {
                    isMuted = value;
                    if (isMuted)
                    {
                        if (MusicAudioSource)
                        {
                            MusicAudioSource.Stop();
                        }
                        if (MusicUIManagerScript.Instance)
                        {
                            MusicUIManagerScript.Instance.HidePlay();
                        }
                    }
                    else
                    {
                        if (Playlist.Length > 0)
                        {
                            PlayCurrentMusic();
                        }
                    }
                    if (SoundEffectsAudioGroup != null)
                    {
                        SoundEffectsAudioGroup.IsMuted = isMuted;
                    }
#if UNITY_ANALYTICS
                    Analytics.CustomEvent(isMuted ? "muteAudio" : "unmuteAudio");
#endif
                }
            }
        }

        /// <summary>
        /// Is starting muted if game runs in mobile
        /// </summary>
        public bool IsStartingMutedIfMobile
        {
            get => isStartingMutedIfMobile;
            set => isStartingMutedIfMobile = value;
        }

        /// <summary>
        /// Is loading playlist from resources
        /// </summary>
        public bool IsLoadingPlaylistFromResources
        {
            get => isLoadingPlaylistFromResources;
            set => isLoadingPlaylistFromResources = value;
        }

        /// <summary>
        /// Is anlayzing music audio clip samples
        /// </summary>
        public bool IsAnalyzingMusicAudioClipSamples
        {
            get => isAnalyzingMusicAudioClipSamples;
            set => isAnalyzingMusicAudioClipSamples = value;
        }

        /// <summary>
        /// Music audio settings
        /// </summary>
        public IAudioSettingsData MusicAudioSettings => musicAudioSettings ??= new AudioSettingsData();

        /// <summary>
        /// Sound effects audio settings
        /// </summary>
        public IAudioSettingsData SoundEffectsAudioSettings => soundEffectsAudioSettings ??= new AudioSettingsData();

        /// <summary>
        /// Playlist
        /// </summary>
        public IMusicTitleData[] Playlist
        {
            get => playlist ?? Array.Empty<IMusicTitleData>();
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                bool is_playing_music = IsPlayingMusic;
                List<MusicTitleData> list = new List<MusicTitleData>();
                foreach (MusicTitleData music_title in value)
                {
                    if (music_title != null)
                    {
                        list.Add(new MusicTitleData(music_title));
                    }
                }
                if (is_playing_music)
                {
                    IsMuted = true;
                }
                playlist = list.ToArray();
                list.Clear();
                if (is_playing_music)
                {
                    IsMuted = false;
                }
                currentPlaylistIndex = 0U;
            }
        }

        /// <summary>
        /// Music audio source
        /// </summary>
        public AudioSource MusicAudioSource { get; private set; }

        /// <summary>
        /// Sound effects
        /// </summary>
        public IAudioGroup SoundEffectsAudioGroup { get; private set; }

        /// <summary>
        /// Music volume
        /// </summary>
        public float MusicVolume
        {
            get => (MusicAudioSource == null) ? 0.0f : MusicAudioSource.volume;
            set
            {
                if (MusicAudioSource != null)
                {
                    MusicAudioSource.volume = Mathf.Clamp(value, 0.0f, 1.0f);
                }
            }
        }

        /// <summary>
        /// Sound effects volume
        /// </summary>
        public float SoundEffectsVolume
        {
            get => (SoundEffectsAudioGroup == null) ? 0.0f : SoundEffectsAudioGroup.Volume;
            set
            {
                if (SoundEffectsAudioGroup != null)
                {
                    SoundEffectsAudioGroup.Volume = value;
                }
            }
        }

        /// <summary>
        /// Is playing music
        /// </summary>
        public bool IsPlayingMusic => MusicAudioSource && MusicAudioSource.isPlaying;

        /// <summary>
        /// Music time
        /// </summary>
        /// <remarks>This property is inconsistent, if audio is compressed!</remarks>
        public float MusicTime
        {
            get => (MusicAudioSource && MusicAudioSource.clip) ? MusicAudioSource.time : 0.0f;
            set
            {
                if (MusicAudioSource)
                {
                    MusicAudioSource.time = Mathf.Clamp(value, 0.0f, MusicAudioClip ? Mathf.Max(0.0f, MusicAudioClip.length - 0.01f) : 0.0f);
                }
            }
        }

        /// <summary>
        /// Music time in samples
        /// </summary>
        /// <remarks>This property is inconsistent, if audio is compressed!</remarks>
        public int MusicTimeSamples
        {
            get => (MusicAudioSource && MusicAudioSource.clip) ? MusicAudioSource.timeSamples : 0;
            set
            {
                if (MusicAudioSource)
                {
                    MusicAudioSource.timeSamples = MusicAudioClip ? Mathf.Max(0, value - 1) : 0;
                }
            }
        }

        /// <summary>
        /// Music frequency
        /// </summary>
        public int MusicFrequency => (MusicAudioSource && MusicAudioSource.clip) ? MusicAudioSource.clip.frequency : 1;

        /// <summary>
        /// Music audio clip samples
        /// </summary>
        public int MusicAudioClipSamples => isAnalyzingMusicAudioClipSamples ? musicAudioClipSamples : (MusicAudioClip ? MusicAudioClip.samples : 0);

        /// <summary>
        /// Music audio clip
        /// </summary>
        public AudioClip MusicAudioClip
        {
            get => MusicAudioSource ? MusicAudioSource.clip : null;
            private set
            {
                if (MusicAudioSource != null)
                {
                    MusicAudioSource.clip = value;
                    if (analyzeMusicAudioSource != null)
                    {
                        analyzeMusicAudioSource.clip = value;
                        analyzeMusicNumerator = 1L;
                        analyzeMusicDenominator = 1L;
                        analyzedSamples = Mathf.Max(0, value.samples - 1);
                        musicAudioClipSamples = value.samples;
                        analyzeMusicAudioSource.timeSamples = analyzedSamples;
                        analyzeMusicAudioSource.Play();
                    }
                }
            }
        }

        /// <summary>
        /// Shuffles collection
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">Collection</param>
        /// <returns>Shuffled array</returns>
        private static T[] Shuffle<T>(IEnumerable<T> collection)
        {
            List<T> list = new List<T>(collection);
            int n = list.Count;
            while (n > 1)
            {
                int k = UnityEngine.Random.Range(0, n--);
                T temp = list[n];
                list[n] = list[k];
                list[k] = temp;
            }
            T[] ret = list.ToArray();
            list.Clear();
            return ret;
        }

        /// <summary>
        /// Plays current music
        /// </summary>
        private void PlayCurrentMusic()
        {
            if ((Playlist.Length > 0) && MusicAudioSource)
            {
                IMusicTitleData music_title = Playlist[currentPlaylistIndex];
                MusicAudioClip = music_title.AudioClip;
                if (!isMuted)
                {
                    MusicAudioSource.timeSamples = 0;
                    MusicAudioSource.Play();
                    if (MusicUIManagerScript.Instance != null)
                    {
                        MusicUIManagerScript.Instance.ShowPlay(music_title);
                    }
                }
            }
        }

        /// <summary>
        /// Plays next music
        /// </summary>
        public void PlayNextMusic()
        {
            if (Playlist.Length > 0)
            {
                ++currentPlaylistIndex;
                if (currentPlaylistIndex >= Playlist.Length)
                {
                    currentPlaylistIndex = 0U;
                }
                PlayCurrentMusic();
            }
        }

        /// <summary>
        /// Plays sound effect
        /// </summary>
        /// <param name="soundEffectAudioClip">Sound effect audio clip</param>
        public void PlaySoundEffect(AudioClip soundEffectAudioClip) => SoundEffectsAudioGroup?.Play(soundEffectAudioClip);

        /// <summary>
        /// Plays music
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public void PlayMusic(IMusicTitleData musicTitle)
        {
            if (musicTitle == null)
            {
                throw new ArgumentNullException(nameof(musicTitle));
            }
            if (MusicAudioSource)
            {
                MusicAudioClip = musicTitle.AudioClip;
                if (!isMuted)
                {
                    MusicAudioSource.timeSamples = 0;
                    MusicAudioSource.Play();
                    if (MusicUIManagerScript.Instance != null)
                    {
                        MusicUIManagerScript.Instance.ShowPlay(musicTitle);
                    }
                }
            }
        }

        /// <summary>
        /// Plays music
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public void PlayMusic(MusicTitleObjectScript musicTitle)
        {
            if (!musicTitle)
            {
                throw new ArgumentNullException(nameof(musicTitle));
            }
            PlayMusic(new MusicTitleData(musicTitle, ResourcesPath));
        }

        /// <summary>
        /// Plays music
        /// </summary>
        /// <param name="musicAudioClip">Music audio clip</param>
        public void PlayMusic(AudioClip musicAudioClip)
        {
            if (!musicAudioClip)
            {
                throw new ArgumentNullException(nameof(musicAudioClip));
            }
            if (MusicAudioSource)
            {
                MusicAudioClip = musicAudioClip;
                if (!isMuted)
                {
                    MusicAudioSource.timeSamples = 0;
                    MusicAudioSource.Play();
                }
            }
        }

        /// <summary>
        /// Plays music delayed
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="delayTime">Delay time</param>
        public void PlayMusicDelayed(IMusicTitleData musicTitle, float delayTime)
        {
            if (musicTitle == null)
            {
                throw new ArgumentNullException(nameof(musicTitle));
            }
            float d = Mathf.Max(delayTime, 0.0f);
            if (MusicAudioSource)
            {
                MusicAudioClip = musicTitle.AudioClip;
                if (!isMuted)
                {
                    MusicAudioSource.PlayDelayed(d);
                    if (MusicUIManagerScript.Instance != null)
                    {
                        MusicUIManagerScript.Instance.ShowPlay(musicTitle);
                    }
                }
            }
        }

        /// <summary>
        /// Plays music delayed
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="delayTime">Delay time</param>
        public void PlayMusicDelayed(MusicTitleObjectScript musicTitle, float delayTime)
        {
            if (!musicTitle)
            {
                throw new ArgumentNullException(nameof(musicTitle));
            }
            if (musicTitle != null)
            {
                PlayMusicDelayed(new MusicTitleData(musicTitle, ResourcesPath), delayTime);
            }
        }

        /// <summary>
        /// Plays music
        /// </summary>
        /// <param name="musicAudioClip">Music audio clip</param>
        /// <param name="delayTime">Delay time</param>
        public void PlayMusicDelayed(AudioClip musicAudioClip, float delayTime)
        {
            if (!musicAudioClip)
            {
                throw new ArgumentNullException(nameof(musicAudioClip));
            }
            float d = Mathf.Max(0.0f, delayTime);
            if (MusicAudioSource)
            {
                MusicAudioClip = musicAudioClip;
                if (!isMuted)
                {
                    MusicAudioSource.timeSamples = 0;
                    MusicAudioSource.PlayDelayed(d);
                }
            }
        }

        /// <summary>
        /// Replays music
        /// </summary>
        public void ReplayMusic()
        {
            if (MusicAudioSource)
            {
                MusicAudioSource.Stop();
                MusicAudioSource.Play();
            }
        }

        /// <summary>
        /// Stops music
        /// </summary>
        public void StopMusic()
        {
            if (MusicAudioSource)
            {
                MusicAudioSource.Stop();
            }
        }

        /// <summary>
        /// Shuffles playlist
        /// </summary>
        public void ShufflePlaylist() => Playlist = Shuffle(Playlist);

        /// <summary>
        /// Loads playlist from resources
        /// </summary>
        /// <param name="path">Path</param>
        public void LoadPlaylistFromResources(string path)
        {
            MusicTitleObjectScript[] playlist_objects = Resources.LoadAll<MusicTitleObjectScript>(path);
            if (playlist_objects != null)
            {
                IMusicTitleData[] playlist = new IMusicTitleData[playlist_objects.Length];
                for (int i = 0; i < playlist.Length; i++)
                {
                    playlist[i] = new MusicTitleData(playlist_objects[i], path);
                }
                Playlist = playlist;
            }
            else
            {
                Playlist = Array.Empty<IMusicTitleData>();
            }
        }

        /// <summary>
        /// Load playlist from resources
        /// </summary>
        public void LoadPlaylistFromResources() => LoadPlaylistFromResources(ResourcesPath);

        /// <summary>
        /// Gets invoked when script has been initialized
        /// </summary>
        protected virtual void Awake()
        {
            if (isStartingMutedIfMobile)
            {
                isMuted = SystemInfo.deviceType == DeviceType.Handheld;
            }
        }

        /// <summary>
        /// Gets invoked when script has been started
        /// </summary>
        protected virtual void Start()
        {
            if (isLoadingPlaylistFromResources)
            {
                LoadPlaylistFromResources();
            }
            MusicAudioSource = gameObject.AddComponent<AudioSource>();
            MusicAudioSettings.ApplySettings(MusicAudioSource);
            if (isAnalyzingMusicAudioClipSamples)
            {
                analyzeMusicAudioSource = gameObject.AddComponent<AudioSource>();
                MusicAudioSettings.ApplySettings(analyzeMusicAudioSource);
                if (analyzeMusicAudioSource != null)
                {
                    analyzeMusicAudioSource.volume = 0.0f;
                }
            }
            SoundEffectsAudioGroup = AudioGroup.CreateAudioGroup(gameObject, soundChannelCount, SoundEffectsAudioSettings);
            ShufflePlaylist();
            PlayCurrentMusic();
        }

        /// <summary>
        /// Gets invoked when script performs a frame update
        /// </summary>
        protected virtual void Update()
        {
            if (!isMuted)
            {
                if (!isGamePaused && !IsPlayingMusic)
                {
                    PlayNextMusic();
                }
            }
            if (analyzeMusicAudioSource != null)
            {
                AudioClip clip = analyzeMusicAudioSource.clip;
                if (clip != null)
                {
                    if (analyzeMusicAudioSource.isPlaying)
                    {
                        if (analyzedSamples == analyzeMusicAudioSource.timeSamples)
                        {
                            musicAudioClipSamples = analyzedSamples + 1;
                        }
                        else
                        {
                            long old_analyze_music_numerator = analyzeMusicNumerator;
                            long old_analyze_music_denominator = analyzeMusicDenominator;
                            analyzeMusicNumerator *= 2L;
                            analyzeMusicDenominator *= 2L;
                            if (analyzedSamples < analyzeMusicAudioSource.timeSamples)
                            {
                                ++analyzeMusicNumerator;
                            }
                            else if (analyzedSamples > analyzeMusicAudioSource.timeSamples)
                            {
                                --analyzeMusicNumerator;
                            }
                            long max_samples = Mathf.Max(0, clip.samples - 1);
                            musicAudioClipSamples = analyzedSamples + 1;
                            analyzedSamples = (int)((max_samples * analyzeMusicNumerator) / analyzeMusicDenominator);
                            analyzeMusicAudioSource.timeSamples = analyzedSamples;
                            if (musicAudioClipSamples == (analyzedSamples + 1))
                            {
                                analyzeMusicNumerator = old_analyze_music_numerator;
                                analyzeMusicDenominator = old_analyze_music_denominator;
                            }
                        }
                    }
                    else
                    {
                        musicAudioClipSamples = analyzeMusicAudioSource.timeSamples + 1;
                    }
                }
            }
        }

        /// <summary>
        /// Gets invoked when application changes pause state
        /// </summary>
        /// <param name="pause">Pause</param>
        protected virtual void OnApplicationPause(bool pause) => isGamePaused = pause;
    }
}
