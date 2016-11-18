using UnityEngine;
using System.Collections;
using UnityEngine.Networking;




public class CustomNM : NetworkManager {
	public GameObject Builder;
	public override void OnStartServer(){
		Builder.GetComponent<MapBuilder>().Create ();
	}
}
