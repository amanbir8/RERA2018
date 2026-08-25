using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsMethod_Master_Complaint_OrderJudgements
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Clsprp_Master_Complaint_OrderJudgements> Display_Master_OrderJudgements_DocumentsByComplaintDocInfoID(Int32 ID)
        {
            connection();
            List<Clsprp_Master_Complaint_OrderJudgements> MasterOrders = new List<Clsprp_Master_Complaint_OrderJudgements>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_OrderJudgements_FormM_DocMaster_ByDocId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_OrderJudgementDocMaster_InfoCode", ID);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    MasterOrders.Add(
                        new Clsprp_Master_Complaint_OrderJudgements
                        {
                            OrderJudgementDocMaster_IndexID = Convert.ToInt32(dr["OrderJudgementDocMaster_IndexID"]),
                            OrderJudgementDocMaster_InfoCode = Convert.ToInt32(dr["OrderJudgementDocMaster_InfoCode"]),
                            OrderJudgementDocMaster_InfoName = Convert.ToString(dr["OrderJudgementDocMaster_InfoName"]),
                            OrderJudgementDocMaster_RelatedSectionName = Convert.ToString(dr["OrderJudgementDocMaster_RelatedSectionName"]),
                            OrderJudgementDoc_SetFileSize = Convert.ToString(dr["OrderJudgementDoc_SetFileSize"]),
                            OrderJudgementDoc_SetFileFormat = Convert.ToString(dr["OrderJudgementDoc_SetFileFormat"]),
                            OrderJudgementDoc_SetFilePath = Convert.ToString(dr["OrderJudgementDoc_SetFilePath"]),
                            OrderJudgementDoc_ValidCode = Convert.ToInt32(dr["OrderJudgementDoc_ValidCode"]),
                            OrderJudgementDoc_ValidSubCode = Convert.ToInt32(dr["OrderJudgementDoc_ValidSubCode"]),
                            OrderJudgementDoc_ValidTinySubCode = Convert.ToInt32(dr["OrderJudgementDoc_ValidTinySubCode"]),
                            IsGroup = Convert.ToInt32(dr["IsGroup"]),
                            IsMandatory = Convert.ToString(dr["IsMandatory"]),
                            A_column = Convert.ToString(dr["A_column"]),
                            B_column = Convert.ToString(dr["B_column"]),
                            C_column = Convert.ToString(dr["C_column"]),
                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            CreatedBy = Convert.ToString(dr["CreatedBy"]),
                            CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                            ModifyBy = Convert.ToString(dr["ModifyBy"]),
                            ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                        });
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return MasterOrders;
        }
        
        public List<Clsprp_Master_Complaint_OrderJudgements> Display_Master_OrderJudgements_DocumentsByComplaintFormID(Int64 ComplaintFormID)
        {
            connection();
            List<Clsprp_Master_Complaint_OrderJudgements> MasterOrders = new List<Clsprp_Master_Complaint_OrderJudgements>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_OrderJudgements_DocMaster_ByComplaintFormID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_OrderJudgementFormID", ComplaintFormID);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    MasterOrders.Add(
                        new Clsprp_Master_Complaint_OrderJudgements
                        {
                            OrderJudgementDocMaster_IndexID = Convert.ToInt32(dr["OrderJudgementDocMaster_IndexID"]),
                            OrderJudgementDocMaster_InfoCode = Convert.ToInt32(dr["OrderJudgementDocMaster_InfoCode"]),
                            OrderJudgementDocMaster_InfoName = Convert.ToString(dr["OrderJudgementDocMaster_InfoName"]),
                            OrderJudgementDocMaster_RelatedSectionName = Convert.ToString(dr["OrderJudgementDocMaster_RelatedSectionName"]),
                            OrderJudgementDoc_SetFileSize = Convert.ToString(dr["OrderJudgementDoc_SetFileSize"]),
                            OrderJudgementDoc_SetFileFormat = Convert.ToString(dr["OrderJudgementDoc_SetFileFormat"]),
                            OrderJudgementDoc_SetFilePath = Convert.ToString(dr["OrderJudgementDoc_SetFilePath"]),
                            OrderJudgementDoc_ValidCode = Convert.ToInt32(dr["OrderJudgementDoc_ValidCode"]),
                            OrderJudgementDoc_ValidSubCode = Convert.ToInt32(dr["OrderJudgementDoc_ValidSubCode"]),
                            OrderJudgementDoc_ValidTinySubCode = Convert.ToInt32(dr["OrderJudgementDoc_ValidTinySubCode"]),
                            IsGroup = Convert.ToInt32(dr["IsGroup"]),
                            IsMandatory = Convert.ToString(dr["IsMandatory"]),
                            A_column = Convert.ToString(dr["A_column"]),
                            B_column = Convert.ToString(dr["B_column"]),
                            C_column = Convert.ToString(dr["C_column"]),
                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            CreatedBy = Convert.ToString(dr["CreatedBy"]),
                            CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                            ModifyBy = Convert.ToString(dr["ModifyBy"]),
                            ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                        });
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return MasterOrders;
        }      

    }
}