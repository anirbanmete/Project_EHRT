//===============================================================================
//                                                                              '
//                          SOFTWARE  :  "EHRT"                                 '
//                       CODE MODULE  :  clsMachine                             '
//                        VERSION NO  :  1.0                                    '
//                      DEVELOPED BY  :  AdvEnSoft, Inc.                        '
//                     LAST MODIFIED  :  22DEC15                                '
//                                                                              '
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EHRT
{
    class clsMachine
    {
        #region "STRUCTURE DEFINITIONS:"
        //=============================

            public struct sDie
            {
                public double D;    //...Depth
                public double W;    //...Width
            }


            public struct sPunch
            {
                public double D;    //...Depth
                public double W;    //...Width
                public double Rad;  //...Radius
            }

        #endregion


        #region "MEMBER VARIABLE DECLARATIONS:"
        //====================================

            private sDie mDie;
            private sPunch mPunch;

        #endregion


        #region "PROPERTY DECLARATIONS:"
        //==============================

            public sDie Die
            //===============
            {
                get { return mDie; }
            }

            public double Die_D
            //=================
            {
                set { mDie.D = value; }
            }

            public double Die_W
            //=================
            {
                set { mDie.W = value; }
            }


            public sPunch Punch
            //===============
            {
                get { return mPunch; }
            }

            public double Punch_D
            //===================
            {
                set { mPunch.D = value; }
            }

            public double Punch_W
            //====================
            {
                set { mPunch.W = value; }
            }
            public double Punch_Rad
            //=====================
            {
                set { mPunch.Rad = value; }
            }
        #endregion
    }
}
