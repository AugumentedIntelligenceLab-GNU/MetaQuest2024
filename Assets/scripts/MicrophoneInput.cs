using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{
    public AudioSource audioSource;
    public float decibel;

    private void Start()
    {
        audioSource.clip = Microphone.Start(null, true, 10, AudioSettings.outputSampleRate);
        while (!(Microphone.GetPosition(null) > 0)) { } // 마이크 입력 대기
        audioSource.loop = true;
        audioSource.Play();
    }

    private void Update()
    {
        float[] samples = new float[audioSource.clip.samples];
        audioSource.clip.GetData(samples, 0);

        float maxSample = 0f;
        foreach (float sample in samples)
        {
            maxSample = Mathf.Max(maxSample, Mathf.Abs(sample));
        }

        decibel = 20 * Mathf.Log10(maxSample / 0.1f);
    }
}
