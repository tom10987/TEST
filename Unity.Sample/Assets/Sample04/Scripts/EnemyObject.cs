
//------------------------------------------------------------
// TIPS:
// ゲームシーンに出現する敵キャラクターを表現するスクリプトです。
//
// GameObject.Find() など、Find 系のメソッドは処理が重いです。
//
// オブジェクトの数が少ないゲームであれば、問題になりにくいですが、
// 数が大量に発生する場合、ゲームの快適さに深刻な影響を及ぼします。
//
// そのため、可能な限り Find 系の処理を使わずにアクセスするのが
// 望ましいです。
//
// 下記はその一例です。
//
// 全ての場合において最適解とはならないので、
// 自分の作る作品に最適な方法を選んでください。
//
//------------------------------------------------------------

using UnityEngine;
using System.Collections.Generic;

public class EnemyObject : MonoBehaviour
{
  static readonly List<EnemyObject> _enemies = new List<EnemyObject>();

  /// <summary> シーンに存在する全ての敵キャラクター </summary>
  public static List<EnemyObject> enemies { get { return _enemies; } }


  /// <summary> 敵キャラクターの攻撃力 </summary>
  public int attack { get; private set; }


  // オブジェクトが有効になったときに、自分自身をリストに登録する
  void Awake()
  {
    attack = Random.Range(0, 100);

    Debug.Log("エネミー君、期待を胸に堂々の登場");
    _enemies.Add(this);

    // 問題点
    // Instantiate() で生成された場合、その直後には Awake() が呼ばれません。
    //
    // 呼ばれたタイミングでのゲームループが終わって、
    // その次の新しいループに入ってから Awake() が呼ばれます。
    //
    // どうしても生成された直後に初期化などを行いたい場合、
    // 専用に public なメソッドを用意して呼び出す必要があります。
  }

  // オブジェクトが削除されたときに、リストから自分自身を削除する
  void OnDestroy()
  {
    Debug.Log("エネミー君、無念のリタイア");
    _enemies.Remove(this);
  }
}
