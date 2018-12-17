using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	// Use this for initialization
	private bool isClick = false;   //鼠标是否按下
	public Transform rightPos;   //拖拽鸟的最大距离参照点
	public float maxDis = 3;  //拖拽鸟的最大距离

	private SpringJoint2D sp;

	private Rigidbody2D rg;

	void Awake() {
		sp = GetComponent<SpringJoint2D>();
		rg = GetComponent<Rigidbody2D>();
	}

	void Start () {
	}

	void OnMouseDown() {
		isClick = true;
	}

	void OnMouseUp() {
		isClick = false;
		rg.isKinematic = false;   //脱离运动学运算
		Invoke("Fly", 0.15f);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isClick) {
			transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);   //屏幕坐标转为世界坐标
			if(Vector3.Distance(transform.position, rightPos.position) > maxDis) {
				Vector3 pos = (transform.position - rightPos.position).normalized; //单位化向量(返回长度为一的向量)
				pos *= maxDis;
				transform.position = pos + rightPos.position;
			}
		}
	}



	void Fly() {
		sp.enabled = false;    //禁用关节弹簧
	}
}
