using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {
    [Header("SFX")] [SerializeField] private AudioClip WallBounce;
    [SerializeField] private AudioClip PaddleBounce;
    [SerializeField] private AudioClip BrickBounce;
    [SerializeField] private AudioClip BrickBreak;

    public static AudioController Instance;

    private AudioSource _audioSource;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void PlayOneShotSFX(AudioClip clip) {
        _audioSource.PlayOneShot(clip);
    }

    public void PlayWallBounce() {
        PlayOneShotSFX(WallBounce);
    }

    public void PlayPaddleBounce() {
        PlayOneShotSFX(PaddleBounce);
    }

    public void PlayBrickBounce() {
        PlayOneShotSFX(BrickBounce);
    }

    public void PlayBrickBreak() {
        PlayOneShotSFX(BrickBreak);
    }
}