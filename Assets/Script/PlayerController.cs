using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Animator anim;


	//攻撃をしていないのに当たり判定がある事は不自然です。
	//解決方法はいくつかありますが、今回は「攻撃をしている時だけ、剣のSphere Colliderを有効にする」事で解決をします。
	GameObject sword;
	// 後に、プレイヤーの剣のオブジェクトを入れる為、GameObject型でswordという変数を定義しています。
	SphereCollider swordCollider;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		sword = GameObject.Find ("cutter");
		// Findメソッドで「cutter01」つまり剣のオブジェクトを取得して、8行目で定義したsword変数に入れています。
		swordCollider = sword.GetComponent<SphereCollider> ();
		// sword変数には剣のオブジェクトが入っています。それに対して、GetComponent<SphereCollider>()で剣についているSphereColliderコンポーネントを取得しています。

		IsAttackingToFalse ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Invoke ("IsAttackingToTrue", 0.5f);
			anim.SetTrigger ("Attack");

			Invoke ("IsAttackingToFalse", 0.8f);
			// Invoke: 第一引数で指定したメソッドを、第二引数で指定した秒数後に実行させるメソッドです。

		}
	}

		// InputManagerでは、キーボードのキーやマウスのボタンに名前を付ける事ができます。分かりやすい名前を付けることで、ゲームを作りやすくしています。例えば今回はキーボードのキーに「Fire1」という名前を付けています。Fireというのはゲームにおいて「攻撃」という意味があります。
		// SetTriggerメソッドは、以下のように記述することでAnimatorに設定されているTriggerをONにする事ができます。

		// 次は、実際に攻撃が敵に当たった時に、敵が倒れるという所までを作っていきます。
		// 以下の手順で作成していきます。
		// 1. 剣に衝突判定用のSphere Colliderを付ける
		// 2. 敵に衝突判定用のBox Colliderを付ける
		// 3. スクリプトで衝突した時の処理を書く

	void IsAttackingToFalse () {
			swordCollider.enabled = false;
	}
		// この行では新しくIsAttackingToFalseというメソッドを定義しています。
		// 中では、swordCollider.enabled = false;で剣のSphere Colliderを非アクティブにしています。
		// ここから、この「剣のSphere Colliderを非アクティブにする」という事を複数回行うため、メソッドにまとめて何度でも呼び出せるようにしています。

	void IsAttackingToTrue() {
		swordCollider.enabled = true;
	}

}
