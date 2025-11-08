using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadContents
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        //モーダルで表示
        //※モードレスの場合はvarではなくクラス名で宣言し、.Show()で起動
        private void btHiragana_Click(object sender, EventArgs e)
        {
            var hiraganaWindow = new HiraganaWindow();
            hiraganaWindow .ShowDialog();
            hiraganaWindow.Dispose();
        }

        private void btNumber_Click(object sender, EventArgs e)
        {
            var numberWindow = new NumberWindow();
            numberWindow .ShowDialog();
            numberWindow.Dispose();
        }
    }
}
