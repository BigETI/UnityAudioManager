using System;
using UnityAudioManager.Objects;
using UnityEngine;

/// <summary>
/// Unity audio manager data namespace
/// </summary>
namespace UnityAudioManager.Data
{
    /// <summary>
    /// Music title data
    /// </summary>
    [Serializable]
    public class MusicTitleData : IComparable<MusicTitleData>
    {
        /// <summary>
        /// Audio clip
        /// </summary>
        [SerializeField]
        private string audioClip;

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
        /// Audio clip
        /// </summary>
        public AudioClip AudioClip
        {
            get
            {
                if (audioClipObject == null)
                {
                    if (audioClip == null)
                    {
                        audioClip = string.Empty;
                    }
                    if (isResource)
                    {
                        audioClipObject = Resources.Load<AudioClip>(audioClip);
                    }
                }
                return audioClipObject;
            }
        }

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

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public MusicTitleData(MusicTitleData musicTitle)
        {
            if (musicTitle != null)
            {
                audioClip = musicTitle.audioClip;
                audioClipObject = musicTitle.audioClipObject;
                title = musicTitle.title;
                description = musicTitle.description;
                author = musicTitle.author;
                iconSprite = musicTitle.iconSprite;
                isResource = musicTitle.isResource;
                audioType = musicTitle.audioType;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="resourcesPath">Resources path</param>
        public MusicTitleData(MusicTitleObjectScript musicTitle, string resourcesPath)
        {
            if (musicTitle != null)
            {
                audioClipObject = musicTitle.AudioClip;
                audioClip = ((audioClipObject == null) ? string.Empty : (resourcesPath + "/" + audioClipObject.name));
                title = musicTitle.Title;
                description = musicTitle.Description;
                author = musicTitle.Author;
                iconSprite = musicTitle.IconSprite;
                isResource = true;
                audioType = AudioType.UNKNOWN;
            }
        }

        /// <summary>
        /// Compare to
        /// </summary>
        /// <param name="other">Other</param>
        /// <returns>Delta</returns>
        public int CompareTo(MusicTitleData other)
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
