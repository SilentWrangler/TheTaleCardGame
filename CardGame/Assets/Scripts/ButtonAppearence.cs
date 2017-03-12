using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class ButtonAppearence : MonoBehaviour {


	[SerializeField]Sprite transparent;
	[SerializeField]InfoSource SourceType;
	GameObject source;

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
		if (source) {
		} else {
			switch (SourceType){
			case InfoSource.Hand:
				source = GameObject.Find (Constants.DeckName);
				break;
			case InfoSource.Collection:
				source = GameObject.Find ("Collection");
				break;
			case InfoSource.SelectedCard:
				source = GameObject.Find ("SelectedCard");
				break;

			}
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



enum InfoSource{
	Hand,
	Collection,
	SelectedCard
}
