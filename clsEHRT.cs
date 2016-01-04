//===============================================================================
//                                                                              '
//                          SOFTWARE  :  "EHRT"                                 '
//                       CODE MODULE  :  clsEHRT                                '
//                        VERSION NO  :  1.0                                    '
//                      DEVELOPED BY  :  AdvEnSoft, Inc.                        '
//                     LAST MODIFIED  :  22DEC15                                '
//                                                                              '
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EHRT
{
    class clsEHRT
    {
        #region "ENUMERATED VARIABLE DEFINITIONS:"
        //======================================

            public enum ePartEnd_Backguage { Left, Right };

            public enum eToolType { Punch, Die };

        #endregion
        

        #region "MEMBER VARIABLE DECLARATIONS:"
        //====================================

            private string mFileName = null; 
            private List<clsPart> mPart = new List<clsPart>();

            private ePartEnd_Backguage mPartEnd_Backguage;
            private eToolType mStationaryTool;
            private modMain.myPoint mHeadPos = new modMain.myPoint();
            private double mMovingTool_DistIni = 0.0;


        #endregion

        #region "PROPERTY DECLARATIONS:"
        //==============================

            public string FileName
            //====================
            {
                get { return mFileName; }
                set { mFileName = value; }
            }

            public List<clsPart> Part
            //=======================
            {
                get { return mPart; }
                set { mPart = value; }
            }

            public ePartEnd_Backguage PartEnd_Backguage
            //==========================================
            {
                get { return mPartEnd_Backguage; }
                set { mPartEnd_Backguage = value; }
            }

            public eToolType StationaryTool
            //=============================
            {
                get { return mStationaryTool; }
                set { mStationaryTool = value; }
            }


            public modMain.myPoint HeadPos
            //=============================
            {
                get { return mHeadPos; }
                set { mHeadPos = value; }
            }

            public double MovingTool_DistIni
            //==============================
            {
                get { return mMovingTool_DistIni; }
                set { mMovingTool_DistIni = value; }
            }

        #endregion

        #region "CLASS METHODS"
        //--------------------

            public void Process_Part()
            //========================
            {
                ReadDXFFile(mFileName);

                //Select_Tool();
                //Collision_Test();
                //Write_Program();

                
            }

            #region "READ DXF FILE:"
            //======================

                public void ReadDXFFile(string FileName_In)
                //==========================================
                {
                    #region "PART:"
                    //=============

                    List<clsEntity> pEntityList_Temp = new List<clsEntity>();
                    pEntityList_Temp = ReadDXFLayer(FileName_In, "PROGP");      //....For the Unfolded part information.
                    //pEntityList_Temp = ReadDXFLayer(FileName_In, "OBJ");

                    string pFileTitle = "";
                    int a = FileName_In.LastIndexOf("\\") + 2;

                    pFileTitle = FileName_In.Substring(a, FileName_In.Length - a).Remove(FileName_In.Substring(a, FileName_In.Length - a).Length - 4);
                    clsPart pPart = new clsPart();
                    pPart.PartNo = pFileTitle;
                    List<clsEntity> pEntityList = new List<clsEntity>();
                    pEntityList = ArrangeEntityCW(pEntityList_Temp);
                    pPart.Entity_Unfolded = pEntityList;
                    pPart.DetermineSize();

                    pEntityList_Temp = new List<clsEntity>();
                    pEntityList_Temp = ReadDXFLayer(FileName_In, "OBJ");        //....For the folded part information.

                    pEntityList = new List<clsEntity>();
                    pEntityList = ArrangeEntityCW(pEntityList_Temp);
                    pPart.Entity_folded = pEntityList;

                    List<double> pDistance = new List<double>();
                    for (int i = 0; i < pPart.Entity_folded.Count; i++)
                    {
                        pDistance.Add(clsEntity.GetDistance_BetwnPts(pPart.Entity_folded[i].Begin_Pt, pPart.Entity_folded[i].End_Pt));
                    }
                    pDistance.Sort();
                    pPart.Thickness = pDistance[0];

                    #endregion


                    #region "BEND:"
                    //=============

                    pEntityList_Temp = new List<clsEntity>();
                    List<clsPart.sBend> pBendList = new List<clsPart.sBend>();

                    pEntityList_Temp = ReadDXFLayer(FileName_In, "BENDU");
                    if (pEntityList_Temp.Count > 0)
                    {
                        for (int j = 0; j < pEntityList_Temp.Count; j++)
                        {
                            clsPart.sBend pBend = new clsPart.sBend();
                            pBend.Distance = pPart.XMax() - pEntityList_Temp[j].Begin_Pt.X;
                            pBend.Dir = clsPart.eBendDir.U;
                            pBendList.Add(pBend);
                        }
                    }

                    pEntityList_Temp = new List<clsEntity>();
                    pEntityList_Temp = ReadDXFLayer(FileName_In, "BENDD");
                    if (pEntityList_Temp.Count > 0)
                    {
                        for (int j = 0; j < pEntityList_Temp.Count; j++)
                        {
                            clsPart.sBend pBend = new clsPart.sBend();
                            pBend.Distance = pPart.XMax() - pEntityList_Temp[j].Begin_Pt.X;
                            pBend.Dir = clsPart.eBendDir.D;
                            pBendList.Add(pBend);
                        }
                    }

                    pPart.Sort_BendDistance(ref pBendList);
                    pPart.BendList_Left = pBendList;
                    List<Single> pAngle = pPart.DetermineBendAngle();
                    for (int i = 0; i < pPart.BendList_Left.Count; i++)
                    {
                        if (pPart.BendList_Left[i].Dir == clsPart.eBendDir.D)
                        {
                            clsPart.sBend pBend = new clsPart.sBend();
                            pBend.Distance = pPart.BendList_Left[i].Distance;
                            pBend.Angle = pAngle[i];
                            pBend.Dir = pPart.BendList_Left[i].Dir;
                            pPart.BendList_Left[i] = pBend;
                        }
                        else
                        {
                            clsPart.sBend pBend = new clsPart.sBend();
                            pBend.Distance = pPart.BendList_Left[i].Distance;
                            pBend.Angle = 360 - pAngle[i];
                            pBend.Dir = pPart.BendList_Left[i].Dir;
                            pPart.BendList_Left[i] = pBend;
                        }
                    }

                    #endregion

                    modMain.gEHRTBender.Part.Add(pPart);

                }



                private List<clsEntity> ReadDXFLayer(string FileName_In, string LayerName_In)
                //===========================================================================
                {
                    StreamReader pSR = new StreamReader(FileName_In);
                    string pstr = "";
                    pstr = pSR.ReadLine();
                    List<clsEntity> pEntityList = new List<clsEntity>();


                    while (pstr != null)
                    {
                        pstr = pstr.Trim();
                        if (pstr == LayerName_In)
                        {
                            pstr = pSR.ReadLine().Trim();

                            while (pstr != "0")
                            {
                                //if (pstr.Contains("62"))
                                //{
                                //    pSR.ReadLine();
                                //    pstr = pSR.ReadLine();
                                //}
                                //if (pstr.Contains("100"))
                                //{
                                pstr = pSR.ReadLine().Trim();     //....AcDbLine

                                if (pstr.Contains("AcDbLine"))
                                {
                                    clsEntity pEntity = new clsEntity();
                                    modMain.myPoint pPt1 = new modMain.myPoint();
                                    modMain.myPoint pPt2 = new modMain.myPoint();
                                    pstr = pSR.ReadLine();
                                    if (pstr.Contains("10"))
                                    {
                                        pPt1.X = Convert.ToDouble(pSR.ReadLine());
                                    }
                                    pstr = pSR.ReadLine();
                                    if (pstr.Contains("20"))
                                    {
                                        pPt1.Y = Convert.ToDouble(pSR.ReadLine());
                                    }
                                    pEntity.Begin_Pt = pPt1;

                                    pSR.ReadLine();
                                    pSR.ReadLine();

                                    pstr = pSR.ReadLine();
                                    if (pstr.Contains("11"))
                                    {
                                        pPt2.X = Convert.ToDouble(pSR.ReadLine());
                                    }
                                    pstr = pSR.ReadLine();
                                    if (pstr.Contains("21"))
                                    {
                                        pPt2.Y = Convert.ToDouble(pSR.ReadLine());
                                    }
                                    pEntity.End_Pt = pPt2;
                                    pEntity.G_Code = 1;
                                    pEntityList.Add(pEntity);
                                }
                                //}
                            }
                        }
                        pstr = pSR.ReadLine();
                    }

                    pSR.Close();

                    return pEntityList;
                }

                private List<clsEntity> ArrangeEntityCW(List<clsEntity> EntityList_In)
                //=========================================================
                {
                    List<clsEntity> EntityList = new List<clsEntity>();
                    clsEntity pEntity = new clsEntity();
                    pEntity = EntityList_In[0];
                    EntityList.Add(pEntity);

                    for (int i = 1; i < EntityList_In.Count; i++)
                    {
                        for (int j = 0; j < EntityList_In.Count; j++)
                        {
                            if ((Math.Abs(EntityList_In[j].Begin_Pt.X - pEntity.End_Pt.X) < modMain.gcEPS &&
                                Math.Abs(EntityList_In[j].Begin_Pt.Y - pEntity.End_Pt.Y) < modMain.gcEPS) &&
                                (!(Math.Abs(EntityList_In[j].End_Pt.X - pEntity.Begin_Pt.X) < modMain.gcEPS) &&
                                 !(Math.Abs(EntityList_In[j].End_Pt.Y - pEntity.Begin_Pt.Y) < modMain.gcEPS)))
                            {
                                pEntity = new clsEntity();
                                pEntity.Begin_Pt = EntityList_In[j].Begin_Pt;
                                pEntity.End_Pt = EntityList_In[j].End_Pt;
                                pEntity.G_Code = EntityList_In[j].G_Code;
                                EntityList.Add(pEntity);
                                break;
                            }
                            else if ((Math.Abs(EntityList_In[j].End_Pt.X - pEntity.End_Pt.X) < modMain.gcEPS &&
                                    Math.Abs(EntityList_In[j].End_Pt.Y - pEntity.End_Pt.Y) < modMain.gcEPS) &&
                                    (!(Math.Abs(EntityList_In[j].Begin_Pt.X - pEntity.Begin_Pt.X) < modMain.gcEPS) &&
                                    !(Math.Abs(EntityList_In[j].Begin_Pt.Y - pEntity.Begin_Pt.Y) < modMain.gcEPS)))
                            {
                                pEntity = new clsEntity();
                                pEntity.Begin_Pt = EntityList_In[j].End_Pt;
                                pEntity.End_Pt = EntityList_In[j].Begin_Pt;
                                pEntity.G_Code = EntityList_In[j].G_Code;
                                EntityList.Add(pEntity);

                                break;
                            }
                        }
                    }

                    return EntityList;
                }

            #endregion



        #endregion
    }
}
