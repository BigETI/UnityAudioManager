using System;
using UnityAudioManager.Data;
using UnityEngine;

/// <summary>
/// Unity audio manager triggers namespace
/// </summary>
namespace UnityAudioManager.Triggers
{
    /// <summary>
    /// Load playlist trigger script class
    /// </summary>
    public class LoadPlaylistTriggerScript : MonoBehaviour
    {
        /// <summary>
        /// Load from resources
        /// </summary>
        [SerializeField]
        private bool loadFromResources = default;

        /// <summary>
        /// Resources path
        /// </summary>
        [SerializeField]
        private string resourcesPath = "MusicTitles";

        /// <summary>
        /// Playlist
        /// </summary>
        [SerializeField]
        private MusicTitleData[] playlist = default;

        /// <summary>
        /// Resources path
        /// </summary>
        private string ResourcesPath
        {
            get
            {
                if (resourcesPath == null)
                {
                    resourcesPath = "MusicTitles";
                }
                return resourcesPath;
            }
        }

        /// <summary>
        /// Playlist
        /// </summary>
        private MusicTitleData[] Playlist
        {
            get
            {
                if (playlist == null)
                {
                    playlist = Array.Empty<MusicTitleData>();
                }
                return playlist;
            }
        }

        /// <summary>
        /// Awake
        /// </summary>
        public void Awake()
        {
            if (loadFromResources)
            {
                AudioManager.LoadPlaylistFromResources(ResourcesPath);
            }
            else
            {
                AudioManager.Playlist = Playlist;
            }
            Destroy(this);
        }
    }
}
