//===============================================================================
//                                                                              '
//                          SOFTWARE  :  "EHRT"                                 '
//                       CODE MODULE  :  clsFiles                               '
//                        VERSION NO  :  1.0                                    '
//                      DEVELOPED BY  :  AdvEnSoft, Inc.                        '
//                     LAST MODIFIED  :  21DEC15                                '
//                                                                              '
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace EHRT
{
    class clsFiles
    {
        #region "MEMBER VARIABLE DECLARATIONS:"
        //====================================

            private const double mcEPS = 0.0001F;     //....An arbitrary small no.   

            //....Root Drive
            private const string mcDriveRoot = "C:";

            //....Root Directory:
            //....For Otimation:  
            private const string mcDirRoot = mcDriveRoot + "\\Optimation\\EHRT Bender\\";

            //....User Root Directory.
            private const string mcDirRootUser = mcDirRoot + "Input Files\\";

            ////....User Source Files Root Directory.
            //private const string mcDirSourceFiles = mcDirRoot + "DIN Files\\";

            ////....User Processed Files Root Directory.
            //private const string mcDirProcessedFiles = mcDirRoot + "Processed Files\\";

            // private string mSourcePath = "";

            private string mConfigFileTitle = "";

            //....Part Info. File Path.                        
            private string mFilePath_Part_Info;

            //....Source Folder.                        
            private string mFilePath_Source_Folder;

            //....Export Package Folder.                
            private string mFilePath_Export_Folder;

            //....Ini File Name
            private string mIniFileName = mcDirRoot + "EHRTBender10.ini";

        #endregion


        #region"READ-ONLY PROPERTIES:"
        //===========================

            public string DirRoot
            //===================
            {
                get { return mcDirRoot; }
            }

            public string DirIn
            //=================
            {
                get { return mcDirRootUser; }
            }

        #endregion


        #region "READ & WRITE PROPERTIES:
        //===============================

            public string ConfigFileTitle
            //===========================
            {
                get { return mConfigFileTitle; }
                set { mConfigFileTitle = value; }
            }
                    
            public string FilePath_Source_Folder
            //==================================
            {
                get { return mFilePath_Source_Folder; }
                set { mFilePath_Source_Folder = value; }
            }

            public string FilePath_Export_Folder
            //==================================
            {
                get { return mFilePath_Export_Folder; }
                set { mFilePath_Export_Folder = value; }
            }

            public string IniFileName
            //=======================
            {
                get { return mIniFileName; }
                set { mIniFileName = value; }
            }

        #endregion


    }
}
