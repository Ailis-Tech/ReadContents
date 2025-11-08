using System;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace ReadContents
{
    public partial class NumberWindow : Form
    {
        public NumberWindow()
        {
            InitializeComponent();
            initializeWindow();
            createButtons();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        CommonConst CONST_NUM = new CommonConst();
        private Button[] buttons;
        private System.Media.SoundPlayer player = null;

        private void initializeWindow()
        {
            //サイズや配置の初期設定
            int vIndex = CONST_NUM.BTN_HEIGHT + CONST_NUM.BTN_SPACE;
            int hIndex = CONST_NUM.BTN_WIDTH + CONST_NUM.BTN_SPACE;
            this.Height = vIndex * 3 + this.pictBox.Height + CONST_NUM.BTN_SPACE * 8;
            this.Width = hIndex * 4 + CONST_NUM.BTN_SPACE * 4;
            this.pictBox.Location = new Point(hIndex - (CONST_NUM.BTN_SPACE * 3), vIndex * 3 + CONST_NUM.BTN_SPACE);
            this.pictBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void createButtons()
        {
            int vIndex = CONST_NUM.BTN_HEIGHT + CONST_NUM.BTN_SPACE;
            int hIndex = CONST_NUM.BTN_WIDTH + CONST_NUM.BTN_SPACE;

            //0～9までの10数の初期化
            this.buttons = new Button[10];

            for (int i = 0; i < buttons.Length; i++)
            {
                this.buttons[i] = new Button();

                this.buttons[i].Name = "bt" + i.ToString();
                this.buttons[i].Text = i.ToString();
                this.buttons[i].Height = CONST_NUM.BTN_HEIGHT;
                this.buttons[i].Width = CONST_NUM.BTN_WIDTH;
                this.buttons[i].Font = new Font(this.buttons[i].Font.OriginalFontName, CONST_NUM.TXT_SIZE);

                //0～9ボタンの配置
                if (i == 0)
                {
                    //0は左上に表示
                    this.buttons[i].Top = CONST_NUM.BTN_SPACE;
                    this.buttons[i].Left = CONST_NUM.BTN_SPACE;
                }
                else
                {
                    //1～9は3×3の9マス表示
                    this.buttons[i].Top = CONST_NUM.BTN_SPACE + (((i - 1) / 3) * vIndex);
                    this.buttons[i].Left = CONST_NUM.BTN_SPACE + hIndex + (((i - 1) % 3) * hIndex);
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
            string mediaDirectory = Path.Combine(parentDirectory, "number");

            //画像メディアを取得
            string imageMediaPath = Path.Combine(mediaDirectory, btn.Text + ".jpg");
            setImage(imageMediaPath);

            //音声メディアのパスを取得
            string voiceFileName = btn.Text + ".wav";
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
