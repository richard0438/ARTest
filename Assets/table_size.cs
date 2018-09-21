using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class table_size : MonoBehaviour {

	public GameObject canvas;
	public GameObject table;
	


	// Use this for initialization
	void Start () {
		RectTransform rtt = (RectTransform)table.transform;
		RectTransform rtc = (RectTransform)canvas.transform;
		float h = rtc.rect.height;
		float w = rtt.rect.width;
		// rtt.sizeDelta = new Vector2(rtt.rect.width, h);
		this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);
	}
	
	// Update is called once per frame
	void Update () {
		// RectTransform rtc = (RectTransform)canvas.transform;
		// RectTransform rtt = (RectTransform)table.transform;
		// float h = rtc.rect.height;
		// rtt.sizeDelta = new Vector2(rtt.rect.width, h);
	}
}
