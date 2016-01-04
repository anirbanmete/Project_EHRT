//===============================================================================
//                                                                              '
//                          SOFTWARE  :  "EHRT"                                 '
//                       CODE MODULE  :  modMain                                '
//                        VERSION NO  :  1.0                                    '
//                      DEVELOPED BY  :  AdvEnSoft, Inc.                        '
//                     LAST MODIFIED  :  22DEC15                                '
//                                                                              '
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace EHRT
{
    static class modMain
    {
        #region  "NAMED CONSTANTS:"
        //-------------------------

            public const string gcProgrameName = "EHRT10";
            public const double gcEPS = 0.0001F;     //....An arbitrary small no.   

        #endregion


        #region "STRUCTURE DEFINITIONS:"
        //=============================

            public struct myPoint           
            {
                public double X;
                public double Y;
                public myPoint(double a, double b)         
                {
                    X = a;
                    Y = b;
                }
            }

        #endregion


        #region "GLOBAL CLASS OBJECTS:"
        //----------------------------     

            public static clsFiles gFiles = new clsFiles();
            public static clsPart gPart = new clsPart();
            public static clsEHRT gEHRTBender = new clsEHRT();

        #endregion


        #region "GLOBAL FORM  OBJECTS:"
        //----------------------------           
                public static frmSplash gfrmSplash = new frmSplash();
                public static frmMain gfrmMain = new frmMain();
                public static frmAbout gfrmAbout = new frmAbout();

                //public static frmDWGConverter gfrmDWGConverter = new frmDWGConverter();
            //public static frmMain gfrmMain = new frmMain();
            //public static frmPathsSelection gfrmPathsSelection = new frmPathsSelection();
            //public static frmAbout gfrmAbout = new frmAbout();
            //public static frmStatus gfrmStatus = new frmStatus();

        #endregion


        #region  "GLOBAl CONTROLLER OBJECTS:"
        //===================================

                //public static clsController_frmCADSelection gController_frmCADSelection =
                //                                            new clsController_frmCADSelection(gfrmCADSelection, gFiles.CADSystem);

                //public static clsController_frmPathsSelection gController_frmPathsSelection =
                //                                                new clsController_frmPathsSelection(gfrmPathsSelection, gFiles);
                //public static clsController_frmMain gController_frmMain = new clsController_frmMain(gfrmMain, gFiles);

        #endregion


        #region "MEMBER VARIABLES"
        //========================
                public static bool gAutoMode = false;
                public static bool gSilentMode = false;

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new frmSplash());
        }

        #region "STRING EXTRACTION ROUTINES:"
        //----------------------------------

            public static string ExtractPreData(string anyString, string searchString)
            //========================================================================
            {
                string anyStr = "";

                int iPos = 0;
                iPos = (anyString.IndexOf(searchString, 0) + 1);

                if (iPos > 0)
                    anyStr = anyString.Substring(0, iPos - 1).Trim(' ');

                return anyStr;
            }


            public static string ExtractPostData(string anyString, string searchString)
            //========================================================================
            {
                string anyStr = "";

                int iPos = 0;
                iPos = (anyString.IndexOf(searchString, 0) + 1);

                if (iPos > 0)
                    //anyStr = anyString.Substring(iPos + 1).Trim(' ');
                    anyStr = anyString.Substring(iPos).Trim(' ');
                return anyStr;
            }


            public static string ExtractMidData(string anyString, string searchStringStart,
                                                                  string searchStringEnd)
            //===========================================================================
            {
                string anyStr = "";
                int iPosS = 0, iPosE = 0;

                iPosS = (anyString.IndexOf(searchStringStart, 0) + 1);

                if (iPosS > 0)
                {
                    iPosE = anyString.IndexOf(searchStringEnd, iPosS);
                    anyStr = anyString.Substring(iPosS, iPosE - iPosS);
                }

                return anyStr;
            }


            public static string CheckSplChar(string anyString)
            //=================================================
            {
                string panyStr = "";

                if (anyString.Contains("\""))
                    panyStr = anyString.Replace("\"", " ");

                else
                    panyStr = anyString;

                return panyStr;
            }


            public static Boolean NumericDataValidation(string Value_In)
            //==================================================== 
            {
                bool val = System.Text.RegularExpressions.Regex.IsMatch(Value_In, @"^[-+]?[0-9]*\.?[0-9]+$");

                return val;
            }

        #endregion
    }
}
