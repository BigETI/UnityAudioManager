using System;
using System.Collections.Generic;
using UnityAudioManager.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityPatterns.Controllers;

/// <summary>
/// Unity audio manager controllers namespace
/// </summary>
namespace UnityAudioManager.Controllers
{
    /// <summary>
    /// A class that describes an UI sound effects controller script
    /// </summary>
    [RequireComponent(typeof(EventTrigger))]
    public class UISoundEffectsControllerScript : AControllerScript, IUISoundEffectsController
    {
        /// <summary>
        /// Is randomizing sound selection
        /// </summary>
        [SerializeField]
        [FormerlySerializedAs("randomizeSoundSelection")]
        private bool isRandomizingSoundSelection;

        /// <summary>
        /// UI sound effects
        /// </summary>
        [SerializeField]
        [FormerlySerializedAs("soundEffects")]
        private UISoundEffectData[] uiSoundEffects = default;

        /// <summary>
        /// Sound effects lookup
        /// </summary>
        private Dictionary<EEventTriggerType, IReadOnlyList<AudioClip>> soundEffectsLookup;

        /// <summary>
        /// Toggle fix
        /// </summary>
        private bool toggleFix;

        /// <summary>
        /// Is randomizing sound selection
        /// </summary>
        public bool IsRandomizingSoundSelection
        {
            get => isRandomizingSoundSelection;
            set => isRandomizingSoundSelection = value;
        }

        /// <summary>
        /// UI sound effects
        /// </summary>
        public UISoundEffectData[] UISoundEffects
        {
            get => uiSoundEffects ?? Array.Empty<UISoundEffectData>();
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                uiSoundEffects = (UISoundEffectData[])value.Clone();
            }
        }

        /// <summary>
        /// Sound effects lookup
        /// </summary>
        public IReadOnlyDictionary<EEventTriggerType, IReadOnlyList<AudioClip>> SoundEffectsLookup
        {
            get
            {
                if (soundEffectsLookup == null)
                {
                    soundEffectsLookup = new Dictionary<EEventTriggerType, IReadOnlyList<AudioClip>>();
                    foreach (UISoundEffectData sound_effect in UISoundEffects)
                    {
                        if (sound_effect != null)
                        {
                            if (sound_effect.SoundEffectAudioClip != null)
                            {
                                List<AudioClip> audio_clips = null;
                                if (soundEffectsLookup.ContainsKey(sound_effect.EventTriggerType))
                                {
                                    audio_clips = (List<AudioClip>)soundEffectsLookup[sound_effect.EventTriggerType];
                                }
                                else
                                {
                                    audio_clips = new List<AudioClip>();
                                    soundEffectsLookup.Add(sound_effect.EventTriggerType, audio_clips);
                                }
                                audio_clips.Add(sound_effect.SoundEffectAudioClip);
                            }
                        }
                    }
                }
                return soundEffectsLookup;
            }
        }

        /// <summary>
        /// Trigger event
        /// </summary>
        /// <param name="eventTriggerType">Event trigger type</param>
        private void TriggerEvent(EEventTriggerType eventTriggerType)
        {
            if (SoundEffectsLookup.ContainsKey(eventTriggerType))
            {
                if (isRandomizingSoundSelection)
                {
                    IReadOnlyList<AudioClip> audio_clips = SoundEffectsLookup[eventTriggerType];
                    if (audio_clips.Count > 0)
                    {
                        AudioManager.PlaySoundEffect(audio_clips[UnityEngine.Random.Range(0, audio_clips.Count)]);
                    }
                }
                else
                {
                    foreach (AudioClip audio_clip in SoundEffectsLookup[eventTriggerType])
                    {
                        AudioManager.PlaySoundEffect(audio_clip);
                    }
                }
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        protected virtual void Start()
        {
            EventTrigger event_trigger = GetComponent<EventTrigger>();
            if (event_trigger != null)
            {
                foreach (EventTrigger.Entry entry in event_trigger.triggers)
                {
                    entry.callback.AddListener((baseEvent) =>
                    {
                        TriggerEvent((EEventTriggerType)(entry.eventID));
                    });
                }
            }
            Button button = GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() =>
                {
                    TriggerEvent(EEventTriggerType.Click);
                });
            }
            InputField input_field = GetComponent<InputField>();
            if (input_field != null)
            {
                input_field.onValueChanged.AddListener((value) =>
                {
                    TriggerEvent(EEventTriggerType.ValueChanged);
                });
                input_field.onEndEdit.AddListener((value) =>
                {
                    TriggerEvent(EEventTriggerType.EndEdit);
                });
            }
            Slider slider = GetComponent<Slider>();
            if (slider != null)
            {
                slider.onValueChanged.AddListener((value) =>
                {
                    TriggerEvent(EEventTriggerType.ValueChanged);
                });
            }
            Toggle toggle = GetComponent<Toggle>();
            if (toggle != null)
            {
                toggleFix = toggle.isOn;
                toggle.onValueChanged.AddListener((value) =>
                {
                    if (toggleFix != value)
                    {
                        toggleFix = value;
                        TriggerEvent(EEventTriggerType.ValueChanged);
                    }
                });
            }
        }
    }
}
