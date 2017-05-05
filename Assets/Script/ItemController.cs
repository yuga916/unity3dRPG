using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	public Item.ItemType itemType;
	// ここはunumから参照しているだけなので、インスタンス化する必要がない。

	AudioClip getItemSound;
	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		getItemSound = Resources.Load<AudioClip>("Audio/DM-CGS-18");
		audioSource = transform.parent.GetComponent<AudioSource>();
		// 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.name == "Player") {
			audioSource.PlayOneShot(getItemSound);
			// PlayOneShot関数は、引数に渡したAudioClipを再生するメソッドです。何度も呼び出して使う事が出来るため、
			// 効果音の再生によく使われます。

			GameManager.instance.inventory.AddItem (itemType);

			Destroy (gameObject);
			//鍵に触れた瞬間にパーティクルを消すためには以下の方法で実装をします。
			//1. ItemPivotのコライダーに触れたら、ItemPivotの親である宝箱のオブジェクトを取得
			//2. 宝箱の子オブジェクトになっているパーティクルを探す
			//3. 探したパーティクルを削除

			GameObject effectObj = gameObject.transform.parent.Find ("ItemEffect(Clone)").gameObject; 
			// 右辺: 一番始めのgameObjectはアタッチされているオブジェクト自身の事なので、今回の場合ItemPivotを指します。続くtransform.parentでは、ItemPivotの親である宝箱を取得しています。
			// 親オブジェクトを探す為のparentプロパティはTransformクラスのプロパティである為、transformにアクセスする必要があります。以上から、gameObject.transform.parentで宝箱オブジェクトを取得している事が分かりますね。
			// 宝箱オブジェクトに対して.Find ("ItemEffect(Clone)").gameObject;として自身のオブジェクト内にあるItemEffect(Clone)つまりパーティクルを取得している事が分かります。
			Destroy (effectObj);
		}
	}
}
