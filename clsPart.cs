//===============================================================================
//                                                                              '
//                          SOFTWARE  :  "EHRT"                                 '
//                       CODE MODULE  :  clsPart                                '
//                        VERSION NO  :  1.0                                    '
//                      DEVELOPED BY  :  AdvEnSoft, Inc.                        '
//                     LAST MODIFIED  :  22DEC15                                '
//                                                                              '
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo ("AssemblyB")]
[assembly: InternalsVisibleTo("Groucho.Generic.Tests")]
[assembly: InternalsVisibleTo("Groucho.Generic.Moles")]
[assembly: InternalsVisibleTo("Groucho.Generic.Explorables")]

namespace EHRT
{
    class clsPart
    {
        #region "ENUMERATED VARIABLE DEFINITIONS:"
        //======================================

            public enum eBendDir
            {
                U,          //...Up
                D,          //...Down
            };

        #endregion


        #region "STRUCTURE DEFINITIONS:"
        //=============================

            public struct sSize
            {
                public double L;           
                public double W;
                public double T;
            }
                  

            public struct sBend
            {
                public eBendDir Dir;
                public double Distance;
                public Single Angle;
                public double Radius;
            }
            
        #endregion


        #region "MEMBER VARIABLE DECLARATIONS:"
        //====================================

            private string mMaterial;
            private string mPartNo;
            private sSize mSize;

            private sBend mBend;
            private List<sBend> mBendList_Left;
            
            
            private List<clsEntity> mEntity_Unfolded;
            private List<clsEntity> mEntity_folded;

        #endregion


        #region "PROPERTY DECLARATIONS:"
        //==============================

            public string Material
            //====================
            {
                get { return mMaterial; }
                set { mMaterial = value; }
            }

            public string PartNo
            //==================
            {
                get { return mPartNo; }
                set { mPartNo = value; }
            }
        
            public sSize Size
            //===============
            {
                get { return mSize; }
            }

            public double Height
            //==================
            {
                set { mSize.L = value; }
            }

            public double Width
            //==================
            {
                set { mSize.W = value; }
            }

            public double Thickness
            //=====================
            {
                set { mSize.T = value; }
            }

            public List<sBend> BendList_Left
            //=====================
            {
                get { return mBendList_Left; }
                set { mBendList_Left = value; }
            }
        
            public sBend Bend
            //===============
            {
                get { return mBend; }
            }

            public double Bend_Distance
            //=========================
            {
                set { mBend.Distance = value; }
            }

            public eBendDir Bend_Dir
            //====================
            {
                set { mBend.Dir = value; }
            }

            public Single Bend_Angle
            //=========================
            {
                set { mBend.Angle = value; }
            }

            public double Bend_Radius
            //=========================
            {
                set { mBend.Radius = value; }
            }
            
        
            public List<clsEntity> Entity_Unfolded
            //==================================
            {
                get { return mEntity_Unfolded; }
                set { mEntity_Unfolded = value; }
            }

            public List<clsEntity> Entity_folded
            //==================================
            {
                get { return mEntity_folded; }
                set { mEntity_folded = value; }
            }

        #endregion


        #region "CLASS METHODS"
        //--------------------

            public void BendList_Right()
            //==========================
            {

            }


            public List<Single> DetermineBendAngle()
            //======================================
            {
                List<Single> pAngle = new List<Single>();

                List<clsEntity> pEntity = new List<clsEntity>();
                Dictionary<clsEntity, double> pEntity_Slope = new Dictionary<clsEntity, double>();

                int pIndex = 0;
                for (int i = 0; i < mEntity_folded.Count; i++)
                {
                    double pEntityLen = clsEntity.GetDistance_BetwnPts(mEntity_folded[i].Begin_Pt, mEntity_folded[i].End_Pt);
                    if (Math.Abs(mSize.T - pEntityLen) < modMain.gcEPS)
                    {
                        pIndex = i;
                        //pEntity.Add(mEntity_folded[i]);
                        break;
                    }
                }

                for (int j = pIndex + 1; j < mEntity_folded.Count; j++)
                {
                    double pEntityLen = clsEntity.GetDistance_BetwnPts(mEntity_folded[j].Begin_Pt, mEntity_folded[j].End_Pt);
                    //pEntity.Add(mEntity_folded[j]);
                    if (Math.Abs(mSize.T - pEntityLen) < modMain.gcEPS)
                    {
                        break;
                    }
                    pEntity.Add(mEntity_folded[j]);
                }

                for (int i = 1; i < pEntity.Count; i++)
                {
                    pAngle.Add(Convert.ToSingle(Math.Round(AngleBetween2Lines(pEntity[i], pEntity[i - 1]) + 180)));
                    //double pSlope = 0.0;
                    //Calc_LineSlope(pEntity[i], ref pSlope);
                    //pEntity_Slope.Add(pEntity[i], pSlope);
                }

                return pAngle;

            }

