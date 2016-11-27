using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Card : NetworkBehaviour {


	public Sprite Border;
	public Sprite Image;
	public string Name;
	public string FlavourText;


	public GUIText ForceNumber;
	public GUIText MagicNumber;
	public GUIText Flavour;
	public GUIText GUIName;

	public int Force;
	public int Magic;
	[Range(1,2)]public int Movement =1;
	[Range(0,5)]public int FavouredTerrain; 
	public int FavTerForceBonus;
	public int FavTerMagicBonus;
	public int MovementForceBonus;
	public int MovementMagicBonus;

	public bool Leader;
	public bool Walker;
	public bool Companion;
	public bool Monster;

	// Use this for initialization
	void Start () {

		int markers = 0;

		//Ensure that any card can have only one entity marker
		if (Leader) {
			markers++;
		}
		if (Walker) {
			markers++;
		}
		if (Companion) {
			markers++;
		}
		if (Monster) {
			markers++;
		}

		if (markers > 1) {
			throw new InvalidCardParametersException ("Card can't have more than one entity marker at once!");
		}

		//Negative power makes no sense
		if (Force < 0) {
			Force = 0;
		}
		if (Magic < 0) {
			Magic = 0;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Play(Vector2 position){
		
	}

	void Move(Vector2 dir){
		if (dir.x == 0 || dir.y == 0) {
		}
	}



	class InvalidCardParametersException : System.Exception{
		public InvalidCardParametersException() : base(){}
		public InvalidCardParametersException (string msg) : base(msg){}
		public InvalidCardParametersException (string msg, System.Exception inner) : base(msg, inner){}
		protected InvalidCardParametersException(System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context) { }
	}
}


