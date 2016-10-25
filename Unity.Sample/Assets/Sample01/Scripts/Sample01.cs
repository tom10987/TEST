
//------------------------------------------------------------
// TIPS:
// ScriptableObject クラスを使った、
// オリジナルアセットのサンプルです。
//
// Unity 以外では編集できませんが、
// その代わり、ビルドした後に必要なデータを入れなおすといった、
// 余計な手間が発生しません。
//
//------------------------------------------------------------

using UnityEngine;

public class Sample01 : MonoBehaviour
{
  // インスペクターに表示可能
  [SerializeField]
  OriginalAsset _origin = null;

  void Start()
  {
    // プロパティなどが用意されていれば、値を取り出せる
    Debug.Log(_origin.intValue);
    Debug.Log(_origin.floatValue);
    Debug.Log(_origin.GetString());
  }
}
