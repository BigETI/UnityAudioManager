using System;
using UnityAudioManager.Data;
using UnityEngine;
using UnityEngine.Serialization;
using UnityPatterns.Triggers;

/// <summary>
/// Unity audio manager triggers namespace
/// </summary>
namespace UnityAudioManager.Triggers
{
    /// <summary>
    /// A class that describes a load playlist trigger script
    /// </summary>
    public class LoadPlaylistTriggerScript : ATriggerScript, ILoadPlaylistTrigger
    {
        /// <summary>
        /// Default resources path
        /// </summary>
        private static readonly string defaultResourcesPath = "MusicTitles";

        /// <summary>
        /// Is loading from resources
        /// </summary>
        [SerializeField]
        [FormerlySerializedAs("loadFromResources")]
        private bool isLoadingFromResources;

        /// <summary>
        /// Resources path
        /// </summary>
        [SerializeField]
        private string resourcesPath = defaultResourcesPath;

        /// <summary>
        /// Playlist
        /// </summary>
        [SerializeField]
        private MusicTitleData[] playlist = Array.Empty<MusicTitleData>();

        /// <summary>
        /// Is loading from resources
        /// </summary>
        public bool IsLoadingFromResources
        {
            get => isLoadingFromResources;
            set => isLoadingFromResources = value;
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
        /// Playlist
        /// </summary>
        public MusicTitleData[] Playlist
        {
            get => playlist ?? Array.Empty<MusicTitleData>();
            set => playlist = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Awake
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            if (isLoadingFromResources)
            {
                AudioManager.LoadPlaylistFromResources(ResourcesPath);
            }
            else
            {
                AudioManager.Playlist = Playlist;
            }
        }
    }
}
