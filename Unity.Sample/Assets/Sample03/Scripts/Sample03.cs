
//------------------------------------------------------------
// TIPS:
// タッチとマウスの操作を１つのメソッド呼び出しで、
// ほぼ同じ挙動として扱えるようにしたサンプルです。
//
// ビルドした際に、どのプラットフォームかで処理が切り替わります。
//
//------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class Sample03 : MonoBehaviour
{
  [SerializeField]
  Camera _camera = null;

  [SerializeField]
  Color _hit = Color.red;


  Transform _target = null;

  IEnumerator Start()
  {
    while (isActiveAndEnabled)
    {
      yield return StartCoroutine(CheckRaycast());
      yield return StartCoroutine(WaitTouchEnded());
    }
  }


  // *** レイキャスト判定の注意点 ***
  // レイキャスト判定したいオブジェクトに、
  // コライダー系コンポーネント (BoxCollider など) がないと全く反応しません

  // レイキャスト判定
  IEnumerator CheckRaycast()
  {
    RaycastHit hit;

    // レイキャストが成功するまで何もしない
    while (true)
    {
      yield return null;

      // タッチされてなければ何もしない
      if (!TouchController.IsTouchBegan()) { continue; }

      // レイがオブジェクトに当たっていたらループを抜ける
      if (TouchController.RaycastHit(_camera, out hit)) { break; }
    }

    // レイキャストで取得したオブジェクトの座標系を取得
    _target = hit.transform;

    // 色の変更を試みる
    var renderer = hit.transform.GetComponent<Renderer>();
    if (renderer) { renderer.material.color = _hit; }
  }

  // タッチ終了の待機
  IEnumerator WaitTouchEnded()
  {
    // タッチ終了まで何もしない
    while (!TouchController.IsTouchEnded()) { yield return null; }

    // 色を戻す
    var renderer = _target.GetComponent<Renderer>();
    if (renderer) { renderer.material.color = Color.white; }

    // オブジェクトを解放
    _target = null;
  }
}
