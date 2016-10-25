
//------------------------------------------------------------
// TIPS:
// 自作クラスでもインスペクターに表示できるようにするサンプルです。
//
// インスペクターに表示できるようになりますが、
// コンポーネントとしてアタッチできるわけではないので注意してください。
//
//------------------------------------------------------------

using UnityEngine;

public class Sample02 : MonoBehaviour
{
  [SerializeField]
  OriginalClassA _classA = null;

  [SerializeField]
  OriginalClassB _classB = null;


  // Start() よりも先に実行
  void Awake()
  {
    if (_classB == null) { _classB = new OriginalClassB(); }
  }

  void Start()
  {
    // インスペクターに表示できるクラスの内容を表示
    Debug.Log("classA.intA = " + _classA.intA);
    Debug.Log("classA.intC = " + _classA._intC);

    // インスペクターに表示できないクラスの内容を表示
    Debug.Log("classB.floatA = " + _classB.floatA);
    Debug.Log("classB.floatB = " + _classB._floatB);
  }
}
