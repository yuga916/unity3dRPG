using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	List<int> itemList = new List<int>();
	// アイテムは複数取得される事が前提なので、複数の情報を保存できるようにする必要があります。複数の情報を保存するにはListと呼ばれる物を使用します。
	// Listの基本文法は以下のように記述します。
	// using System.Collections.Generic;
	// List<型> 変数名 = new List<型>();

	public void AddItem(Item.ItemType type) {
		print((int)type);
		itemList.Add ((int)type);
		// 今回はアイテムのID 番号が必要ですね。そのような時はこれまでの型変換と同様に要素の前に型を宣言する事で取得することができます。
	}

	public bool HasItem() {
		if (itemList.Count >= 1) {
			return true;
		} else {
			return false;
		}
	}
	// 扉が開く条件のスクリプトを書いていきましょう。
	// 以下の手順で実装を進めていきます。

	//1. アイテムを持っているかどうかをチェックするメソッドを作成する
	//2. 扉にぶつかったタイミングで、1で作ったメソッドを呼び出すようにする


}
