using System;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace ReadContents
{
    public partial class HiraganaWindow : Form
    {
        public HiraganaWindow()
        {
            InitializeComponent();
            createButton();
            initializeWindow();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private CommonConst CONST_NUM = new CommonConst();
        private Button[] buttons;
        private string[] hiragana = new string[] {"あ","い","う","え","お",
                                                  "か","き","く","け","こ",
                                                  "さ","し","す","せ","そ",
                                                  "た","ち","つ","て","と",
                                                  "な","に","ぬ","ね","の",
                                                  "は","ひ","ふ","へ","ほ",
                                                  "ま","み","む","め","も",
                                                  "や","ゆ","よ",
                                                  "ら","り","る","れ","ろ",
                                                  "わ","を","ん"};
        private System.Media.SoundPlayer player = null;

        private void initializeWindow()
        {
            //サイズや配置の初期設定
            int vIndex = CONST_NUM.BTN_HEIGHT + CONST_NUM.BTN_SPACE;
            int hIndex = CONST_NUM.BTN_WIDTH + CONST_NUM.BTN_SPACE;
            this.Height = vIndex * 5 + this.pictBox.Height + CONST_NUM.BTN_SPACE * 6;
            this.Width = hIndex * 10 + CONST_NUM.BTN_SPACE * 4;
            this.pictBox.Location = new Point(hIndex * 4, vIndex * 5 + CONST_NUM.BTN_SPACE);
            this.pictBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void createButton()
        {        
            int vIndex = CONST_NUM.BTN_HEIGHT + CONST_NUM.BTN_SPACE;
            int hIndex = CONST_NUM.BTN_WIDTH + CONST_NUM.BTN_SPACE;

            //50音ボタンの初期化(や行とわ行は3つのため全46文字)
            this.buttons = new Button[46];

            for (int i = 0; i < buttons.Length; i++)
            {
                this.buttons[i] = new Button();

                this.buttons[i].Name = "bt" + i.ToString();
                this.buttons[i].Text = this.hiragana[i];
                this.buttons[i].Height = CONST_NUM.BTN_HEIGHT;
                this.buttons[i].Width = CONST_NUM.BTN_WIDTH;
                this.buttons[i].Font = new Font(this.buttons[i].Font.OriginalFontName, CONST_NUM.TXT_SIZE);

                //50音ボタンの配置
                if (i <= 37)
                {
                    //あ行～や行
                    if (i <= 34)
                    {
                        //あ行～ま行
                        this.buttons[i].Top = CONST_NUM.BTN_SPACE + ((i % 5) * vIndex);
                    }
                    else
                    {
                        //や行
                        this.buttons[i].Top = CONST_NUM.BTN_SPACE + (((i + 1) % 3) * vIndex * 2);
                    }
                    this.buttons[i].Left = (this.Width - (hIndex + CONST_NUM.BTN_SPACE * 2)) - ((i / 5) * hIndex);
                }
                else if (i > 37 && i <= 42)
                {
                    //ら行
                    this.buttons[i].Top = CONST_NUM.BTN_SPACE + (((i - 3) % 5) * vIndex);
                    this.buttons[i].Left = (this.Width - (hIndex + CONST_NUM.BTN_SPACE) * 2) - (((i - 3) / 5) * hIndex);
                }
                else
                {
                    //わ行
                    this.buttons[i].Top = CONST_NUM.BTN_SPACE + (((i + 2) % 3) * vIndex * 2);
                    this.buttons[i].Left = CONST_NUM.BTN_SPACE * 2;
                }

                this.Controls.Add(this.buttons[i]);
                this.buttons[i].Click += new System.EventHandler(btnClick);
            }
        }

        private void btnClick(object sender, System.EventArgs e)
        {
            //引数のボタンオブジェクトをセット
            Button btn = (Button)sender;

            //メディアフォルダを取得
            string currentDirectory = Directory.GetCurrentDirectory();
            string parentDirectory = Path.GetDirectoryName(currentDirectory);
            parentDirectory = Path.GetDirectoryName(parentDirectory);
            string mediaDirectory = Path.Combine(parentDirectory, "hiragana");

            string voiceFileName;
            //音声メディアのパスを取得
            if (btn.Text == "を")
            {
                voiceFileName = "お.wav";
            }
            else
            {
                voiceFileName = btn.Text + ".wav";
            }

            string imageMediaPath = Path.Combine(mediaDirectory, btn.Text + ".jpg");
            setImage(imageMediaPath);

            string voiceMediaPath = Path.Combine(mediaDirectory, voiceFileName);

            player = new System.Media.SoundPlayer(voiceMediaPath);
            if (player != null)
            {
                player.Play();
            }
        }

        private void setImage(string imagePath)
        {
            //画像を読み込んでpictBoxに表示
            try
            {
                if (System.IO.File.Exists(imagePath))
                {
                    //Image.FromFileメソッドを使用
                    this.pictBox.Image = Image.FromFile(imagePath);
                }
                else
                {
                    this.pictBox.Image = null;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("画像の読み込み中にエラーが発生しました: " + ex.Message);
            }
        }
    }
}
