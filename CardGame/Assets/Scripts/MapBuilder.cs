using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class MapBuilder : NetworkBehaviour {


	int [,] map;
	GameObject [,] tiles;

	public GameObject Tile;
	[Range(3,8)]public int size;
	[Range(2,4)]public int players;

	// Use this for initialization
	/*void Start () {
		Create ();
	}*/
	 
	public override void OnStartServer(){
		Create ();
	} 


	public void Create(){
		if (tiles!=null) {
			foreach (GameObject o in tiles) {
				Destroy (o);
			}
		}
		tiles = new GameObject[size,size] ;
		map = new int[size, size];
		Generate ();
		Build ();
	}


	void Generate(){
		System.Random pseudoRandom = new System.Random((int)DateTime.Now.Ticks);

		map [0, 0] = 6; //strongholds for player 1 and 2
		map [size - 1, size - 1] = 6;
		if (players > 2) {
			map [0, size - 1] = 6; //for player 3
		}
		if (players > 3) {
			map [size - 1, 0] = 6; //for player 4
		}
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (map [i, j] != 6) {
					map [i, j] = (int)pseudoRandom.Next (1, 6);
				}
			}
		}
	}

	void Build(){
		Vector3 pos = new Vector3();
		float startx = 0;
		float starty = Constants.map_increment * (size / 2);


		for (int x = size-1; x >= 0; x--) {
			float curx = startx;
			float cury = starty;
			//Debug.Log (curx);
			//Debug.Log (cury);
			for (int y = size-1; y >= 0; y--) {
				pos.x = curx;
				pos.y = cury;
				pos.z-=0.001f;
				Create (pos, map [x, y],x,y);
				curx -= Constants.map_increment;
				cury -= Constants.map_increment;
			}
			startx += Constants.map_increment;
			starty -= Constants.map_increment;
		}



	}

	
	void Create(Vector3 pos, int Created, int x, int y){
		GameObject o;
		TileInfo ti;
		o =(GameObject)Instantiate (Tile, pos, Quaternion.identity);
		o.name = "Tile" + x.ToString () + y.ToString ();
		ti = o.GetComponent<TileInfo> ();
		ti.terrainType = Created;
		ti.targetPosition = (Vector2)pos;
		NetworkServer.Spawn(o);
		tiles[x,y] = o;
	}

	
}
