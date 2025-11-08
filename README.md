**How to build**
1. Visual Studioでビルドするため、インストールします。
2. まずはsampleフォルダにあるhiragana.zipとnumber.zipを解凍し、ReadContentsフォルダ直下に置きます。
3. slnファイルからプロジェクトを開いてビルドしてください。
4. ビルドが成功するとReadContents\bin内に実行ファイル(.exe)が生成されます。

**How to Use**
* 任意のフォルダを作り、その中に下記のようなフォルダ階層になるようにファイルを置いてください。
```
.
└── 任意のフォルダ
    ├── bin
    │   ├── Release - 実行ファイル
    │   └── Debug - 実行ファイル
    ├── hiragana
    │   ├── あ.wav
    │   ├── い.wav
    │   ├── う.wav
    │   ├── ...
    │   ├── わ.wav
    │   ├── ん.wav
    │   ├── あ.jpg
    │   ├── い.jpg
    │   ├── う.jpg
    │   └── ...
    └── number
        ├── 0.wav
        ├── 1.wav
        ├── 2.wav
        ├── ...
        ├── 8.wav
        ├── 9.wav
        ├── 0.jpg
        ├── 1.jpg
        ├── 2.jpg
        ├── ...
        ├── 8.jpg
        └── 9.jpg
```

* 上記の要領で任意のjpgファイルを追加できます。
* jpgファイルを追加することで、ボタンをクリックした際にその画像が表示されるようになります。
