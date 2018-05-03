using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightsBehaviour : MonoBehaviour {
    public int _band;
    public float _minIntense, maxIntense;
    Light _light;


	// Use this for initialization
	void Start () {
        _light = GetComponent<Light>();

	}
	
	// Update is called once per frame
	void Update () {
        _light.intensity = (Music._audioBandBuffer[_band] * (maxIntense - _minIntense)) + _minIntense;
	}
}
