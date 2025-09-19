using System.Collections;
using UnityEngine;

public class RandomAutoAudioCue : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clips;

    [Header("Temps entre sons (aléatoire)")]
    [SerializeField] private Vector2 intervalRange = new Vector2(10f, 20f);

    [Header("Pitch & Volume random")]
    [SerializeField] private Vector2 pitchRange = new Vector2(1f, 1f);
    [SerializeField] private Vector2 volumeRange = new Vector2(1f, 1f);

    private void Start()
    {
        StartCoroutine(RandomPlayer());
    }

    private IEnumerator RandomPlayer()
    {
        while (true)
        {
            // Attendre un temps aléatoire avant de jouer
            float waitTime = Random.Range(intervalRange.x, intervalRange.y);
            yield return new WaitForSeconds(waitTime);

            PlayRandom();
        }
    }

    private void PlayRandom()
    {
        if (clips.Length == 0) return;

        AudioClip clip = clips[Random.Range(0, clips.Length)];
        source.pitch = Random.Range(pitchRange.x, pitchRange.y);
        source.volume = Random.Range(volumeRange.x, volumeRange.y);

        source.PlayOneShot(clip);
    }
}

