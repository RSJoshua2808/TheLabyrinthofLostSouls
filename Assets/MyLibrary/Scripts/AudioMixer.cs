using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MusicTransition : MonoBehaviour {

    public AudioMixer mixer;
    public string musicVolParameter = "musicVol"; // Match exposed parameter name

    public float fadeOutTime = 1f;
    public float fadeInTime = 1f;

    public AudioSource currentMusic;
    public AudioSource nextMusic;

    private void Start() {
        // Ensure the first music track is playing
        if (currentMusic != null && currentMusic.isPlaying == false) {
            currentMusic.Play();
        }
    }

    public void TransitionToNewTrack(AudioSource nextMusic) {
        this.nextMusic = nextMusic;
        StartCoroutine(FadeTransition());
    }

        IEnumerator FadeTransition() {
        // Fade out current music
        float currentTime = 0f;
        while (currentTime < fadeOutTime) {
            // Lerp the volume to zero
            mixer.SetFloat(musicVolParameter, Mathf.Lerp(1f, 0f, currentTime / fadeOutTime));
            currentTime += Time.deltaTime;
            yield return null;
        }
        // Stop the current music
        if (currentMusic != null) {
            currentMusic.Stop();
        }
        // Play the new music
        if (nextMusic != null) {
            nextMusic.Play();
        }
        // Fade in new music
        currentTime = 0f;
        while (currentTime < fadeInTime) {
            // Lerp the volume to one
            mixer.SetFloat(musicVolParameter, Mathf.Lerp(0f, 1f, currentTime / fadeInTime));
            currentTime += Time.deltaTime;
            yield return null;
        }
        // Update current music reference
        currentMusic = nextMusic;
        nextMusic = null;

        mixer.SetFloat(musicVolParameter, 1f); // Ensure the new music is fully audible

        // Reset volume to 1f
        mixer.SetFloat(musicVolParameter, 1f);
    }
}