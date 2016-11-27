using UnityEngine;
using System.Collections;
using UnityEngine.Networking;



[RequireComponent (typeof(SpriteRenderer))]
public class TileInfo : NetworkBehaviour {

	[SyncVar][Range(0,6)]public int terrainType;
	public Sprite sprite;
	public Vector2 targetPosition;
	public float speed;
	public Sprite[] sprites;
	public Card[] Faction1;
	public Card[] Faction2;
	public Card[] Faction3;
	public Card[] Faction4;
	public Card[] Monsters;

	// Use this for initialization
	void Start () {
		sprite = sprites [terrainType];
		gameObject.GetComponent<SpriteRenderer> ().sprite = sprite;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (targetPosition.y < gameObject.transform.position.y) {
			Vector3 currentPosition = gameObject.transform.position;
			currentPosition.y -= speed;
			gameObject.transform.position = currentPosition;
		}
	
	}
}
