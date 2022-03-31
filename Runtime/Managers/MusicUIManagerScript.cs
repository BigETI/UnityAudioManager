using UnityEngine;
using UnityEngine.UI;
using UnityPatterns.Managers;

/// <summary>
/// Unity audio manager managers namespace
/// </summary>
namespace UnityAudioManager.Managers
{
    /// <summary>
    /// A class that describes a music UI manager script
    /// </summary>
    public class MusicUIManagerScript : AManagerScript<MusicUIManagerScript>, IMusicUIManager
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
        /// Show play
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public void ShowPlay(IMusicTitleData musicTitle)
        {
            if (titleText)
            {
                titleText.text = musicTitle.Title;
            }
            if (descriptionText)
            {
                descriptionText.text = musicTitle.Description;
            }
            if (authorText)
            {
                authorText.text = musicTitle.Author;
            }
            if (iconImage)
            {
                iconImage.sprite = ((musicTitle.IconSprite == null) ? defaultIconSprite : musicTitle.IconSprite);
            }
            if (panelAnimator)
            {
                panelAnimator.Play("Show");
            }
        }

        /// <summary>
        /// Hide play
        /// </summary>
        public void HidePlay()
        {
            if (panelAnimator)
            {
                panelAnimator.Play("Idle");
            }
        }
    }
}
