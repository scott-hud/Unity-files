using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class Music : MonoBehaviour {
    private AudioSource _MusicSource;

    public static float[] _audioSample = new float [512];
    public static float[] _freqBand = new float[8];
    public static float[] _buffer = new float[8];
    float[] _bufferDecrease = new float[8];

    float[] _freqBandHeighest = new float[8];
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];


    // Use this for initialization
    void Start () {
        _MusicSource = GetComponent<AudioSource>();

        for (int q = 0; q < 8; q++)
        {
            _freqBandHeighest[q] = 0;
            _audioBandBuffer[q] = 1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        PlayAudio();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();

    }

    void CreateAudioBands()
    {
        for( int q = 0; q < 8; q++)
        {
            if (_freqBand[q] > _freqBandHeighest[q])
            {
                _freqBandHeighest[q] = _freqBand[q];
            }
            _audioBand[q] = (_freqBand[q] / _freqBandHeighest[q]);
            _audioBandBuffer[q] = (_audioBand[q] / _freqBandHeighest[q]);
            Debug.Log(_audioBandBuffer[q]);
        }
    }

    void PlayAudio()
    {
        _MusicSource.GetSpectrumData(_audioSample, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; g++)
        {
            if (_freqBand [g] > _buffer[g])
            {
                _buffer[g] = _freqBand[g];
                _bufferDecrease[g] = 0.005f;
            }

            if (_freqBand[g] < _buffer[g])
            {
                _buffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBands()
    {
        /*
         * 44100 / 512 = 86 hertz per sample
         * 20 - 60 hertz
         * 60 - 250 hertz
         * 250 - 500 hertz
         * 500- 2000 hertz
         * 2000 - 4000 hertz
         * 4000 - 6000 hertz
         * 6000- 40000 hertz
         */
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average +=// _audioSample[count]; //* (count * 1);
                Mathf.Clamp(_audioSample[count], 0.001f, 2200f);
                count++;
                
            }
            //Debug.Log(average);
            average /= count;
            
            _freqBand[i] = average * 10;

            
        
        }
    }

}
