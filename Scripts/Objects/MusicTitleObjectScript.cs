using UnityEngine;

/// <summary>
/// Unity audio manager objects namespace
/// </summary>
namespace UnityAudioManager.Objects
{
    /// <summary>
    /// Music title object script class
    /// </summary>
    [CreateAssetMenu(fileName = "MusicTitle", menuName = "Utils/Music title")]
    public class MusicTitleObjectScript : ScriptableObject
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
        public string Title
        {
            get
            {
                if (title == null)
                {
                    title = string.Empty;
                }
                return title;
            }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get
            {
                if (description == null)
                {
                    description = string.Empty;
                }
                return description;
            }
        }

        /// <summary>
        /// Author
        /// </summary>
        public string Author
        {
            get
            {
                if (author == null)
                {
                    author = string.Empty;
                }
                return author;
            }
        }

        /// <summary>
        /// Icon sprite
        /// </summary>
        public Sprite IconSprite => iconSprite;
    }
}
