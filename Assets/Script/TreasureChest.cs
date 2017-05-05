using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour {

	Animator anim;
	bool isOpen = false;
	//　最初の一回だけ開くようにする処理。

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.name == "Player" && isOpen == false) {
			anim.SetBool ("IsOpen", true);
			GameObject effectObj = Resources.Load<GameObject> ("Effects/ItemEffect");
			// Resources.Loadは、Projectビューにある「Resources」フォルダ内にあるプレハブを呼び出す事ができるとても便利なメソッドです。
			// Resources.Loadメソッドは以下の文法で、プレハブを呼び出すことが可能です。
			// Resources.Load<呼び出すオブジェクトの型>("オブジェクトまでのパス");


			GameObject effect = (GameObject)Instantiate(effectObj, gameObject.transform.position, effectObj.transform.rotation);
			// 行頭の(GameObject)という記述: これは、Instantiateで生成されたオブジェクトの型をGameObject型に変換するという意味です。
			// 以下のように記述する事で、オブジェクトの型を変換する事ができます。
			// (変換したい型)object;
			// Instantiateメソッドは、渡す引数が1つの時はGameObject型に自動で変換されます。しかし、引数が2つ以上ある時は自動で型の変換が行われません。今回取得したオブジェクトを入れる変数はGameObject型なので、GameObject型に型を変換する必要があります。

			// 第一引数: 21行目で取得したプレハブが指定されているので、パーティクルが複製されます。
			// 第二引数: ここで言うgameObjectとは、アタッチされているオブジェクト自身を意味します。
			// 第三引数: 第三引数にはどれだけ回転をするかの情報をセットします。

			effect.transform.parent = gameObject.transform; 
			// Transform.parent: そのオブジェクトの親オブジェクトを取得する事ができます。
			// この時のgameObjectはアタッチされているオブジェクトを指すので、宝箱のオブジェクトであるTreasureChestとなります。
			isOpen = true;

		}
	}
}
