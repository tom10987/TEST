
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
