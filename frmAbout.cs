
//===============================================================================
//                                                                              '
//                          SOFTWARE  :  "EHRT"                                 '
//                       Form MODULE  :  frmAbout                               '
//                        VERSION NO  :  1.0                                    '
//                      DEVELOPED BY  :  AdvEnSoft, Inc.                        '
//                     LAST MODIFIED  :  22DEC15                                '
//                                                                              '
//===============================================================================


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EHRT
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //lblRelDate.Text = modMain.gfrmSplash.lblRelDate.Text.ToUpper();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

