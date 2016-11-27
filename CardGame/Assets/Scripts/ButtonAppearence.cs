using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class ButtonAppearence : MonoBehaviour {


	[SerializeField]Sprite transparent;
	GameObject deck;

	[SerializeField]Image border;
	[SerializeField]Image picture;
	[SerializeField]Text ForceNumber;
	[SerializeField]Text MagicNumber;
	[SerializeField]Text CardName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (deck) {
		} else {
			deck = GameObject.Find (Constants.DeckName);
			SetImages ();
		}
	}


	void SetImages(Sprite bord,Sprite pic){
		border.sprite = bord;
		picture.sprite = pic;
	}
	void SetImages(){
		border.sprite = transparent;
		picture.sprite = transparent;
		ForceNumber.text = "";
		MagicNumber.text = "";
		CardName.text = "";
	}
}
