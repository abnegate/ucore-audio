using UnityEngine;
using System.Collections;

namespace UCore.Audio
{
    public class BGAudio : MonoBehaviour
    {
        public float startVolume = 0f;
        public float maxVolume = 1.0f;
        public float incrementStep = 0.01f;
        public float timeStepSeconds = 0.3f;
        public bool dontDestroyOnLoad = true;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.volume = startVolume;

            _audioSource.Play();

            StartCoroutine(FadeAudioVolume(_audioSource, 1));

            if (dontDestroyOnLoad) {
                DontDestroyOnLoad(gameObject);
            }
        }

        private IEnumerator FadeAudioVolume(AudioSource source, int direction)
        {
            for (float i = source.volume;
                source.volume <= maxVolume && source.volume >= 0f;
                i += incrementStep * direction
            ) {
                source.volume = i;
                yield return new WaitForSeconds(timeStepSeconds);
            }
        }
    }
}