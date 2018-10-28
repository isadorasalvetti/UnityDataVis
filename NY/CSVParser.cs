using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MAPBOX
using Mapbox.Utils;
using Mapbox.Examples;

public class Pair<T, U> {
    public Pair() {
    }

    public Pair(T first, U second) {
        this.First = first;
        this.Second = second;
    }

    public T First { get; set; }
    public U Second { get; set; }
};

//PARSE CSV DATA into dictionary.
public class CSVParser : MonoBehaviour {
	//Data format: Latitude, Longitude, Price, Type, Food, Venue, Sub Category
	public Dictionary<Pair<double, double>, int> Hotels; //Hotel lat n long and price
	public Dictionary<Pair<double, double>, Pair<string, string>> Restaurants, Venues; //Restaurants and Venues by lat n long and type n subtype.

	public TextAsset csvPath; //file to be parsed 

	private char lineSeperater = '\n'; // It defines line seperate character
	private char fieldSeperator = ','; // It defines field seperate chracter

	public GameObject map;	
	
	public void Start(){
		Hotels = new Dictionary<Pair<double, double>, int>();
		Venues = new Dictionary<Pair<double, double>, Pair<string, string>>();
		Restaurants = new Dictionary<Pair<double, double>, Pair<string, string>>();
		
		readData();
		addMarkers(Hotels);
		map.GetComponent<SpawnOnMap>().Spawn();
	}


	private void readData(){
		string[] records = csvPath.text.Split(lineSeperater);
		foreach (string record in records){
			parseString(record);
		}
	}

	private bool parseString(string line){
		string[] fields = line.Split (fieldSeperator);

		double lat, lon;
		if (!double.TryParse(fields[0], out lat)) return false;
		double.TryParse(fields[1], out lon);

		int price;
		if (int.TryParse(fields[2],out price)){
			Hotels[new Pair<double, double>(lat, lon)] = price;
			return true;
		}

		else if (fields[3].Length > 1 || fields[4].Length > 1) {
			//if (fields[5].Length < 2) fields[5] = "null";
			//if (fields[6].Length < 2) fields[6] = "null";
			Restaurants [new Pair<double, double>(lat, lon)] = new Pair<string, string>(fields[3], fields[4]);
			return true;
		}

		else if (fields[5].Length > 1 || fields[6].Length > 1){
			//if (fields[5].Length < 2) fields[5] = "null";
			//if (fields[6].Length < 2) fields[6] = "null";
			Venues [new Pair<double, double>(lat, lon)] = new Pair<string, string>(fields[5], fields[6]);
			return true;
		}
		return false;
	}

	//SPAWN MARKERS on map using mapbox
	void addMarkers(Dictionary<Pair<double, double>, int> data){
		foreach(KeyValuePair<Pair<double, double>, int> d in data){
			Vector2d latLon = new Vector2d(d.Key.First, d.Key.Second);
			map.GetComponent<SpawnOnMap>()._locations.Add(latLon);
		}
	}

}
