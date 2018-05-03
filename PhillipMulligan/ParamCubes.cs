using System.Collections.Generic;
using UnityEngine;

public class ParamCubes : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMulti;
    public bool _useBuffer;
    Material _material;
    
    // Use this for initialization
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        float yScale = (float)((Music._audioBandBuffer[_band] * _scaleMulti ) + _startScale);
        
        yScale = Mathf.Clamp(yScale, 0.01f, 100f);
        // (Music._freqBand[_band] * _scaleMulti) + _startScale
        //print(yScale);

        if (_useBuffer)
        {
            
            transform.localScale = new Vector3(transform.localScale.x, yScale , transform.localScale.z);
            Color _color = new Color(Music._audioBandBuffer[_band], Music._audioBandBuffer[_band], Music._audioBandBuffer[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
        if (!_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, yScale, transform.localScale.z);
            Color _color = new Color(Music._audioBand[_band], Music._audioBand[_band], Music._audioBand[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
    }

    
}
