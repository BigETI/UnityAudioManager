using System;
using UnityEngine;

/// <summary>
/// Unity audio manager namespace
/// </summary>
namespace UnityAudioManager
{
    /// <summary>
    /// An interface that represents music title data
    /// </summary>
    public interface IMusicTitleData : IComparable<IMusicTitleData>
    {
        /// <summary>
        /// Audio clip name
        /// </summary>
        string AudioClipName { get; }

        /// <summary>
        /// Title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Description
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Author
        /// </summary>
        string Author { get; }

        /// <summary>
        /// Icon sprite
        /// </summary>
        Sprite IconSprite { get; }

        /// <summary>
        /// Audio clip
        /// </summary>
        AudioClip AudioClip { get; }
    }
}
