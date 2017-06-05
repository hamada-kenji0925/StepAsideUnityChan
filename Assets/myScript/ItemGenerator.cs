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
	private float unitychanZ;
	//自動生成する範囲
	private int AutoGeneRange = 50;
	//自動生成する範囲のUnityちゃん座標
	private float unitychanZ_autoGene;

	// Use this for initialization
	void Start () {
		//シーン中のUnityちゃんオブジェクトを取得
		this.unitychan = GameObject.Find("unitychan");
		//一定の距離ごとにアイテムを生成
		for (int i = startPos; i < goalPos; i+=15) {
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
	}
	
	// Update is called once per frame
	void Update () {
		//Unityちゃんの現在Z座標の取得
		this.unitychanZ = this.unitychan.transform.position.z;
		//Unityちゃんの自動生成範囲座標の計算
		this.unitychanZ_autoGene = this.unitychanZ + this.AutoGeneRange;

		//初期値：UnityちゃんZ座標、条件：UnityちゃんZ座標が50m以内の場合に処理実行、更新：15m間隔で処理実行
		for (float i = this.unitychanZ; i < this.unitychanZ_autoGene; i += 15) {
			//NewItemGenerator (i);
		}
	}

	//発展課題用（未完成）
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
