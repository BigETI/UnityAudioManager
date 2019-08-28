using UnityAudioManager.Data;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Unity audio manager managers namespace
/// </summary>
namespace UnityAudioManager.Managers
{
    /// <summary>
    /// Music UI controller script class
    /// </summary>
    public class MusicUIManagerScript : MonoBehaviour
    {
        /// <summary>
        /// Default icon sprite
        /// </summary>
        [SerializeField]
        private Sprite defaultIconSprite = default;

        /// <summary>
        /// Title text
        /// </summary>
        [SerializeField]
        private Text titleText = default;

        /// <summary>
        /// Description text
        /// </summary>
        [SerializeField]
        private Text descriptionText = default;

        /// <summary>
        /// Author text
        /// </summary>
        [SerializeField]
        private Text authorText = default;

        /// <summary>
        /// Icon image
        /// </summary>
        [SerializeField]
        private Image iconImage = default;

        /// <summary>
        /// Panel animator
        /// </summary>
        [SerializeField]
        private Animator panelAnimator = default;

        /// <summary>
        /// Instance
        /// </summary>
        public static MusicUIManagerScript Instance { get; private set; }

        /// <summary>
        /// Show play
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public void ShowPlay(MusicTitleData musicTitle)
        {
            if (titleText != null)
            {
                titleText.text = musicTitle.Title;
            }
            if (descriptionText != null)
            {
                descriptionText.text = musicTitle.Description;
            }
            if (authorText != null)
            {
                authorText.text = musicTitle.Author;
            }
            if (iconImage != null)
            {
                iconImage.sprite = ((musicTitle.IconSprite == null) ? defaultIconSprite : musicTitle.IconSprite);
            }
            if (panelAnimator != null)
            {
                panelAnimator.Play("Show");
            }
        }

        /// <summary>
        /// Hide play
        /// </summary>
        public void HidePlay()
        {
            if (panelAnimator != null)
            {
                panelAnimator.Play("Idle");
            }
        }

        /// <summary>
        /// Awake
        /// </summary>
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
