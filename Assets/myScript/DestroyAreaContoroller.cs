using UnityEngine;
using System.Collections;

public class DestroyAreaContoroller : MonoBehaviour {


	//DestroyAreaオブジェクト
	private GameObject CameraObject;

	// Use this for initialization
	void Start () {
		//DestroyAreaオブジェクトを取得
		this.CameraObject = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		//MainCameraに追従する形でDestroyAreaを移動させる
		this.transform.position = new Vector3 (0, this.transform.position.y, this.CameraObject.transform.position.z);

	}


	void OnTriggerEnter(Collider other){
		//接触した障害物・コインのみの場合、オブジェクト削除を実施
		if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag" || other.gameObject.tag == "CoinTag") {
			Destroy (other.gameObject);
		}
	}

}
