using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate_Spheres : MonoBehaviour {

    public GameObject _SpherePrefab;

    GameObject[] _Sphere = new GameObject[24];
    public float minScale;
    public float maxScale;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 24; i++)
        {
	        
	        GameObject _instanceSphere = (GameObject) Instantiate(_SpherePrefab);	
	        _instanceSphere.transform.position = this.transform.position;
	        _instanceSphere.transform.parent = this.transform;
	        _instanceSphere.name = "InstanceSphere" + i;
	        transform.eulerAngles = new Vector3(0, 90 , 0); 
	        _instanceSphere.transform.position = Vector3.right * i;
	        _Sphere[i] = _instanceSphere;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < 24; i++ )
        {
            if (_Sphere != null)
            {
                _Sphere[i].transform.localScale = new Vector3(Music._audioSample[i] * minScale , Music._audioSample[i] * maxScale , Music._audioSample[i] * maxScale);
            }
        }
	}
}
