# Form-M Debug Table

| Button/Link (UI) | View | JS/Event | Controller Action | Core Helper/Method Calls | Next/Result |
|---|---|---|---|---|---|
| Open Form-M | `Views/Complaint/RegComplaintFormM.cshtml` | Page GET | `RegComplaintFormM()` | `DisplayComplaintProfileDetail`, `Display_ComplaintFormM_Registration_StepI`, `Display_ComplaintFormM_FactsOfTheCase_UploadedFileExtract_ByProfileID_StepI`, `fnExtractSubStringUnRegdComplaint` | Step-1 form loaded |
| Save/Update (main Step-1) | same | `<input type="submit" id="BtnMainform">` | `RegComplaintFormM(smodel)` (POST) | `Verify_ComplaintFormM_FactsOfTheCase_Documents_ByProfileID`, `fnSaveSubStringUnRegdComplaint`, `Add_ComplaintFormM_Registration_StepI` or `Update_ComplaintFormM_Registration_StepI`, `Get_ComplaintFormM_FlagStep` | Redirect Step1/2/3/4 |
| Reset (Step-1) | same | ActionLink | `RegComplaintFormM()` | Normal GET load path | Reload Step-1 |
| Add/View more Complainant | `Views/Complaint/RegComplaintFormM.cshtml` | click `#modalOpenerButton` (AJAX GET) | `RegAdditionalComplaintFormM()` | `Display_Complainant_Detail`, `Display_ComplaintFormM_Flag_RegStep` | Modal opens |
| Save additional complainants | `Views/Complaint/RegAdditionalComplaintFormM.cshtml` | click `#saveOrder` (AJAX POST) | `SaveComplainantFormMDetail(order[])` | `Add_FormM_Complainant` (loop) | JSON success/fail |
| Delete additional complainant | same | click `#deleteButton` (AJAX GET) | `Delete_AdditionalComplaintFormM(...)` | `Delete_FormM_Complainant` | Row removed |
| Add/View more Respondent | `Views/Complaint/RegComplaintFormM.cshtml` | click `#modalOpenerRespButton` (AJAX GET) | `RegAdditionalRespondentFormM()` | `Display_Respondent_Detail`, `Display_ComplaintFormM_Flag_RegStep` | Modal opens |
| Save additional respondents | `Views/Complaint/RegAdditionalRespondentFormM.cshtml` | click `#saveOrder` (AJAX POST) | `SaveRespondentFormMDetail(order[])` | `Add_FormM_Respondent` (loop) | JSON success/fail |
| Delete additional respondent | same | click `#deleteButton` (AJAX GET) | `Delete_AdditionalRespondentFormM(...)` | `Delete_FormM_Respondent` | Row removed |
| Upload Facts-of-Case PDF (Step-1) | `Views/Complaint/RegComplaintFormM.cshtml` | click upload trigger (AJAX POST) | `FactsCase_FormM_DocumentUpload(...)` | file validations + `SaveComplaintFormM_FactsCase_Documents` | statusCode JSON |
| View Facts file | same | click `.display-factscase-document` / `.display-factscase-uploaded-document` | `ComplaintFormMFactsCaseFileDetail(...)` / `ComplaintFormMFactsCaseCurrentFileDetail(...)` | fetch detail/view model | Modal file preview |
| Delete Facts file | same | click `.delete-factscase-document` | `Delete_FactsCase_FormM_Document(...)` | delete method in model layer | UI toggles upload/view rows |
| Download Facts file | same | click `.download-factscase-document` / `.download-factscase-uploaded-document` | `Download_FactsCase_FormM_File(...)` / `Download_FactsCase_FormM_CurrentFile(...)` | returns base64 content | Browser download |
| Open Step-2 Documents | `Views/Complaint/RegComplaintEncldocM.cshtml` | Page GET | `RegComplaintEncldocM()` | `Display_ComplaintFormM_Documents_ByComplaintFormM_ID` | Step-2 loaded |
| Upload enclosure doc | same | upload form AJAX POST | `ComplaintFormMDocumentFormUpload(...)` | `Display_Master_Complaint_DocumentsByComplaintFormID`, `Display_ComplaintFormM_Documents_ByDocCodeInfo_ComplaintFormM_ID`, `RegexRemove`, `SaveComplaintFormDocuments`, `Add_ComplaintFormM_Documents` | statusCode JSON |
| Delete enclosure doc | same | ActionLink delete | `Delete_ComplaintEncldocMDocument(...)` | `Delete_ComplaintFormM_Document` | Redirect Step-2 |
| Proceed from Step-2 | same | submit `FormProceed` | `RegComplaintEncldocFormM()` | `Update_Check_ComplaintFormM_Documents` | If complete -> Step-3 payment; else error message |
| Step-3 Payment | payment module | redirect | `ComplaintPayment/RequestPaymentFormM` | payment-controller flow | payment done |
| Open Step-4 Verification | `Views/Complaint/RegComplaintVerificationM.cshtml` | Page GET | `RegComplaintVerificationM()` | `Display_ComplaintFormM_Flag_RegStep` | verify screen |
| Final Submit (Step-4) | same | submit `BtnMainform` | `RegComplaintVerificationM(smodel)` (POST) | `ValidateComplaintFormM_AgreeDetails`, `UpdateComplaintFormM_AgreeDetails`, `UserManager.SendEmailAsync`, `Display_ComplaintFormM_Flag_RegStep` | diary number + final state |
| Print Form-M | same | ActionLink | `ComplaintPrintForm/Print_ComplaintFormMcodeDetails` | print module calls | PDF/print view |
| State/District/Subdivision dropdowns | Step-1 + modal views | AJAX | `GetState`, `GetDistrictByStateId`, `GetSubdivisionByDistId` | master lookup methods | dropdown bind |
| Fetch project/agent/allottee by RERA No. | Step-1 | AJAX | `GetProjectRealestateAgentAllotteeNameFromMN` | lookup method | auto-fill related fields |
