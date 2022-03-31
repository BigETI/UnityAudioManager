using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity audio manager namespace
/// </summary>
namespace UnityAudioManager
{
    /// <summary>
    /// An interface that represents an audio group
    /// </summary>
    public interface IAudioGroup
    {
        /// <summary>
        /// Audio sources
        /// </summary>
        IReadOnlyList<AudioSource> AudioSources { get; }

        /// <summary>
        /// Current sounds index
        /// </summary>
        uint CurrentSoundsIndex { get; }

        /// <summary>
        /// Is muted
        /// </summary>
        bool IsMuted { get; set; }

        /// <summary>
        /// Volume
        /// </summary>
        float Volume { get; set; }

        /// <summary>
        /// Spatialize
        /// </summary>
        bool Spatialize { get; set; }

        /// <summary>
        /// Spatial blend
        /// </summary>
        float SpatialBlend { get; set; }

        /// <summary>
        /// Apply settings
        /// </summary>
        /// <param name="audioSettings">Audio settings</param>
        void ApplySettings(IAudioSettingsData audioSettings);

        /// <summary>
        /// Play
        /// </summary>
        /// <param name="clip"></param>
        void Play(AudioClip clip);
    }
}
