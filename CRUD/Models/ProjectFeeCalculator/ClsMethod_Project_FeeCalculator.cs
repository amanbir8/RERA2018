using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.Promoter;

namespace CRUD.Models.ProjectFeeCalculator
{
    public class ClsMethod_Project_FeeCalculator
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public DateTime datefun(string valuedate)
        {
            DateTime defaultdate = new DateTime(1919, 1, 1);
            if (valuedate != DBNull.Value.ToString())
            {
                IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
                String datetime = valuedate.Trim();
                DateTime dt = DateTime.Parse(datetime, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                return dt;
            }
            else
                return defaultdate;
        }

        //Project Registration (Fee Calculator) By Project_ID
        public Tuple<decimal, decimal, decimal, string> Display_ProjectPaymentRegistrationFeeCalculatorByProjectID(Int64 RelatedProjectID, Int64 RelatedPromoterID, Int64 PaymentType)
        {
            decimal retval = 0;
            decimal retWebPortalConvenienceFee = 0;
            decimal retOtherFee = 0;
            string retstr = string.Empty;

            Int64 varPaymentType = 0;
            varPaymentType = PaymentType;

            // Registration Fee
            if (varPaymentType == 1)
            {
                Int64 parmRelatedProjectID = 0;
                Int64 parmRelatedPromoterID = 0;
                Int64 parmProjectPayment_IndexID = 0;

                Int32 parmZone = 0;
                decimal parmTArea = 0;
                decimal parmPlotArea = 0;
                decimal parmGHArea = 0;
                decimal parmComArea = 0;
                decimal parmIndArea = 0;
                decimal parmCommonArea = 0;
                decimal parmOtherCommonArea = 0;
                decimal parmEWSArea = 0;

                try
                {
                    //Read Land Area Values from DB
                    connection();
                    MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_FeeCalculatorLandPaymentById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_RelatedProjectID", RelatedProjectID);
                    cmd.Parameters.AddWithValue("p_RelatedPromoterID", RelatedPromoterID);
                    cmd.Parameters.AddWithValue("p_PaymentType", PaymentType);
                    MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    con.Open();
                    sd.Fill(dt);
                    con.Close();

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            parmRelatedProjectID = Convert.ToInt64(dr["qRelatedProjectID"]);
                            parmRelatedPromoterID = Convert.ToInt64(dr["qRelatedPromoterID"]);
                            parmProjectPayment_IndexID = Convert.ToInt64(dr["qProjectPaymentType"]);
                            parmZone = Convert.ToInt32(dr["qProjectZoneCode"]);
                            parmTArea = Convert.ToDecimal(dr["qLandTotalArea"]);
                            parmPlotArea = Convert.ToDecimal(dr["qLandPlottedArea"]);
                            parmGHArea = Convert.ToDecimal(dr["qLandGroupHousingArea"]);
                            parmComArea = Convert.ToDecimal(dr["qLandCommercialArea"]);
                            parmIndArea = Convert.ToDecimal(dr["qLandIndustrialArea"]);
                            parmCommonArea = Convert.ToDecimal(dr["qLandCommonArea"]);
                            parmOtherCommonArea = Convert.ToDecimal(dr["qLandOtherCommonArea"]);
                            parmEWSArea = Convert.ToDecimal(dr["qLandEWSArea"]);
                        };
                    }                    

                    //Fee Calculator Formula
                    Tuple<decimal, string> ProjectRegistrationFeePayment = Get_ProjectRegistrationFeePayment(parmZone, parmTArea, parmPlotArea, parmGHArea, parmComArea, parmIndArea, parmCommonArea, parmOtherCommonArea, parmEWSArea);

                    retval = ProjectRegistrationFeePayment.Item1;
                    retstr = ProjectRegistrationFeePayment.Item2;
                    retOtherFee = 0m;
                    retWebPortalConvenienceFee = 5000m;
                }
                catch (Exception ex)
                {
                    string varEx = ex.ToString();
                }
            }
            else
            {
                // Late Fee or Any Other Fee
                retval = 0m;
                retstr = string.Empty;
                retOtherFee = 0m;
                retWebPortalConvenienceFee = 0m;
            }
            return new Tuple<decimal, decimal, decimal, string>(retval, retWebPortalConvenienceFee, retOtherFee, retstr);
        }

        //Project Registration (Fee Calculator with Land Area) By Project_ID
        public Tuple<decimal, decimal, decimal, string, int, decimal, Tuple<decimal, decimal, decimal, decimal, decimal, decimal, decimal>> Display_ProjectStaticValuePaymentRegistrationFeeCalculatorByProjectID(Int64 RelatedProjectID, Int64 RelatedPromoterID, Int64 PaymentType)
        {
            decimal retval = 0;
            decimal retWebPortalConvenienceFee = 0;
            decimal retOtherFee = 0;
            string retstr = string.Empty;

            decimal parmTArea = 0;
            decimal parmPlotArea = 0;
            decimal parmGHArea = 0;
            decimal parmComArea = 0;
            decimal parmIndArea = 0;
            decimal parmCommonArea = 0;
            decimal parmOtherCommonArea = 0;
            decimal parmEWSArea = 0;
            Int32 parmZone = 0;

            Int64 varPaymentType = 0;
            varPaymentType = PaymentType;

            // Registration Fee
            if (varPaymentType == 1)
            {
                Int64 parmRelatedProjectID = 0;
                Int64 parmRelatedPromoterID = 0;
                Int64 parmProjectPayment_IndexID = 0;                               

                try
                {
                    //Read Land Area Values from DB
                    connection();
                    MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_FeeCalculatorLandPaymentById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_RelatedProjectID", RelatedProjectID);
                    cmd.Parameters.AddWithValue("p_RelatedPromoterID", RelatedPromoterID);
                    cmd.Parameters.AddWithValue("p_PaymentType", PaymentType);
                    MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    con.Open();
                    sd.Fill(dt);
                    con.Close();

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            parmRelatedProjectID = Convert.ToInt64(dr["qRelatedProjectID"]);
                            parmRelatedPromoterID = Convert.ToInt64(dr["qRelatedPromoterID"]);
                            parmProjectPayment_IndexID = Convert.ToInt64(dr["qProjectPaymentType"]);
                            parmZone = Convert.ToInt32(dr["qProjectZoneCode"]);
                            parmTArea = Convert.ToDecimal(dr["qLandTotalArea"]);
                            parmPlotArea = Convert.ToDecimal(dr["qLandPlottedArea"]);
                            parmGHArea = Convert.ToDecimal(dr["qLandGroupHousingArea"]);
                            parmComArea = Convert.ToDecimal(dr["qLandCommercialArea"]);
                            parmIndArea = Convert.ToDecimal(dr["qLandIndustrialArea"]);
                            parmCommonArea = Convert.ToDecimal(dr["qLandCommonArea"]);
                            parmOtherCommonArea = Convert.ToDecimal(dr["qLandOtherCommonArea"]);
                            parmEWSArea = Convert.ToDecimal(dr["qLandEWSArea"]);
                        };
                    }

                    //Fee Calculator Formula
                    Tuple<decimal, string> ProjectRegistrationFeePayment = Get_ProjectRegistrationFeePayment(parmZone, parmTArea, parmPlotArea, parmGHArea, parmComArea, parmIndArea, parmCommonArea, parmOtherCommonArea, parmEWSArea);

                    retval = ProjectRegistrationFeePayment.Item1;
                    retstr = ProjectRegistrationFeePayment.Item2;
                    retOtherFee = 0m;
                    retWebPortalConvenienceFee = 5000m;
                }
                catch (Exception ex)
                {
                    string varEx = ex.ToString();
                }
            }
            else
            {
                // Late Fee or Any Other Fee
                retval = 0m;
                retstr = string.Empty;
                retOtherFee = 0m;
                retWebPortalConvenienceFee = 0m;
            }
            return new Tuple<decimal, decimal, decimal, string, int, decimal, Tuple<decimal, decimal, decimal, decimal, decimal, decimal, decimal>>(retval, retWebPortalConvenienceFee, retOtherFee, retstr, parmZone, parmTArea, Tuple.Create(parmPlotArea, parmGHArea, parmComArea, parmIndArea, parmCommonArea, parmOtherCommonArea, parmEWSArea));
        }

        //Project Registration (Land Area Details for Fee Calculator) By Project_ID
        public Tuple<int, string, decimal, Tuple<decimal, decimal, decimal, decimal, decimal, decimal, decimal>> Display_LandAreaDetailsPaymentFeeCalculatorByProjectID(Int64 RelatedProjectID, Int64 RelatedPromoterID, Int64 PaymentType)
        {
            string retstr = string.Empty;

            decimal parmTArea = 0;
            decimal parmPlotArea = 0;
            decimal parmGHArea = 0;
            decimal parmComArea = 0;
            decimal parmIndArea = 0;
            decimal parmCommonArea = 0;
            decimal parmOtherCommonArea = 0;
            decimal parmEWSArea = 0;
            Int32 parmZone = 0;

            Int64 varPaymentType = 0;
            varPaymentType = PaymentType;

            if (varPaymentType == 1)
            {
                Int64 parmRelatedProjectID = 0;
                Int64 parmRelatedPromoterID = 0;
                Int64 parmProjectPayment_IndexID = 0;                

                try
                {
                    //Read Land Area Values from DB
                    connection();
                    MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_FeeCalculatorLandPaymentById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_RelatedProjectID", RelatedProjectID);
                    cmd.Parameters.AddWithValue("p_RelatedPromoterID", RelatedPromoterID);
                    cmd.Parameters.AddWithValue("p_PaymentType", PaymentType);
                    MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    con.Open();
                    sd.Fill(dt);
                    con.Close();

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            parmRelatedProjectID = Convert.ToInt64(dr["qRelatedProjectID"]);
                            parmRelatedPromoterID = Convert.ToInt64(dr["qRelatedPromoterID"]);
                            parmProjectPayment_IndexID = Convert.ToInt64(dr["qProjectPaymentType"]);
                            parmZone = Convert.ToInt32(dr["qProjectZoneCode"]);
                            parmTArea = Convert.ToDecimal(dr["qLandTotalArea"]);
                            parmPlotArea = Convert.ToDecimal(dr["qLandPlottedArea"]);
                            parmGHArea = Convert.ToDecimal(dr["qLandGroupHousingArea"]);
                            parmComArea = Convert.ToDecimal(dr["qLandCommercialArea"]);
                            parmIndArea = Convert.ToDecimal(dr["qLandIndustrialArea"]);
                            parmCommonArea = Convert.ToDecimal(dr["qLandCommonArea"]);
                            parmOtherCommonArea = Convert.ToDecimal(dr["qLandOtherCommonArea"]);
                            parmEWSArea = Convert.ToDecimal(dr["qLandEWSArea"]);
                        };
                    }
                }
                catch (Exception ex)
                {
                    string varEx = ex.ToString();
                }
            }
            return new Tuple<int, string, decimal, Tuple<decimal, decimal, decimal, decimal, decimal, decimal, decimal>>(parmZone, retstr, parmTArea, Tuple.Create(parmPlotArea, parmGHArea, parmComArea, parmIndArea, parmCommonArea, parmOtherCommonArea, parmEWSArea));
        }

        //Project Registration (Fee Calculator) 
        public Tuple<decimal, string> Get_ProjectRegistrationFeePayment(Int32 vZone, decimal vTArea, decimal vPlotArea, decimal vGHArea, decimal vComArea, decimal vIndArea, decimal vCommonArea, decimal vOtherCommonArea, decimal vEWSArea)
        {
            decimal retval = 0;
            string retstr = string.Empty;

            //If (B5-(Sum B6:B9)<0) then NA
            decimal commonarea = (vTArea - (vPlotArea + vGHArea + vComArea + vIndArea + vOtherCommonArea + vEWSArea));
            if (commonarea >= 0)
            {
                //Project-Zone
                Int32 vZoneValue = 0;
                vZoneValue = vZone;

                //B5-B6-B7-B8-B9-B10-B11-B12
                //Land Entry Values
                decimal vB5TArea = 0;
                decimal vB6PlotArea = 0;
                decimal vB7GHArea = 0;
                decimal vB8ComArea = 0;
                decimal vB9IndArea = 0;
                decimal vB10CommonArea = 0;
                decimal vB11OtherCommonArea = 0;
                decimal vB12EWSArea = 0;

                vB5TArea = vTArea;
                vB6PlotArea = vPlotArea;
                vB7GHArea = vGHArea;
                vB8ComArea = vComArea;
                vB9IndArea = vIndArea;
                vB10CommonArea = vCommonArea;
                vB11OtherCommonArea = vOtherCommonArea;
                vB12EWSArea = vEWSArea;

                //J5-K5-L5-M5-N5-O5-P5
                //Zone Factors
                decimal factorJ5Plotted = 0;
                decimal factorK5GroupHousing = 0;
                decimal factorL5Commercial = 0;
                decimal factorM5Industrial = 0;
                decimal factorN5CommonArea = 0;
                decimal factorO5ClubSchoolOtherArea = 0;
                decimal factorP5EWS = 0;

                switch (vZoneValue)
                {
                    case 1:
                        {
                            factorJ5Plotted = 6;
                            factorK5GroupHousing = 10;
                            factorL5Commercial = 20;
                            factorM5Industrial = 4;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 20;
                            factorP5EWS = 10;
                            break;
                        }
                    case 2:
                        {
                            factorJ5Plotted = 4;
                            factorK5GroupHousing = 8;
                            factorL5Commercial = 16;
                            factorM5Industrial = 3.0m;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 16;
                            factorP5EWS = 8;
                            break;
                        }
                    case 3:
                        {
                            factorJ5Plotted = 6;
                            factorK5GroupHousing = 10;
                            factorL5Commercial = 20;
                            factorM5Industrial = 4;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 20;
                            factorP5EWS = 10;
                            break;
                        }
                    case 4:
                        {
                            factorJ5Plotted = 4;
                            factorK5GroupHousing = 8;
                            factorL5Commercial = 16;
                            factorM5Industrial = 3.0m;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 16;
                            factorP5EWS = 8;
                            break;
                        }
                    case 5:
                        {
                            factorJ5Plotted = 4;
                            factorK5GroupHousing = 8;
                            factorL5Commercial = 12;
                            factorM5Industrial = 3.0m;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 12;
                            factorP5EWS = 8;
                            break;
                        }
                    case 6:
                        {
                            factorJ5Plotted = 4;
                            factorK5GroupHousing = 6;
                            factorL5Commercial = 8;
                            factorM5Industrial = 2;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 8;
                            factorP5EWS = 6;
                            break;
                        }
                    case 7:
                        {
                            factorJ5Plotted = 2;
                            factorK5GroupHousing = 4;
                            factorL5Commercial = 6;
                            factorM5Industrial = 2;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 6;
                            factorP5EWS = 4;
                            break;
                        }
                    case 8:
                        {
                            factorJ5Plotted = 2;
                            factorK5GroupHousing = 4;
                            factorL5Commercial = 6;
                            factorM5Industrial = 2;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 6;
                            factorP5EWS = 4;
                            break;
                        }
                    default:
                        {
                            factorJ5Plotted = 6;
                            factorK5GroupHousing = 10;
                            factorL5Commercial = 20;
                            factorM5Industrial = 4;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 20;
                            factorP5EWS = 10;
                            break;
                        }
                }

                //J6-K6-L6-M6-N6-O6-P6
                //Percentage Components
                decimal J6 = 0;
                try
                {
                    J6 = Convert.ToDecimal((vB6PlotArea / (vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea)) * 100m);
                }
                catch (DivideByZeroException)
                {
                    J6 = 2;
                }
                decimal K6 = 0;
                try
                {
                    K6 = Convert.ToDecimal((vB7GHArea / (vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea)) * 100m);
                }
                catch (DivideByZeroException)
                {
                    K6 = 2;
                }
                decimal L6 = 0;
                try
                {
                    L6 = Convert.ToDecimal((vB8ComArea / (vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea)) * 100m);
                }
                catch (DivideByZeroException)
                {
                    L6 = 2;
                }
                decimal M6 = 0;
                try
                {
                    M6 = Convert.ToDecimal((vB9IndArea / (vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea)) * 100m);
                }
                catch (DivideByZeroException)
                {
                    M6 = 2;
                }
                decimal N6 = 0;
                try
                {
                    N6 = Convert.ToDecimal((vB10CommonArea / vB5TArea) * 100m);
                }
                catch (DivideByZeroException)
                {
                    N6 = 2;
                }
                decimal O6 = 0;
                try
                {
                    O6 = Convert.ToDecimal((vB11OtherCommonArea / (vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea)) * 100m);
                }
                catch (DivideByZeroException)
                {
                    O6 = 2;
                }
                decimal P6 = 0;
                try
                {
                    P6 = Convert.ToDecimal((vB12EWSArea / (vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea)) * 100m);
                }
                catch (DivideByZeroException)
                {
                    P6 = 2;
                }

                //J7-K7-L7-M7-NA-O7-P7
                //Common Area
                decimal J7 = Convert.ToDecimal((vB10CommonArea) * (J6 / 100m));
                decimal K7 = Convert.ToDecimal((vB10CommonArea) * (K6 / 100m));
                decimal L7 = Convert.ToDecimal((vB10CommonArea) * (L6 / 100m));
                decimal M7 = Convert.ToDecimal((vB10CommonArea) * (M6 / 100m));
                decimal NA = 0;
                try
                {
                    NA = Convert.ToDecimal(((vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea) / vB5TArea) * 100m);
                }
                catch (DivideByZeroException)
                {
                    NA = 2;
                }
                decimal O7 = Convert.ToDecimal((vB10CommonArea) * (O6 / 100m));
                decimal P7 = Convert.ToDecimal((vB10CommonArea) * (P6 / 100m));

                //J8
                //Common Area Fee
                decimal J8 = Convert.ToDecimal((factorJ5Plotted * J7) + (factorK5GroupHousing * K7) + (factorL5Commercial * L7) + (factorM5Industrial * M7) + (factorO5ClubSchoolOtherArea * O7) + (factorP5EWS * P7));

                // Extra Calculation Zone
                try
                {
                    decimal Zone1 = Convert.ToDecimal((vB6PlotArea * 6m) + (vB7GHArea * 10m) + (vB8ComArea * 20m) + (vB9IndArea * 4m) + (vB10CommonArea * 6m) + (vB11OtherCommonArea * 20m) + (vB12EWSArea * 10m));
                    decimal Zone2 = Convert.ToDecimal((vB6PlotArea * 4m) + (vB7GHArea * 8m) + (vB8ComArea * 16m) + (vB9IndArea * 3.0m) + (vB10CommonArea * 4m) + (vB11OtherCommonArea * 16m) + (vB12EWSArea * 8m));
                    decimal Zone3 = Convert.ToDecimal((vB6PlotArea * 6m) + (vB7GHArea * 10m) + (vB8ComArea * 20m) + (vB9IndArea * 4m) + (vB10CommonArea * 6m) + (vB11OtherCommonArea * 20m) + (vB12EWSArea * 10m));
                    decimal Zone4 = Convert.ToDecimal((vB6PlotArea * 4m) + (vB7GHArea * 8m) + (vB8ComArea * 16m) + (vB9IndArea * 3.0m) + (vB10CommonArea * 4m) + (vB11OtherCommonArea * 16m) + (vB12EWSArea * 8m));
                    decimal Zone5 = Convert.ToDecimal((vB6PlotArea * 4m) + (vB7GHArea * 8m) + (vB8ComArea * 12m) + (vB9IndArea * 3.0m) + (vB10CommonArea * 4m) + (vB11OtherCommonArea * 12m) + (vB12EWSArea * 8m));
                    decimal Zone6 = Convert.ToDecimal((vB6PlotArea * 4m) + (vB7GHArea * 6m) + (vB8ComArea * 8m) + (vB9IndArea * 2m) + (vB10CommonArea * 4m) + (vB11OtherCommonArea * 8m) + (vB12EWSArea * 6m));
                    decimal Zone7 = Convert.ToDecimal((vB6PlotArea * 2m) + (vB7GHArea * 4m) + (vB8ComArea * 6m) + (vB9IndArea * 2m) + (vB10CommonArea * 2m) + (vB11OtherCommonArea * 6m) + (vB12EWSArea * 4m));
                    decimal Zone8 = Convert.ToDecimal((vB6PlotArea * 2m) + (vB7GHArea * 4m) + (vB8ComArea * 6m) + (vB9IndArea * 2m) + (vB10CommonArea * 2m) + (vB11OtherCommonArea * 6m) + (vB12EWSArea * 4m));
                }
                catch (DivideByZeroException)
                {
                    string exstr = string.Empty;
                }

                //Project Registration Fee Amount

                decimal FeeAmount = 0;
                try
                {
                    FeeAmount = Convert.ToDecimal((vB6PlotArea * factorJ5Plotted) + (vB7GHArea * factorK5GroupHousing) + (vB8ComArea * factorL5Commercial) + (vB9IndArea * factorM5Industrial) + (vB11OtherCommonArea * factorO5ClubSchoolOtherArea) + (vB12EWSArea * factorP5EWS) + J8);
                }
                catch (Exception ex)
                {
                    string exstr = ex.ToString();
                    FeeAmount = 0m;
                }

                retval = FeeAmount;
            }
            else
            {
                retstr = "Invalid Area Values (In sqr merters)";
            }
            return new Tuple<decimal, string>(retval, retstr);
        }

        //Extra Amendments dt 29.06.2022 
        public Tuple<decimal, string> Get_ProjectRegistrationFeePayment_20220629(Int32 vZone, decimal vTArea, decimal vPlotArea, decimal vGHArea, decimal vComArea, decimal vIndArea, decimal vCommonArea, decimal vOtherCommonArea, decimal vEWSArea)
        {
            decimal retval = 0;
            string retstr = string.Empty;

            //If (B5-(Sum B6:B9)<0) then NA
            decimal commonarea = (vTArea - (vPlotArea + vGHArea + vComArea + vIndArea + vOtherCommonArea + vEWSArea));
            if (commonarea >= 0)
            {
                //Project-Zone
                Int32 vZoneValue = 0;
                vZoneValue = vZone;

                //B5-B6-B7-B8-B9-B10-B11-B12
                //Land Entry Values
                decimal vB5TArea = 0;
                decimal vB6PlotArea = 0;
                decimal vB7GHArea = 0;
                decimal vB8ComArea = 0;
                decimal vB9IndArea = 0;
                decimal vB10CommonArea = 0;
                decimal vB11OtherCommonArea = 0;
                decimal vB12EWSArea = 0;

                vB5TArea = vTArea;
                vB6PlotArea = vPlotArea;
                vB7GHArea = vGHArea;
                vB8ComArea = vComArea;
                vB9IndArea = vIndArea;
                vB10CommonArea = vCommonArea;
                vB11OtherCommonArea = vOtherCommonArea;
                vB12EWSArea = vEWSArea;

                //J5-K5-L5-M5-N5-O5-P5
                //Zone Factors
                decimal factorJ5Plotted = 0;
                decimal factorK5GroupHousing = 0;
                decimal factorL5Commercial = 0;
                decimal factorM5Industrial = 0;
                decimal factorN5CommonArea = 0;
                decimal factorO5ClubSchoolOtherArea = 0;
                decimal factorP5EWS = 0;

                switch (vZoneValue)
                {
                    case 1:
                        {
                            factorJ5Plotted = 3;
                            factorK5GroupHousing = 5;
                            factorL5Commercial = 10;
                            factorM5Industrial = 2;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 10;
                            factorP5EWS = 5;
                            break;
                        }
                    case 2:
                        {
                            factorJ5Plotted = 2;
                            factorK5GroupHousing = 4;
                            factorL5Commercial = 8;
                            factorM5Industrial = 1.5m;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 8;
                            factorP5EWS = 4;
                            break;
                        }
                    case 3:
                        {
                            factorJ5Plotted = 3;
                            factorK5GroupHousing = 5;
                            factorL5Commercial = 10;
                            factorM5Industrial = 2;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 10;
                            factorP5EWS = 5;
                            break;
                        }
                    case 4:
                        {
                            factorJ5Plotted = 2;
                            factorK5GroupHousing = 4;
                            factorL5Commercial = 8;
                            factorM5Industrial = 1.5m;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 8;
                            factorP5EWS = 4;
                            break;
                        }
                    case 5:
                        {
                            factorJ5Plotted = 2;
                            factorK5GroupHousing = 4;
                            factorL5Commercial = 6;
                            factorM5Industrial = 1.5m;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 6;
                            factorP5EWS = 4;
                            break;
                        }
                    case 6:
                        {
                            factorJ5Plotted = 2;
                            factorK5GroupHousing = 3;
                            factorL5Commercial = 4;
                            factorM5Industrial = 1;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 4;
                            factorP5EWS = 3;
                            break;
                        }
                    case 7:
                        {
                            factorJ5Plotted = 1;
                            factorK5GroupHousing = 2;
                            factorL5Commercial = 3;
                            factorM5Industrial = 1;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 3;
                            factorP5EWS = 2;
                            break;
                        }
                    case 8:
                        {
                            factorJ5Plotted = 1;
                            factorK5GroupHousing = 2;
                            factorL5Commercial = 3;
                            factorM5Industrial = 1;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 3;
                            factorP5EWS = 2;
                            break;
                        }
                    default:
                        {
                            factorJ5Plotted = 3;
                            factorK5GroupHousing = 5;
                            factorL5Commercial = 10;
                            factorM5Industrial = 2;
                            factorN5CommonArea = 0;
                            factorO5ClubSchoolOtherArea = 10;
                            factorP5EWS = 5;
                            break;
                        }
                }

                //J6-K6-L6-M6-N6-O6-P6
                //Percentage Components
                decimal J6 = 0;
                try
                {
                    J6 = Convert.ToDecimal((vB6PlotArea / (vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea)) * 100m);
                }
                catch (DivideByZeroException)
                {
                    J6 = 2;
                }
                decimal K6 = 0;
                try
                {
                    K6 = Convert.ToDecimal((vB7GHArea / (vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea)) * 100m);
                }
                catch (DivideByZeroException)
                {
                    K6 = 2;
                }
                decimal L6 = 0;
                try
                {
                    L6 = Convert.ToDecimal((vB8ComArea / (vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea)) * 100m);
                }
                catch (DivideByZeroException)
                {
                    L6 = 2;
                }
                decimal M6 = 0;
                try
                {
                    M6 = Convert.ToDecimal((vB9IndArea / (vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea)) * 100m);
                }
                catch (DivideByZeroException)
                {
                    M6 = 2;
                }
                decimal N6 = 0;
                try
                {
                    N6 = Convert.ToDecimal((vB10CommonArea / vB5TArea) * 100m);
                }
                catch (DivideByZeroException)
                {
                    N6 = 2;
                }
                decimal O6 = 0;
                try
                {
                    O6 = Convert.ToDecimal((vB11OtherCommonArea / (vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea)) * 100m);
                }
                catch (DivideByZeroException)
                {
                    O6 = 2;
                }
                decimal P6 = 0;
                try
                {
                    P6 = Convert.ToDecimal((vB12EWSArea / (vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea)) * 100m);
                }
                catch (DivideByZeroException)
                {
                    P6 = 2;
                }

                //J7-K7-L7-M7-NA-O7-P7
                //Common Area
                decimal J7 = Convert.ToDecimal((vB10CommonArea) * (J6 / 100m));
                decimal K7 = Convert.ToDecimal((vB10CommonArea) * (K6 / 100m));
                decimal L7 = Convert.ToDecimal((vB10CommonArea) * (L6 / 100m));
                decimal M7 = Convert.ToDecimal((vB10CommonArea) * (M6 / 100m));
                decimal NA = 0;
                try
                {
                    NA = Convert.ToDecimal(((vB6PlotArea + vB7GHArea + vB8ComArea + vB9IndArea + vB11OtherCommonArea + vB12EWSArea) / vB5TArea) * 100m);
                }
                catch (DivideByZeroException)
                {
                    NA = 2;
                }
                decimal O7 = Convert.ToDecimal((vB10CommonArea) * (O6 / 100m));
                decimal P7 = Convert.ToDecimal((vB10CommonArea) * (P6 / 100m));

                //J8
                //Common Area Fee
                decimal J8 = Convert.ToDecimal((factorJ5Plotted * J7) + (factorK5GroupHousing * K7) + (factorL5Commercial * L7) + (factorM5Industrial * M7) + (factorO5ClubSchoolOtherArea * O7) + (factorP5EWS * P7));

                // Extra Calculation Zone
                try
                {
                    decimal Zone1 = Convert.ToDecimal((vB6PlotArea * 3m) + (vB7GHArea * 5m) + (vB8ComArea * 10m) + (vB9IndArea * 2m) + (vB10CommonArea * 3m) + (vB11OtherCommonArea * 10m) + (vB12EWSArea * 5m));
                    decimal Zone2 = Convert.ToDecimal((vB6PlotArea * 2m) + (vB7GHArea * 4m) + (vB8ComArea * 8m) + (vB9IndArea * 1.5m) + (vB10CommonArea * 2m) + (vB11OtherCommonArea * 8m) + (vB12EWSArea * 4m));
                    decimal Zone3 = Convert.ToDecimal((vB6PlotArea * 3m) + (vB7GHArea * 5m) + (vB8ComArea * 10m) + (vB9IndArea * 2m) + (vB10CommonArea * 3m) + (vB11OtherCommonArea * 10m) + (vB12EWSArea * 5m));
                    decimal Zone4 = Convert.ToDecimal((vB6PlotArea * 2m) + (vB7GHArea * 4m) + (vB8ComArea * 8m) + (vB9IndArea * 1.5m) + (vB10CommonArea * 2m) + (vB11OtherCommonArea * 8m) + (vB12EWSArea * 4m));
                    decimal Zone5 = Convert.ToDecimal((vB6PlotArea * 2m) + (vB7GHArea * 4m) + (vB8ComArea * 6m) + (vB9IndArea * 1.5m) + (vB10CommonArea * 2m) + (vB11OtherCommonArea * 6m) + (vB12EWSArea * 4m));
                    decimal Zone6 = Convert.ToDecimal((vB6PlotArea * 2m) + (vB7GHArea * 3m) + (vB8ComArea * 4m) + (vB9IndArea * 1m) + (vB10CommonArea * 2m) + (vB11OtherCommonArea * 4m) + (vB12EWSArea * 3m));
                    decimal Zone7 = Convert.ToDecimal((vB6PlotArea * 1m) + (vB7GHArea * 2m) + (vB8ComArea * 3m) + (vB9IndArea * 1m) + (vB10CommonArea * 1m) + (vB11OtherCommonArea * 3m) + (vB12EWSArea * 2m));
                    decimal Zone8 = Convert.ToDecimal((vB6PlotArea * 1m) + (vB7GHArea * 2m) + (vB8ComArea * 3m) + (vB9IndArea * 1m) + (vB10CommonArea * 1m) + (vB11OtherCommonArea * 3m) + (vB12EWSArea * 2m));
                }
                catch (DivideByZeroException)
                {
                    string exstr = string.Empty;
                }

                //Project Registration Fee Amount

                decimal FeeAmount = 0;
                try
                {
                    FeeAmount = Convert.ToDecimal((vB6PlotArea * factorJ5Plotted) + (vB7GHArea * factorK5GroupHousing) + (vB8ComArea * factorL5Commercial) + (vB9IndArea * factorM5Industrial) + (vB11OtherCommonArea * factorO5ClubSchoolOtherArea) + (vB12EWSArea * factorP5EWS) + J8);
                }
                catch (Exception ex)
                {
                    string exstr = ex.ToString();
                    FeeAmount = 0m;
                }

                retval = FeeAmount;
            }
            else
            {
                retstr = "Invalid Area Values (In sqr merters)";
            }
            return new Tuple<decimal, string>(retval, retstr);
        }

    }
}