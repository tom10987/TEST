
## `GitHub` での操作

---
#### `GitHub` にリポジトリを作成

※ ここから先の手順は **統合作業の責任者** と **作業を進めるメンバー** で手順が異なります。

* 統合先のリポジトリを作成：**統合作業の責任者**

![github01][gh01]

ログインできていれば、アイコンから自分のページを開くことができます。

![github02][gh02]

自分のアカウントにて、チーム制作のリポジトリを作成するために、リポジトリの一覧を表示します。

![github03][gh03]

`New` ボタンを選択して、リポジトリを作成してください。

リポジトリが作成されたことを確認できたら完了です。  
他のメンバーに連絡して、下記の手順を進めてください。


* リポジトリをフォークする：**作業メンバー**

**統合作業の責任者** のページから、チーム制作のリポジトリを開いてください。

![github04][gh04]

画面右上にある `Fork` ボタンを選択すれば、自分のアカウントにリポジトリのコピーが始まります。

自分のページが表示されれば、フォーク作業の完了です。


---
## `Source Tree` での準備

#### `GitHub` のリポジトリとリンクさせる

※ ここから先の手順は **統合作業の責任者** と **作業を進めるメンバー** で手順が少し変わります。


* クローン  
※ 上記セットアップにてクローン済みなら、このステップは省略してください。

~~~
クローンとは、サーバー上にあるリポジトリを PC にコピーすることを言います。  
ついでに、そのサーバーのリポジトリとのリンクも行います。
~~~

![settings00][st05]

左上にある **新規/クローンの作成** を選択してください。


![settings01][set01]

**統合作業の責任者** が作成したリポジトリの `URL` を入力します。  
このとき、`URL` の末尾に必ず `.git` と入力してください。

クローン先のフォルダを指定します。  
アドレス欄の右側にあるボタンから直接フォルダを選択できます。

~~~
デスクトップを指定する場合、
そのままだとデスクトップ上にある内容全てが管理対象に含まれるので、注意してください。

その場合は、デスクトップ上に空フォルダを作成、そのフォルダを指定してください。
~~~


* リモート  
※ **統合作業の責任者** は、この手順をスキップしてください。

~~~
リモートとは、どのサーバーの、どのリポジトリに対してリンクしているかの設定をいいます。
~~~

![settings02][set02]

初期状態だと、このような画面になっていると思います。

ここに自分のリポジトリを追加したいので、**追加** を選択してください。

![settings03][set03]

追加したいリモートの名前とリポジトリのアドレスを入力します。  
ここでも、`URL` の末尾に `.git` を必ず入力してください。

~~~
リモート名は自由に設定して大丈夫です。
~~~

![settings04][set04]

このようになっていれば完了です。**OK** を選択してください。


---
## PC での操作

---
#### リポジトリの更新手順

* プッシュ

![settings05][set05]

**統合作業の責任者** は、そのまま `origin` を選択してください。

**作業メンバー** は、**自分が作成したリモート名** を選択してください。

チェックボックスにチェックが入っている状態でプッシュしてください。


* プル

![settings06][set06]

メンバー全員が `origin` を選択してプルしてください。


---

[gh01]: https://github.com/tom10987/TEST/blob/master/ScreenShots/github_account.png
[gh02]: https://github.com/tom10987/TEST/blob/master/ScreenShots/github_top.png
[gh03]: https://github.com/tom10987/TEST/blob/master/ScreenShots/github_create_repo.png
[gh04]: https://github.com/tom10987/TEST/blob/master/ScreenShots/github_fork.png

[set01]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_clone.png
[set02]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_remote_1.png
[set03]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_remote_2.png
[set04]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_remote_3.png
[set05]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_push.png
[set06]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_pull.png
