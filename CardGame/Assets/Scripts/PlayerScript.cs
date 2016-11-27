using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {



	public Card[] hand;
	public Card[] deck;
	// Use this for initialization
	void Start () {
		gameObject.name = Constants.DeckName;
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
