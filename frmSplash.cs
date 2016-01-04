
//===============================================================================
//                                                                              '
//                          SOFTWARE  :  "EHRT"                                 '
//                       Form MODULE  :  frmSplash                              '
//                        VERSION NO  :  1.0                                    '
//                      DEVELOPED BY  :  AdvEnSoft, Inc.                        '
//                     LAST MODIFIED  :  21DEC15                                '
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
    public partial class frmSplash : Form
    {
             
        #region "CONSTRUCTOR:"
        //-------------------

            public frmSplash()
            //================
            {
                InitializeComponent();
            }

        #endregion


        #region "FORM LOAD RELATED ROUTINES:"
        //----------------------------------

            private void frmSplash_Load(object sender, EventArgs e)
            //=====================================================
            {
                //modMain.LoadImageLogo(imgLogo);
                this.WindowState = FormWindowState.Normal;
                this.Refresh();
                System.Threading.Thread.Sleep(2000);
                this.Hide();

                modMain.gfrmMain.ShowDialog();
            }


            private void frmSplash_Activated(object sender, EventArgs e)
            //==========================================================
            {
                //this.WindowState = FormWindowState.Normal;
                //this.Refresh();
                //System.Threading.Thread.Sleep(2000);
                //this.Hide();
                               
                //modMain.gfrmMain.ShowDialog();
               
            }

        #endregion


        #region "CONTROL RELATED ROUTINES:"
        //-------------------------------

            #region "Label."
            //----------------------
                private void lblCancel_Click(object sender, EventArgs e)
                //======================================================
                {
                    System.Environment.Exit(0);
                }

                private void lblCancel_MouseHover(object sender, EventArgs e)
                //===========================================================
                {
                    Label pLabel = (Label)sender;

                    Font pFont = new Font("Calibri", 14, FontStyle.Bold);
                    pLabel.Font = pFont;                    
                }

                private void lblCancel_MouseLeave(object sender, EventArgs e)
                //===========================================================
                {
                    Label pLabel = (Label)sender;
                    Font pFont = new Font("Calibri", 12, FontStyle.Bold);
                    pLabel.Font = pFont;
                }

            #endregion

                

            

        #endregion

           
    }
}

