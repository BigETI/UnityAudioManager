using UnityAudioManager.Data;

/// <summary>
/// Unity audio manager namespace
/// </summary>
namespace UnityAudioManager
{
    /// <summary>
    /// An interface that represents a load playlist trigger
    /// </summary>
    public interface ILoadPlaylistTrigger
    {
        /// <summary>
        /// Is loading from resources
        /// </summary>
        bool IsLoadingFromResources { get; set; }

        /// <summary>
        /// Resources path
        /// </summary>
        string ResourcesPath { get; set; }

        /// <summary>
        /// Playlist
        /// </summary>
        MusicTitleData[] Playlist { get; set; }
    }
}
