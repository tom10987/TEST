
//------------------------------------------------------------
// TIPS:
// オリジナルのアセットを表現するスクリプトです。
//
// そのままではファイルを作成できないため、
// ファイルを作成する命令を追加する必要があります。
//
// また、ファイルの拡張子を必ず .asset にしてください。
// それ以外の拡張子では Unity が認識できません。
//
//------------------------------------------------------------

using UnityEngine;

public class OriginalAsset : ScriptableObject
{

  // Unity エディターに機能を追加する場合、必ず #if ~ #endif で囲みます
#if UNITY_EDITOR

  static readonly string fileName = "original.asset";

  // アセット作成の命令をエディターに追加
  [UnityEditor.MenuItem("Custom Assets/Create Original Asset")]
  static void CreateAsset()
  {
    // OriginalAsset 型のファイルをプロジェクトフォルダに作成する
    var asset = CreateInstance<OriginalAsset>();
    UnityEditor.ProjectWindowUtil.CreateAsset(asset, fileName);
  }

#endif


  // Header について
  // インスペクターを確認してください
  [Header("ここの文字列をインスペクターに表示します")]
  [SerializeField]
  int _intValue = 0;

  public int intValue { get { return _intValue; } }


  // Range(x, y) について
  // x, y の範囲に収まるスライダーをインスペクターに表示
  [SerializeField, Range(0f, 1f)]
  float _floatValue = 0.5f;

  public float floatValue { get { return _floatValue; } }


  // TextArea について
  // 文字列の入力エリアを大きく広げます
  [SerializeField, TextArea]
  string _stringValue = string.Empty;

  public string GetString() { return _stringValue; }
}
