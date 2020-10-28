using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour
{
    AudioSource aud;

    float[] spectrum;

    float freq;

    Vector3 initScale;
    [SerializeField]
    float scaleFactor = 5f;

    void Awake() 
    {
        spectrum = new float[256];
        aud = GetComponent<AudioSource>();    
    }

    void Start()
    {
        initScale = transform.localScale;
    }    

    void Update()
    {
        aud.GetOutputData(spectrum, 0);   
        for(int i = 0; i < spectrum.Length; i++)
        {
            freq = spectrum[i];
            //Debug.Log(freq);
        }
        transform.localScale = (Vector3.one * freq * scaleFactor) + initScale;
    }
}
