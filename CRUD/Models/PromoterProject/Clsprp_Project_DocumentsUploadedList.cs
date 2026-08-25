using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.PromoterProject
{
    public class Clsprp_Project_DocumentsUploadedList
    {
        public int ProjectDoc_InfoCode { get; set; }
        public string ProjectDoc_InfoName { get; set; }       

        //public List<Clsprp_Project_DocumentsUploadedList> prpongoing { get; set; }
        //public Clsprp_Project_DocumentsUploadedList()
        //{
        //    prpongoing = new List<Clsprp_Project_DocumentsUploadedList>();
        //}

    }
}