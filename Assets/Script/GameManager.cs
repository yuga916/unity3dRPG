using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// シングルトン: あるクラスから生成されたインスタンスが絶対に1つである事を保証するような設計です。つまり1回インスタンスを生成するだけで、そのインスタンスを様々な場所で使い回す事ができるようにします。そうすることで、仮に複数インスタンスを作成したとしても、必ず最初のインスタンスを参照するようになります。
	// GameManager(このスクリプト)はゲーム開始と同時に読み込みをさせたいので、Hierarchyビューに配置する必要があります。
	// スクリプトを直接Hierarchyビューに置くことはできないので、何かのオブジェクトにアタッチする必要があります。このような時はHierarchyビューに空のオブジェクトを作成して、スクリプトをアタッチする事が一般的です。

	// シングルトンを実装するには以下の手順で行います。
	// 1. GameManager自身のインスタンスを生成
	// 2. 生成したインスタンスをどこからでもアクセスできる共通のインスタンスにする

	public static GameManager instance;
	// GameManager型のinstanceという変数を定義しています。この変数には、GameManager自身のインスタンスを代入する為、GameManager型で定義をしています。シングルトンなインスタンスを生成する時は、staticな変数として定義をします。
	// static: 共通化

	public Inventory inventory;
	// 


	// Use this for initialization
	void Start () {
		if (instance == null) {
			// instanceはDontDestroyOnLoadで破棄しないように指定しているので、instanceの中にはシーン移動前に生成したGameManagerクラスのインスタンスが入っています。
			// これで、何度呼ばれても一番最初に生成したインスタンスを参照するよう になります 。
			instance = this;
			// thisとはそのクラスのインスタンスの事を指します。今回はGameManagerクラスでthisという記述をしているのでnew GameManager()と同じ意味になります。
		}

		DontDestroyOnLoad (this);
		// DontDestroyOnLoadの引数に渡したオブジェクトは、シーンが変わってもオブジェクトが破棄されません。本来は、シーンが変わるとオブジェクトも全て破棄されます。ですので、シーンが変わっても共通のインスタンスを参照したい場合には、「DontDestroyOnLoad」を使用します。
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
