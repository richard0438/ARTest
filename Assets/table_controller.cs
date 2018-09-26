using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class table_controller : MonoBehaviour {

	public GameObject table;
	public GameObject markwidth;
	public GameObject buttom;

	private bool visible = false;
	private Vector3 left,right,down;
	// Use this for initialization
	public void Table () {
		right = new Vector2(table.transform.position.x + ((RectTransform)markwidth.transform).rect.width, table.transform.position.y);
		left = table.transform.position;
		table.transform.position = right;
	}
	
	// Update is called once per frame
	// void Update () {
		
	// }

	public void MoveTable () {
		if (visible == true) {
			table.transform.position = new Vector2(table.transform.position.x + ((RectTransform)markwidth.transform).rect.width, table.transform.position.y);
			visible = false;
			Debug.Log(table.transform.position.x );
		}
		else {
			table.transform.position = new Vector2(table.transform.position.x - ((RectTransform)markwidth.transform).rect.width, table.transform.position.y);
			visible = true;
			Debug.Log(((RectTransform)markwidth.transform).rect.width);
		}
	}

}
