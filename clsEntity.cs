//===============================================================================
//                                                                              '
//                          SOFTWARE  :  "EHRT"                                 '
//                       CODE MODULE  :  clsEntity                              '
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
    class clsEntity
    {
        #region "MEMBER VARIABLE DECLARATIONS:"
        //===================================

            //....An order of magnitude smaller than gcEPS & hence, stored locally here.
            private const double mcEPS = 0.0001F;     //....An arbitrary small no.        
            private modMain.myPoint mBegin_Pt;
            private modMain.myPoint mEnd_Pt;
            private int mG_Code;
            private Single mI_Code;
            private Single mJ_Code;

        #endregion


        #region "PROPERTY ROUTINES:"
        //==========================

            public modMain.myPoint Begin_Pt
            {
                get { return mBegin_Pt; }
                set { mBegin_Pt = value; }
            }


            public modMain.myPoint End_Pt
            {
                get { return mEnd_Pt; }
                set { mEnd_Pt = value; }
            }


            public int G_Code
            {
                get { return mG_Code; }
                set { mG_Code = value; }
            }


            public Single I_Code
            {
                get { return mI_Code; }
                set { mI_Code = value; }
            }


            public Single J_Code
            {
                get { return mJ_Code; }
                set { mJ_Code = value; }
            }

        #endregion


        #region "METHODS:"
        //===============

            public modMain.myPoint CenterPt_Arc()
            //=====================================
            {
                modMain.myPoint[] pTempCenPt = new modMain.myPoint[4];
                modMain.myPoint pCenPt;
                pCenPt.X = 0.0F;
                pCenPt.Y = 0.0F;

                if (mG_Code == 2)
                {
                    pTempCenPt[0].X = mBegin_Pt.X + mI_Code;
                    pTempCenPt[0].Y = mBegin_Pt.Y + mJ_Code;

                    pTempCenPt[1].X = mBegin_Pt.X + mI_Code;
                    pTempCenPt[1].Y = mBegin_Pt.Y - mJ_Code;

                    pTempCenPt[2].X = mBegin_Pt.X - mI_Code;
                    pTempCenPt[2].Y = mBegin_Pt.Y + mJ_Code;

                    pTempCenPt[3].X = mBegin_Pt.X - mI_Code;
                    pTempCenPt[3].Y = mBegin_Pt.Y - mJ_Code;

                    for (int pIndx = 0; pIndx < 4; pIndx++)
                    {
                        double pTemp1 = Math.Pow(mEnd_Pt.Y - pTempCenPt[pIndx].Y, 2.0F) + Math.Pow(mEnd_Pt.X - pTempCenPt[pIndx].X, 2.0F);
                        double pTemp2 = Math.Pow(mBegin_Pt.Y - pTempCenPt[pIndx].Y, 2.0F) + Math.Pow(mBegin_Pt.X - pTempCenPt[pIndx].X, 2.0F);

                        if (Math.Abs(pTemp1 - pTemp2) < mcEPS)
                        {
                            //....Center Point of the Arc.
                            pCenPt.X = pTempCenPt[pIndx].X;
                            pCenPt.Y = pTempCenPt[pIndx].Y;
                            break;
                        }
                    }
                }

                else if (mG_Code == 3)
                {
                    pTempCenPt[0].X = mBegin_Pt.X + mI_Code;
                    pTempCenPt[0].Y = mBegin_Pt.Y + mJ_Code;

                    pTempCenPt[1].X = mBegin_Pt.X + mI_Code;
                    pTempCenPt[1].Y = mBegin_Pt.Y - mJ_Code;

                    pTempCenPt[2].X = mBegin_Pt.X - mI_Code;
                    pTempCenPt[2].Y = mBegin_Pt.Y + mJ_Code;

                    pTempCenPt[3].X = mBegin_Pt.X - mI_Code;
                    pTempCenPt[3].Y = mBegin_Pt.Y - mJ_Code;

                    for (int pIndx = 0; pIndx < 4; pIndx++)
                    {
                        double pTemp1 = Math.Pow((mEnd_Pt.Y - pTempCenPt[pIndx].Y), 2.0F) + Math.Pow((mEnd_Pt.X - pTempCenPt[pIndx].X), 2.0F);
                        double pTemp2 = Math.Pow((mBegin_Pt.Y - pTempCenPt[pIndx].Y), 2.0F) + Math.Pow((mBegin_Pt.X - pTempCenPt[pIndx].X), 2.0F);

                        if (Math.Abs(pTemp1 - pTemp2) < mcEPS)
                        {
                            //....Center Point of the Arc.
                            pCenPt.X = pTempCenPt[pIndx].X;
                            pCenPt.Y = pTempCenPt[pIndx].Y;
                            break;
                        }
                    }
                }

                return pCenPt;
            }


            public static double GetDistance_BetwnPts(modMain.myPoint pPt1_In, modMain.myPoint pPt2_In)
            //===================================================================================
            {
                double pDistance = Math.Sqrt(Math.Pow((pPt2_In.X - pPt1_In.X), 2) +
                                             Math.Pow((pPt2_In.Y - pPt1_In.Y), 2));
                return pDistance;
            }

        #endregion

    }
}
