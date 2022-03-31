using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Unity audio manager namespace
/// </summary>
namespace UnityAudioManager
{
    /// <summary>
    /// An interface that represents audio settings data
    /// </summary>
    public interface IAudioSettingsData
    {
        /// <summary>
        /// Audio clip
        /// </summary>
        AudioClip AudioClip { get; }

        /// <summary>
        /// Output
        /// </summary>
        AudioMixerGroup Output { get; }

        /// <summary>
        /// Mute
        /// </summary>
        bool Mute { get; }

        /// <summary>
        /// Bypass effects
        /// </summary>
        bool BypassEffects { get; }

        /// <summary>
        /// Bypass listener effects
        /// </summary>
        bool BypassListenerEffects { get; }

        /// <summary>
        /// Bypass reverb zones
        /// </summary>
        bool BypassReverbZones { get; }

        /// <summary>
        /// Play on awake
        /// </summary>
        bool PlayOnAwake { get; }

        /// <summary>
        /// Loop
        /// </summary>
        bool Loop { get; }

        /// <summary>
        /// Priority
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// Volume
        /// </summary>
        float Volume { get; }

        /// <summary>
        /// Pitch
        /// </summary>
        float Pitch { get; }

        /// <summary>
        /// Stereo pan
        /// </summary>
        float StereoPan { get; }

        /// <summary>
        /// Spatial blend
        /// </summary>
        float SpatialBlend { get; }

        /// <summary>
        /// Reverb zone mix
        /// </summary>
        float ReverbZoneMix { get; }

        /// <summary>
        /// Doppler level
        /// </summary>
        float DopplerLevel { get; }

        /// <summary>
        /// Spread
        /// </summary>
        float Spread { get; }

        /// <summary>
        /// Volume roloff
        /// </summary>
        AudioRolloffMode VolumeRolloff { get; }

        /// <summary>
        /// Minimum distance
        /// </summary>
        float MinDistance { get; }

        /// <summary>
        /// Maximum distance
        /// </summary>
        float MaxDistance { get; }

        /// <summary>
        /// Apply settings
        /// </summary>
        /// <param name="audioSource">Audio source</param>
        void ApplySettings(AudioSource audioSource);
    }
}
