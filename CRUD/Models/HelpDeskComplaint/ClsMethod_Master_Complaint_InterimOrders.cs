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
    public class ClsMethod_Master_Complaint_InterimOrders
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }        

        public List<Clsprp_Master_Complaint_InterimOrders> Display_Master_Complaint_DocumentsByComplaintDocInfoID(Int32 ID)
        {
            connection();
            List<Clsprp_Master_Complaint_InterimOrders> MasterInterimOrders = new List<Clsprp_Master_Complaint_InterimOrders>();
                        
            MySqlCommand cmd = new MySqlCommand("Display_Rera_InterimOrder_FormM_DocMaster_ByDocId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintDocMaster_InfoCode", ID);          

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterInterimOrders.Add(
                    new Clsprp_Master_Complaint_InterimOrders
                    {
                        ComplaintDocMaster_IndexID = Convert.ToInt32(dr["ComplaintDocMaster_IndexID"]),
                        ComplaintDocMaster_InfoCode = Convert.ToInt32(dr["ComplaintDocMaster_InfoCode"]),
                        ComplaintDocMaster_InfoName = Convert.ToString(dr["ComplaintDocMaster_InfoName"]),
                        ComplaintDocMaster_RelatedSectionName = Convert.ToString(dr["ComplaintDocMaster_RelatedSectionName"]),
                        ComplaintDoc_SetFileSize = Convert.ToString(dr["ComplaintDoc_SetFileSize"]),
                        ComplaintDoc_SetFileFormat = Convert.ToString(dr["ComplaintDoc_SetFileFormat"]),
                        ComplaintDoc_SetFilePath = Convert.ToString(dr["ComplaintDoc_SetFilePath"]),
                        ComplaintDoc_ValidCode = Convert.ToInt32(dr["ComplaintDoc_ValidCode"]),
                        ComplaintDoc_ValidSubCode = Convert.ToInt32(dr["ComplaintDoc_ValidSubCode"]),
                        ComplaintDoc_ValidTinySubCode = Convert.ToInt32(dr["ComplaintDoc_ValidTinySubCode"]),
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
            return MasterInterimOrders;
        }
        
        public List<Clsprp_Master_Complaint_InterimOrders> Display_Master_Complaint_DocumentsByComplaintFormID(Int64 ComplaintFormID)
        {
            connection();
            List<Clsprp_Master_Complaint_InterimOrders> MasterInterimOrders = new List<Clsprp_Master_Complaint_InterimOrders>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_InterimOrder_DocMaster_ByComplaintFormID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ComplaintFormID", ComplaintFormID);                
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    MasterInterimOrders.Add(
                        new Clsprp_Master_Complaint_InterimOrders
                        {
                            ComplaintDocMaster_IndexID = Convert.ToInt32(dr["ComplaintDocMaster_IndexID"]),
                            ComplaintDocMaster_InfoCode = Convert.ToInt32(dr["ComplaintDocMaster_InfoCode"]),
                            ComplaintDocMaster_InfoName = Convert.ToString(dr["ComplaintDocMaster_InfoName"]),
                            ComplaintDocMaster_RelatedSectionName = Convert.ToString(dr["ComplaintDocMaster_RelatedSectionName"]),
                            ComplaintDoc_SetFileSize = Convert.ToString(dr["ComplaintDoc_SetFileSize"]),
                            ComplaintDoc_SetFileFormat = Convert.ToString(dr["ComplaintDoc_SetFileFormat"]),
                            ComplaintDoc_SetFilePath = Convert.ToString(dr["ComplaintDoc_SetFilePath"]),
                            ComplaintDoc_ValidCode = Convert.ToInt32(dr["ComplaintDoc_ValidCode"]),
                            ComplaintDoc_ValidSubCode = Convert.ToInt32(dr["ComplaintDoc_ValidSubCode"]),
                            ComplaintDoc_ValidTinySubCode = Convert.ToInt32(dr["ComplaintDoc_ValidTinySubCode"]),
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
            catch(Exception ex)
            {
                ex.ToString();
            }
            return MasterInterimOrders;
        }      

    }
}