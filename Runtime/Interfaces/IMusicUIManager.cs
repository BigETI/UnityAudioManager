/// <summary>
/// Unity audio manager namespace
/// </summary>
namespace UnityAudioManager
{
    /// <summary>
    /// An interface that represents a music UI manager
    /// </summary>
    public interface IMusicUIManager
    {
        /// <summary>
        /// Show play
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        void ShowPlay(IMusicTitleData musicTitle);

        /// <summary>
        /// Hide play
        /// </summary>
        void HidePlay();
    }
}
