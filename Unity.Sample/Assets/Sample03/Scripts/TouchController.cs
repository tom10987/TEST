
//------------------------------------------------------------
// TIPS:
// タッチとマウスの判定を実行環境に合わせて切り替えます。
//
// コンポーネントである必要はないので、MonoBehaviour を継承しません。
// また、インスタンス化する必要もないので、静的クラスとして定義します。
//
// なお、タッチ判定はシングルタッチのみ対応しています。
// 複数の指を使ったタッチ（マルチタッチ）には対応していません。
//
// ダブルタップ判定は用意していませんが、
// Input.touches から、タッチ時間を取得するプロパティがあるので、
// そちらを活用してください。
//
//------------------------------------------------------------

using UnityEngine;

public static class TouchController
{
  /// <summary> 実行環境が Android なら true を返す </summary>
  public static bool isAndroid
  {
    get { return Application.platform == RuntimePlatform.Android; }
  }

  /// <summary> 実行環境が iOS なら true を返す </summary>
  public static bool isIPhone
  {
    get { return Application.platform == RuntimePlatform.IPhonePlayer; }
  }

  /// <summary> 実行環境がスマートフォンなら true を返す </summary>
  public static bool isSmartDevice
  {
    get { return isAndroid || isIPhone; }
  }


  /// <summary> 画面サイズを返す </summary>
  public static Vector2 screenSize
  {
    get { return new Vector2(Screen.width, Screen.height); }
  }

  /// <summary> 画面サイズを基準にした、画面中央の座標を返す </summary>
  public static Vector3 center { get { return screenSize * 0.5f; } }

  /// <summary> 画面サイズを基準にした、縦横の比率を返す </summary>
  public static float aspect { get { return (float)Screen.width / Screen.height; } }


  /// <summary> タッチされたときのスクリーン座標を返す：左下 (0, 0) </summary>
  public static Vector3 GetScreenPosition()
  {
    // Vector3 として扱うのは、オブジェクトの transform.position が Vector3 のため
    var touch = Vector3.zero;

#if UNITY_STANDALONE
    // スマートフォンでなければ、マウス座標を代わりに返す
    touch = Input.mousePosition;
#else
    // タッチされていれば、スクリーンの座標を返す
    if (Input.touchCount > 0) { touch = Input.touches[0].position; }
#endif

    return touch;
  }

  /// <summary> 画面中央を基準にした、スクリーン座標を返す </summary>
  public static Vector3 GetScreenPositionFromCenter()
  {
    // スクリーン座標を画面サイズの半分だけずらす
    return GetScreenPosition() - center;
  }


  /// <summary> 画面中央を基準にした、スクリーンの相対座標を返す : [-1, 1] </summary>
  public static Vector3 GetScreenPositionRelative()
  {
    var touch = GetScreenPositionFromCenter();

    // スクリーン座標を変換する
    var relative = Vector3.zero;
    relative.x = (touch.x / center.x);
    relative.y = (touch.y / center.y);

    return relative;
  }

  /// <summary> アスペクト比を考慮した、スクリーンの相対座標を返す </summary>
  public static Vector3 GetScreenPositionByAspect()
  {
    var relative = GetScreenPositionRelative();

    // X 成分のみアスペクト比を反映
    // Camera コンポーネントから取り出せるアスペクト比も X 成分を基準にしているため
    relative.x *= aspect;

    return relative;
  }


  /// <summary> スクリーン座標からのレイキャスト判定を行う </summary>
  public static bool RaycastHit(Camera camera, out RaycastHit hit)
  {
    // 全てのレイヤーに反応するインデックスを渡す
    return RaycastHitByLayer(camera, out hit, ~0);

    // Unity のレイヤーは、int 型サイズのビットフラグで管理されている

    // ところが、gameObject.layer で返されるのは、
    // enum のように順番を並べ替えたようなインデックスが返される

    // gameObject.layer から取り出した場合、
    // 1 << gameObject.layer のように、シフト演算が必要になる場合があるので注意
  }

  /// <summary> レイキャスト判定とタグの判定を同時に行う </summary>
  public static bool RaycastHitByTag(Camera camera,
                                     out RaycastHit hit,
                                     string tag)
  {
    // 判定の結果を取得、レイがオブジェクトに当たっていれば、タグの比較を行う
    var isHit = RaycastHit(camera, out hit);
    return isHit ? (hit.transform.tag == tag) : false;
  }

  /// <summary> レイキャスト判定とレイヤーの判定を同時に行う </summary>
  public static bool RaycastHitByLayer(Camera camera,
                                       out RaycastHit hit,
                                       int layerMask)
  {
    // スクリーン座標をカメラに与えて、カメラからのレイを取得
    // 指定したレイヤーのオブジェクトとレイキャスト判定を行う
    var ray = camera.ScreenPointToRay(GetScreenPosition());
    return Physics.Raycast(ray, out hit, camera.farClipPlane, layerMask);
  }


  // タッチが指定された状態に一致するなら true を返す
  static bool GetTouchState(TouchPhase state)
  {
    return Input.touchCount > 0 ?
      Input.touches[0].phase == state : false;
  }

  /// <summary> タッチされたら true を返す </summary>
  public static bool IsTouchBegan()
  {
    bool result = false;

#if UNITY_STANDALONE
    // Unity エディター、または Windows、MacOSX 向けビルドの場合の判定
    // マウスの左クリックを判定基準にする
    result = Input.GetMouseButtonDown(0);
#else
    // タッチされていれば、その状態を調べる
    result = GetTouchState(TouchPhase.Began);
#endif

    return result;
  }

  /// <summary> タッチされ続けている間 true を返す </summary>
  public static bool IsTouchMoved()
  {
    bool result = false;

#if UNITY_STANDALONE
    result = Input.GetMouseButton(0);
#else
    // タッチされていれば、その状態を調べる
    if (Input.touchCount > 0)
    {
      var touch = Input.touches[0];

      // 動いていないがタッチされ続けている場合もあるので、それも考慮する
      bool isMove = (touch.phase == TouchPhase.Moved);
      bool isWait = (touch.phase == TouchPhase.Stationary);

      result = isMove || isWait;
    }
#endif

    return result;
  }

  /// <summary> タッチが離されたら true を返す </summary>
  public static bool IsTouchEnded()
  {
    bool result = false;

#if UNITY_STANDALONE
    result = Input.GetMouseButtonUp(0);
#else
    result = GetTouchState(TouchPhase.Ended);
#endif

    return result;
  }


  /// <summary> 端末の戻るボタンが押されたら true を返す </summary>
  public static bool IsPushedQuitKey()
  {
    // KeyCode.Escape は、スマートフォンの戻るボタンに対応している
    return Input.GetKeyDown(KeyCode.Escape);
  }
}
