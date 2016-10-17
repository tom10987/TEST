
//------------------------------------------------------------
// TIPS:
// オリジナルのクラスをインスペクターに表示するサンプルです。
//
// コンポーネントとして GameObject に登録することはできません。
//
// [System.Serializable] をクラスの上につけてください。
//
//------------------------------------------------------------

using UnityEngine;

// インスペクターに表示できるクラス
[System.Serializable]
public class OriginalClassA
{
  [SerializeField]
  int _intA = 0;

  // SerializeField がないと表示できない
  int _intB = 0;

  // public なら表示できる
  public int _intC = 0;


  public int intA { get { return _intA; } }
  public int intB { get { return _intB; } }
  public int intC { get { return _intC; } }
}


// インスペクターに表示できないクラス
public class OriginalClassB
{
  // 表示できないので意味がない
  [SerializeField]
  float _floatA = 0f;

  // 同上
  public float _floatB = 0f;


  // コンストラクタがあれば、初期化は可能
  public OriginalClassB()
  {
    _floatA = 1f;
    _floatB = 2f;
  }


  public float floatA { get { return _floatA; } }
  public float floatB { get { return _floatB; } }
}
