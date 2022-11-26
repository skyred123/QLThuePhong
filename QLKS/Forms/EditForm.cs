using QLKS.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS.Forms
{
    public partial class EditForm : Form
    {
        public int EditNV = 1;
        public int CreateNV = 2;
        public EditForm()
        {
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            UserControl_ChinhSuaTT _ChinhSuaTT = new UserControl_ChinhSuaTT();
            this.Controls.Add(_ChinhSuaTT);
            _ChinhSuaTT.Dock = DockStyle.Fill;
        }
    }
}
