using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_controller : MonoBehaviour {

	public float sensitivityX = 5.0f;
	public float sensitivityY = 5.0f;
	// public float sensitivityZ = 5.0f;
	public int down = 0;
	private Touch oldTouch1;  //上次触摸点1(手指1)
	private Touch oldTouch2;  //上次触摸点2(手指2)

	// Use this for initialization
	// void Start () {
		
	// }
	
	// Update is called once per frame
	void Update () {
		// if (Input.GetMouseButtonDown(0))
		// 	down = 1;
		// else if (Input.GetMouseButtonUp(0))
		// 	down = 0;

		// if(down == 1) {
		// 	float rotationX = Input.GetAxis("Mouse X") * sensitivityX;
		// 	float rotationY = Input.GetAxis("Mouse Y") * sensitivityY;
		// 	// float rotationZ = Input.GetAxis("Mouse Z") * sensitivityZ;
		// 	// if((rotationX * rotationX) >= (rotationY * rotationY)) {
		// 	// 	transform.Rotate(rotationX,0,0);
		// 	// }
		// 	// else {
		// 	// 	transform.Rotate(0,rotationY,0);
		// 	// }
		// 	transform.Rotate(rotationX,rotationY,0);
		// 	Debug.Log(rotationX);
		// }

		if (Input.touchCount == 1)
			down = 1;
		else if (Input.touchCount ==0)
			down = 0;
		else if (Input.touchCount ==2) 
			down = 2;

		if(down == 1) {
			Touch rTouch = Input.GetTouch (0);
			if( rTouch.phase == TouchPhase.Began ){
				return;
			}
			float rotationX = Input.GetAxis("Mouse X") * sensitivityX;
			float rotationY = Input.GetAxis("Mouse Y") * sensitivityY;
			// float rotationZ = Input.GetAxis("Mouse Z") * sensitivityZ;
			
			transform.Rotate(rotationX,rotationY,0);
			//Debug.Log(rotationX);
		}

		else if(down ==2) {
			Touch newTouch1 = Input.GetTouch (0);
			Touch newTouch2 = Input.GetTouch (1);
			//第2点刚开始接触屏幕, 只记录，不做处理
			if( newTouch2.phase == TouchPhase.Began ){
				oldTouch2 = newTouch2;
				oldTouch1 = newTouch1;
				return;
			}
		
			//计算老的两点距离和新的两点间距离，变大要放大模型，变小要缩放模型
			float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
			float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);
 
			//两个距离之差，为正表示放大手势， 为负表示缩小手势
			float offset = newDistance - oldDistance;
 
			//放大因子， 一个像素按 0.01倍来算(100可调整)
			float scaleFactor = offset / 100f;
			Vector3 localScale = transform.localScale;
			Vector3 scale = new Vector3(localScale.x + scaleFactor, localScale.y + scaleFactor, localScale.z + scaleFactor);
 
			//最小缩放到 0.3 倍
			if (scale.x > 0.3f && scale.y > 0.3f && scale.z > 0.3f) {
				transform.localScale = scale;
			}
 
			//记住最新的触摸点，下次使用
			oldTouch1 = newTouch1;
			oldTouch2 = newTouch2;

			
		}

		
	}
}
