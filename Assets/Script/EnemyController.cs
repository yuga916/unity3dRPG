using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	// プレイヤーから攻撃を受けたら敵が倒れるようにする為に、以下の手順で実装を進めていきます。
	// 1. 予め敵のAnimation情報を取得しておく
	// 2. プレイヤーから攻撃を受けたら、倒れるアニメーションを再生する

	Animation anim;
	BoxCollider boxCollider;
	public int hp = 100;

	public Image hpGauge;
	int fullHp;
	int attackPower;
	GameObject hpObj;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
	
		boxCollider = GetComponent<BoxCollider> ();

		hpObj = transform.Find ("HP").gameObject;
		// Start関数の中でtransform.Find("HP")として、子オブジェクトの「HP」という名前をオブジェクトを探しています。
		// Transform.Findが記述されているスクリプトがアタッチされているオブジェクトの子オブジェクトのみを検索対象として、オブジェクトを検索します。
		// 以前使用したGameObject.FindはHierarhcyビュー上の全てオブジェクトから検索をします。
		// その為、処理としてはTransform.Findの方が軽くなります。


		fullHp = hp;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		// オブジェクト同士の衝突を判定するメソッドでした。引数にはCollider型のotherという名前で、ぶつかってきたオブジェクトの名前を受け取っています。
		if (other.name == "cutter") {
			attackPower = other.GetComponent<Weapon> ().power;
			// other.GetComponent<Weapon> ()で、剣に付いている「Weaponコンポーネント」を取得しています。
			hp -= attackPower;
			hpGauge.fillAmount = (float)hp / fullHp;
			// hpをfloat型に型変化をしている理由
			// 単純にint型同士で計算をしてしまうと小数点以下は切り捨てられる為、今回のように答えが小数点以下になる計算をすると0が返って来ます。
			// その為、50/100の計算結果の0がhpGaugeのfillAmountに代入され、HPゲージが一度で0になってしまいます。

			// そして、今回片方だけをfloat型に型変換しています。
			// これは、異なる型同士で計算をすると、より大きい範囲を表す方の型に自動で型変換される為です。

			if (hp <= 0) {
				anim.Play ("Allosaurus_Die");
				Destroy (boxCollider);
				Destroy (hpObj);
			}
		}
	}
}
