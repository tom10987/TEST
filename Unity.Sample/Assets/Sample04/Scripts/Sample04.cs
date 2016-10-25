
using UnityEngine;
using System.Collections;

public class Sample04 : MonoBehaviour
{
  [SerializeField]
  Camera _camera = null;

  // これはプレハブ
  // _prefab.attack のような使い方はできません。
  [SerializeField]
  EnemyObject _prefab = null;


  IEnumerator Start()
  {
    RaycastHit hit;

    while (isActiveAndEnabled)
    {
      // 左クリックしたら、敵キャラクター出現
      if (Input.GetMouseButtonDown(0))
      {
        // マウス位置からゲーム空間の座標を計算
        var position = GetScreenPositionRelative();
        position *= _camera.orthographicSize;

        // 計算済みの座標に敵キャラクターを生成
        var enemy = Instantiate(_prefab);
        enemy.transform.position = position;
        enemy.transform.rotation = Random.rotation;
      }

      // 右クリックしたら、敵キャラクター消去
      if (Input.GetMouseButtonDown(1))
      {
        // レイが敵キャラクターに当たったら、そのキャラクターを削除
        if (TouchController.RaycastHit(_camera, out hit))
        {
          DestroyImmediate(hit.transform.gameObject);

          // Find とかしてなくても敵の数が確認できる！
          int count = EnemyObject.enemies.Count;

          Debug.Log("残っている敵の数: " + count);
        }
      }

      // キーボードの A が押されたら、適当なキャラクターのパラメータを表示
      if (Input.GetKeyDown(KeyCode.A))
      {
        int max = EnemyObject.enemies.Count;

        if (max > 0)
        {
          int index = Random.Range(0, max - 1);

          var enemy = EnemyObject.enemies[index];
          Debug.Log(enemy.gameObject.name + " attack: " + enemy.attack);
        }
      }

      yield return null;
    }
  }


  Vector3 screenSize { get { return new Vector3(Screen.width, Screen.height); } }

  Vector3 center { get { return screenSize * 0.5f; } }

  // 画面中央を基準にした、スクリーンの相対座標を取得
  Vector3 GetScreenPositionRelative()
  {
    // 画面中央が基準のマウス座標を取得
    var position = Input.mousePosition - center;

    // マウス座標を相対座標に変換する
    var relative = Vector3.zero;
    relative.x = (position.x / center.x) * _camera.aspect;
    relative.y = (position.y / center.y);

    return relative;
  }
}