        #endregion



        #region "Helper Routines:"
        //========================


            public void DetermineSize()
            //=========================
            {
                mSize.W = XMax() - XMin();
                mSize.L = YMax() - YMin();
            }

            public double XMin()
            //==================
            {
                double pXMin = Entity_Unfolded[0].Begin_Pt.X;

                for (int i = 0; i < Entity_Unfolded.Count; i++)
                {
                    if (pXMin > Entity_Unfolded[i].Begin_Pt.X)
                    {
                        pXMin = Entity_Unfolded[i].Begin_Pt.X;
                    }
                    if (pXMin > Entity_Unfolded[i].End_Pt.X)
                    {
                        pXMin = Entity_Unfolded[i].End_Pt.X;
                    }
                }

                return pXMin;
            }


            public double XMax()
            //===================
            {
                double pXMax = Entity_Unfolded[0].Begin_Pt.X;

                for (int i = 0; i < Entity_Unfolded.Count; i++)
                {
                    if (pXMax < Entity_Unfolded[i].Begin_Pt.X)
                    {
                        pXMax = Entity_Unfolded[i].Begin_Pt.X;
                    }
                    if (pXMax < Entity_Unfolded[i].End_Pt.X)
                    {
                        pXMax = Entity_Unfolded[i].End_Pt.X;
                    }
                }

                return pXMax;
            }


            public double YMin()
            //==================
            {
                double pYMin = Entity_Unfolded[0].End_Pt.Y;

                for (int i = 0; i < Entity_Unfolded.Count; i++)
                {
                    if (pYMin > Entity_Unfolded[i].End_Pt.Y)
                    {
                        pYMin = Entity_Unfolded[i].End_Pt.Y;
                    }
                    if (pYMin > Entity_Unfolded[i].Begin_Pt.Y)
                    {
                        pYMin = Entity_Unfolded[i].Begin_Pt.Y;
                    }
                }

                return pYMin;
            }


            public double YMax()
            //==================
            {
                double pYMax = Entity_Unfolded[0].End_Pt.Y;

                for (int i = 0; i < Entity_Unfolded.Count; i++)
                {
                    if (pYMax < Entity_Unfolded[i].End_Pt.Y)
                    {
                        pYMax = Entity_Unfolded[i].End_Pt.Y;
                    }
                    if (pYMax < Entity_Unfolded[i].Begin_Pt.Y)
                    {
                        pYMax = Entity_Unfolded[i].Begin_Pt.Y;
                    }
                }
                return pYMax;
            }

            public void Sort_BendDistance(ref List<clsPart.sBend> Bend_In)
            //=============================================================
            {
                clsPart.sBend pBend = new clsPart.sBend();
                for (int i = 0; i < Bend_In.Count; i++)
                {
                    for (int j = 0; j < Bend_In.Count - 1; j++)
                    {
                        if (Bend_In[j].Distance > Bend_In[j + 1].Distance)
                        {
                            pBend = Bend_In[j];
                            Bend_In[j] = Bend_In[j + 1];
                            Bend_In[j + 1] = pBend;
                        }
                    }
                }
            }

            private void Calc_LineSlope(clsEntity Entity_In, ref double Slope_Out)
            //====================================================================
            {
                //double pcInfinity_Slope = 99.99F;

                double pEntityIn_Denominator = (Entity_In.End_Pt.X - Entity_In.Begin_Pt.X);

                if (Math.Abs(pEntityIn_Denominator - 0.0) < modMain.gcEPS)
                {
                    Slope_Out = 90.0;
                }
                else
                {
                    Slope_Out = (Entity_In.End_Pt.Y - Entity_In.Begin_Pt.Y) / pEntityIn_Denominator;
                    
                }

            }
        
           
            private double AngleBetween2Lines(clsEntity Entity1_In, clsEntity Entity2_In)
            //===========================================================================
            {
                const double pc_Rad2Deg = 180.0 / Math.PI;
                double angle1 = Math.Atan2(Entity1_In.Begin_Pt.Y - Entity1_In.End_Pt.Y,
                                           Entity1_In.Begin_Pt.X - Entity1_In.End_Pt.X);
                double angle2 = Math.Atan2(Entity2_In.Begin_Pt.Y - Entity2_In.End_Pt.Y,
                                           Entity2_In.Begin_Pt.X - Entity2_In.End_Pt.X);

                return (angle1 - angle2) * pc_Rad2Deg;
            }
                    
        #endregion

    }
}
