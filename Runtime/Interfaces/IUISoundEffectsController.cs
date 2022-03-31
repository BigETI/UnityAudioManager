using System.Collections.Generic;
using UnityAudioManager.Data;
using UnityEngine;
using UnityPatterns;

/// <summary>
/// Unity audio manager namespace
/// </summary>
namespace UnityAudioManager
{
    /// <summary>
    /// An interface that represents an UI sound effects controller
    /// </summary>
    public interface IUISoundEffectsController : IController
    {
        /// <summary>
        /// Is randomizing sound selection
        /// </summary>
        bool IsRandomizingSoundSelection { get; set; }

        /// <summary>
        /// UI sound effects
        /// </summary>
        UISoundEffectData[] UISoundEffects { get; set; }

        /// <summary>
        /// Sound effects lookup
        /// </summary>
        IReadOnlyDictionary<EEventTriggerType, IReadOnlyList<AudioClip>> SoundEffectsLookup { get; }
    }
}
