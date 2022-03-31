using UnityEngine;

/// <summary>
/// Unity audio manager namespace
/// </summary>
namespace UnityAudioManager
{
    /// <summary>
    /// An interface that represents a music title object
    /// </summary>
    public interface IMusicTitleObject : UnityPatterns.IObject
    {
        /// <summary>
        /// Audio clip
        /// </summary>
        AudioClip AudioClip { get; }

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
    }
}
