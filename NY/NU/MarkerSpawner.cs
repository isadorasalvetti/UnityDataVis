using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Examples;
using CoordConversion;

//NOT IN USE!
/*
public class MarkerSpawner : MonoBehaviour {
	public GameObject map;
	private ScreeConditions sc;

	void Start(){
		//float mZ = map.GetComponent<AbstractMap>().Zoom;
		//double cLat = map.GetComponent<AbstractMap>().CenterLatitudeLongitude.x;
		//double cLon = map.GetComponent<AbstractMap>().CenterLatitudeLongitude.y;
		//sc = new ScreeConditions(cLat, cLon, 0, 0, mZ);
	}

	public void addMarkers(Dictionary<Pair<double, double>, int> data){
		foreach(KeyValuePair<Pair<double, double>, int> d in data){
			Vector2d latLon = new Vector2d(d.Key.First, d.Key.Second);
			map.GetComponent<SpawnOnMap>()._locations.Add(latLon);

		}
	}

}
*/
