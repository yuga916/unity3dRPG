using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour {

	Animator anim;
	// Animator型でanimという変数を定義しています。あとで、「Door」のAnimationコンポーネントを入れる為、Animation型で定義をしています。

	public bool conditionNeedItem = false;
	// 扉によって開く条件を設定

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		// 先程定義した変数animに、GetComponentメソッドで取得したAnimatorコンポーネントを代入しています。
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.name == "Player") {
			if (conditionNeedItem == false) {
				// アイテムを所持しているかチェックしたい扉だけconditionNeedItemにチェックをすれば、扉ごとに開く条件を設定する事ができるようになります。
				anim.SetBool ("IsOpen", true);
			} else {
				if (GameManager.instance.inventory.HasItem ()) {
					anim.SetBool ("IsOpen", true);
				}
			}
		}
	}

	// OnTriggerEnter()メソッドはIsTriggerが設定されているオブジェクトに、他のオブジェクトがぶつかった時に呼ばれるメソッドでしたね。AutoDoor.csはDoorオブジェクトにアタッチをするので、今回のコードは「Doorに付いているColliderにぶつかったら、コンソールビューにぶつかった！と表示させる」スクリプトとなっています。

	// ぶつかってきたオブジェクトがプレイヤーかどうかを判断するスクリプトを書いていきましょう。ぶつかってきたオブジェクトの情報を取得するためには、OnTriggerEnter()メソッドの引数を利用します。OnTriggerEnter()メソッドはCollider型の引数を1つ受け取ります。引数のColliderにはぶつかってきたオブジェクトの情報が入っています。

	void OnTriggerExit(Collider other) {
		if (other.name == "Player") {
			anim.SetBool ("IsOpen", false);
		}
	}
}
