using System;
using UnityAudioManager.Objects;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Unity audio manager data namespace
/// </summary>
namespace UnityAudioManager.Data
{
    /// <summary>
    /// Music title data
    /// </summary>
    [Serializable]
    public class MusicTitleData : IMusicTitleData
    {
        /// <summary>
        /// Audio clip name
        /// </summary>
        [SerializeField]
        [FormerlySerializedAs("audioClip")]
        private string audioClipName;

        /// <summary>
        /// Title
        /// </summary>
        [SerializeField]
        private string title;

        /// <summary>
        /// Description
        /// </summary>
        [TextArea]
        [SerializeField]
        private string description;

        /// <summary>
        /// Author
        /// </summary>
        [SerializeField]
        private string author;

        /// <summary>
        /// Icon sprite
        /// </summary>
        [SerializeField]
        private Sprite iconSprite;

        /// <summary>
        /// Is resource
        /// </summary>
        [SerializeField]
        private bool isResource;

        /// <summary>
        /// Audio type
        /// </summary>
        [SerializeField]
        private AudioType audioType = AudioType.UNKNOWN;

        /// <summary>
        /// Audio clip
        /// </summary>
        private AudioClip audioClipObject;

        /// <summary>
        /// Audio clip name
        /// </summary>
        public string AudioClipName => audioClipName ?? string.Empty;

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

        /// <summary>
        /// Is resource
        /// </summary>
        public bool IsResource => isResource;

        /// <summary>
        /// Audio type
        /// </summary>
        public AudioType AudioType => audioType;

        /// <summary>
        /// Audio clip
        /// </summary>
        public AudioClip AudioClip =>
            audioClipObject = ((audioClipObject == null) && isResource) ? Resources.Load<AudioClip>(AudioClipName) : audioClipObject;

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public MusicTitleData(MusicTitleData musicTitle)
        {
            if (musicTitle == null)
            {
                throw new ArgumentNullException(nameof(musicTitle));
            }
            audioClipName = musicTitle.AudioClipName;
            title = musicTitle.Title;
            description = musicTitle.Description;
            author = musicTitle.Author;
            iconSprite = musicTitle.IconSprite;
            isResource = musicTitle.isResource;
            audioType = musicTitle.audioType;
            audioClipObject = musicTitle.audioClipObject;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="resourcesPath">Resources path</param>
        public MusicTitleData(MusicTitleObjectScript musicTitle, string resourcesPath)
        {
            if (!musicTitle)
            {
                throw new ArgumentNullException(nameof(musicTitle));
            }
            audioClipObject = musicTitle.AudioClip;
            audioClipName = audioClipObject ? $"{ resourcesPath }/{ audioClipObject.name }" : string.Empty;
            title = musicTitle.Title;
            description = musicTitle.Description;
            author = musicTitle.Author;
            iconSprite = musicTitle.IconSprite;
            isResource = true;
            audioType = AudioType.UNKNOWN;
        }

        /// <summary>
        /// Compare to
        /// </summary>
        /// <param name="other">Other</param>
        /// <returns>Delta</returns>
        public int CompareTo(IMusicTitleData other)
        {
            int ret = -1;
            if (other != null)
            {
                ret = Title.CompareTo(other.Title);
                if (ret == 0)
                {
                    ret = Author.CompareTo(other.Author);
                    if (ret == 0)
                    {
                        ret = Description.CompareTo(other.Description);
                    }
                }
            }
            return ret;
        }
    }
}
