using UnityEngine;
using UnityPatterns.Objects;

/// <summary>
/// Unity audio manager objects namespace
/// </summary>
namespace UnityAudioManager.Objects
{
    /// <summary>
    /// A class that describes a music title object script
    /// </summary>
    [CreateAssetMenu(fileName = "MusicTitle", menuName = "Audio manager/Music title")]
    public class MusicTitleObjectScript : AObjectScript, IMusicTitleObject
    {
        /// <summary>
        /// Audio clip
        /// </summary>
        [SerializeField]
        private AudioClip audioClip = default;

        /// <summary>
        /// Title
        /// </summary>
        [SerializeField]
        private string title = default;

        /// <summary>
        /// Description
        /// </summary>
        [TextArea]
        [SerializeField]
        private string description = default;

        /// <summary>
        /// Author
        /// </summary>
        [SerializeField]
        private string author = default;

        /// <summary>
        /// Icon sprite
        /// </summary>
        [SerializeField]
        private Sprite iconSprite = default;

        /// <summary>
        /// Audio clip
        /// </summary>
        public AudioClip AudioClip => audioClip;

        /// <summary>
        /// Title
        /// </summary>
        public string Title => title ?? string.Empty;

        /// <summary>
        /// Description
        /// </summary>
        public string Description => description ?? string.Empty;

        /// <summary>
        /// Author
        /// </summary>
        public string Author => author ?? string.Empty;

        /// <summary>
        /// Icon sprite
        /// </summary>
        public Sprite IconSprite => iconSprite;
    }
}
