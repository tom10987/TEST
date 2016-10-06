
## `Source Tree`

[こちら](https://www.sourcetreeapp.com/)
からダウンロード

![top_page][st01]

`Download SourceTree Free` というボタンをクリックするとダウンロードが開始されます。

`Mac OSX` 環境で開発している場合は、すぐ下にある  
`Download SourceTree for Mac OSX` を選択してください。

---
#### インストール手順

ダウンロードしたインストーラーを起動、画面の指示に従って進めてください。

![install][st02]

インストール先を指定します。デフォルトの設定で問題ありません。  
どうしても変更したい場合のみ、各自の環境に合わせて変更してください。

---
#### セットアップ手順

* ステップ１  
![setup01][step01]

**ライセンスに同意します** にチェックを入れて、**続行** を選択します。

* ステップ２  
![setup02][step02]

次の画面で、アカウントの確認を求められます。  
これは、`GitHub` アカウントのことではないので注意してください。

`Use an existing account` をクリックすると、アカウントの入力を求められます。

* ステップ３  
![setup03][st03]

画面下部 `Sign up.` を選択します。

~~~
なお Gmail アカウントを持っていて、それを利用したい場合は、
画面上部から Gmail アカウントの認証に進んでください。

Gmail アカウントを使う場合は、次のステップは省略してください。
~~~

* ステップ４  
![setup04][st04]

上から順に、メールアドレス、アカウント名、パスワードを入力します。

**私はロボットではありません** にチェックを必ず入れてください。

`Sign up` をクリックすると、入力したメールアドレスに認証メールが届くので、  
メールにある認証ボタンをクリックすれば完了です。

~~~
このとき、Web ページが開きますが、そのまま閉じてしまって問題ありません。
~~~

`Source Tree` に戻り、認証を済ませたメールアドレスとパスワードを入力してください。

* ステップ５  
![setup05][step03]

この画面に進んだら登録完了です。**続行** を選択して進みます。

* ステップ６  
![setup06][step04]

ここで `GitHub` アカウントの入力を行います。  
右側の `GitHub` のアイコンをクリックした状態で、アカウント名とパスワードを入力してください。

* ステップ７  
![setup07][step05]

問題なければ、必要な機能の追加インストールが始まります。  
青いバーが右端まで進んだら **続行** が選択できるようになります。

* ステップ８  
![setup08][step06]

次に進むと、このようなウィンドウが表示されるので、**キャンセル** を選択してください。

* ステップ９  
![setup10][step07]

`GitHub` アカウントの入力に問題がなければ、  
あらかじめクローン（コピー）するリポジトリを選択する画面になります。

チーム制作用のリポジトリが作成済みなら、それを選択してください。  
保存先フォルダの設定に注意してください。

ない場合は、**スキップ** を選択します。

* ステップ１０  
![setup11][step08]

**キャンセル** を選択します。

---
![setup12][st05]

これで、インストール完了です。`Source Tree` が起動します。

---
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


* プッシュ

![settings05][set05]

**統合作業の責任者** は、そのまま `origin` を選択してください。

**作業メンバー** は、**自分が作成したリモート名** を選択してください。

チェックボックスにチェックが入っている状態でプッシュしてください。


* プル

![settings06][set06]

メンバー全員が `origin` を選択してプルしてください。

---

[st01]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_top.png
[st02]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_install.png
[st03]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_signup_1.png
[st04]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_signup_2.png
[st05]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_menu.png

[step01]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_setup_1.png
[step02]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_setup_2.png
[step03]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_setup_3.png
[step04]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_setup_4.png
[step05]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_setup_5.png
[step06]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_setup_6.png
[step07]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_setup_7.png
[step08]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_setup_8.png

[set01]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_clone.png
[set02]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_remote_1.png
[set03]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_remote_2.png
[set04]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_remote_3.png
[set05]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_push.png
[set06]: https://github.com/tom10987/TEST/blob/master/ScreenShots/sourcetree_pull.png
