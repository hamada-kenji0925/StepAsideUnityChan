using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour {
	
	//carPrefabを入れる
	public GameObject carPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//cornPrefabを入れる
	public GameObject cornPrefab;
	//スタート地点
	private int startPos = -160;
	//ゴール地点
	private int goalPos = 120;
	//アイテムを出すX方向の範囲
	private float posRange = 3.4f;

	//発展課題
	//Unityちゃんオブジェクト変数宣言
	private GameObject unitychan;
	//Unityちゃん現在Z値座標
	private int unitychanZ;
	//初回アイテム生成範囲
	private int firstPos = -110;
	//アイテム生成が発生した段階のZ座標格納（初回スタート時の為、startPos値-160格納）
	private int ItemDistance = -160;
	//アイテム生成間隔
	private int itemInterval = 15;
	//アイテム生成したUnityちゃんのZ座標から50先の座標格納
	private int Coordinate;

	// Use this for initialization
	void Start () {
		//シーン中のUnityちゃんオブジェクトを取得
		this.unitychan = GameObject.Find("unitychan");
		//一定の距離ごとにアイテムを生成
		for (int i = startPos; i < firstPos; i+=15) {
			//どのアイテムを出すのかランダムに設定
			int num = Random.Range(0,10);
			if (num <= 1) {
				//コーンをX軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f) {
					GameObject coin = Instantiate (cornPrefab) as GameObject;
					coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i);
				}
			}  else {
				//レーンごとにアイテムを生成
				for (int j = -1; j < 2; j++) {
					//アイテムの種類を決める
					int item = Random.Range(1,11);
					//アイテムを置くZ座標のオフセット
					int offsetZ = Random.Range(-5,6);
					//60%コイン配置：30%車配置：10%何もなし
					if (1 <= item && item <= 6) {
						//コインを生成
						GameObject coin = Instantiate (coinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);
					}  else if (7 <= item && item <= 9) {
						//車を生成
						GameObject car = Instantiate(carPrefab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y, i + offsetZ);
					}
				}
			}
		}
		//アイテム生成したZ座標を格納
		this.Coordinate = this.firstPos;
	}
	
	// Update is called once per frame
	void Update () {
		//Unityちゃんの現在Z座標の取得（Z座標はfloat型の為、intへキャスト）
		this.unitychanZ = (int)this.unitychan.transform.position.z;

		//アイテム生成位置が(goalPos-10)を超えなければ生成を行う
		if (this.Coordinate < this.goalPos-10) {
			//アイテム生成されてからitemInterval分を移動していれば
			if ((this.unitychanZ - this.ItemDistance) > this.itemInterval) {
				//アイテム生成をしたZ座標を取得
				this.Coordinate = this.Coordinate + this.itemInterval;

				//アイテム生成
				NewItemGenerator ((float)this.Coordinate);
				//アイテム生成したUnityちゃんのZ座標を取得
				this.ItemDistance = this.unitychanZ;

			}
		}
	}

	//発展課題用
	void NewItemGenerator(float Z){
		//どのアイテムを出すのかランダムに設定
		int num = Random.Range(0,10);
		if (num <= 1) {
			//コーンをX軸方向に一直線に生成
			for (float j = -1; j <= 1; j += 0.4f) {
				GameObject coin = Instantiate (cornPrefab) as GameObject;
				coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, Z);
			}
		} else {
			//レーンごとにアイテムを生成
			for (int j = -1; j < 2; j++) {
				//アイテムの種類を決める
				int item = Random.Range(1,11);
				//アイテムを置くZ座標のオフセット
				int offsetZ = Random.Range(-5,6);
				//60%コイン配置：30%車配置：10%何もなし
				if (1 <= item && item <= 6) {
					//コインを生成
					GameObject coin = Instantiate (coinPrefab) as GameObject;
					coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, Z + offsetZ);
				} else if (7 <= item && item <= 9) {
					//車を生成
					GameObject car = Instantiate(carPrefab) as GameObject;
					car.transform.position = new Vector3 (posRange * j, car.transform.position.y, Z + offsetZ);
				}
			}
		}
	}

}
