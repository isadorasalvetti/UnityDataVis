using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;

public class TargetMarker : MonoBehaviour {

	public GameObject map;
	public int displayZoom = 14;
	private bool display = false;
	private Vector3 originalScale;

	// Use this for initialization
	void Start () {
		display = map.GetComponent<AbstractMap>().Zoom == displayZoom;
		originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		display = map.GetComponent<AbstractMap>().Zoom == displayZoom;
		if (display) transform.localScale = originalScale;
		else transform.localScale = new Vector3 (0, 0, 0);
	}
}
