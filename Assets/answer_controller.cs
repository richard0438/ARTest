using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class answer_controller : MonoBehaviour {

	public Transform btnParent;
	public Text answer;
	private Button[] btns;
	private string ans = "";

	// Use this for initialization
	void Start () {
		 btns = new Button[btnParent.childCount];
		 answer.text = "Your answer";

		 for (int i = 0; i < btns.Length; i++) {
			 btns[i] = btnParent.GetChild(i).GetComponent<Button>();
			 btns[i].onClick.AddListener(OnClick);
		 }
	}
	
	// Update is called once per frame
	void OnClick () {
		string btnName = EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name;
		if (btnName == "selection1") {
			ans = ans + "A ";
		} 
		else if (btnName == "selection2") {
			ans = ans + "B ";
		} 
		else if (btnName == "selection3") {
			ans = ans + "C ";
		} 
		else if (btnName == "selection4") {
			ans = ans + "D ";
		} 
		else if (btnName == "send_answer") {
			Debug.Log(ans);
			answer.text = ans;
			ans ="";
		}
		
	}
}
