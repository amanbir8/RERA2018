using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models.Agent
{
    public static class OpenAiVision
    {
        private static readonly string ApiKey = ConfigurationManager.AppSettings["OpenAI:ApiKey"];

        public class Verdict
        {
            public bool IsPhotograph { get; set; }
            public double Confidence { get; set; }
            public string Reason { get; set; }
            public bool IsMatch { get; set; }

        }

        //public static async Task<Verdict> ClassifyAsync(byte[] imageBytes, string mime = "image/jpeg")
        //{
        //    var b64 = Convert.ToBase64String(imageBytes);
        //    var dataUrl = $"data:{mime};base64,{b64}";

        //    var payload = new
        //    {
        //        model = "gpt-4o-mini",
        //        temperature = 0,
        //        response_format = new { type = "json_object" },
        //        messages = new object[]
        //        {
        //            new {
        //                role = "system",
        //               content = new object[] {
        //                     new { type = "text", text =
        //                    // STRICT JSON only
        //                    "Return ONLY JSON: {\"category\":\"human_person|animal|document|screenshot|object_scene|illustration\",\"is_photograph\":true|false,\"confidence\":0..1,\"reason\":\"...\"}. " +

        //                    // Task
        //                    "Goal: Accept ONLY photos that show a HUMAN PERSON. Reject everything else (animals, objects, landscapes, documents, screenshots, drawings). " +

        //                    // Definitions (strict)
        //                    "human_person = a real-world photo where a human is clearly visible (face or body). " +
        //                    "animal = photo of animals with no human visible. " +
        //                    "document = scans/photos of IDs, forms, certificates, printed pages (text/tables/stamps/barcodes/QRs/signatures). " +
        //                    "screenshot = screen capture of UI/web/app/slides. " +
        //                    "object_scene = real-world photo of objects/rooms/landscapes/vehicles without a human. " +
        //                    "illustration = drawings, cartoons, logos, CG renders. " +

        //                    // Scanned prints
        //                    "Scanned/printed human portraits are still human_person. " +

        //                    // Output rules
        //                    "Set category precisely. Set is_photograph = true only if category == human_person. " +
        //                    "If any doubt about a HUMAN being present, set category != human_person and is_photograph = false. " +

        //                    // Few-shot guidance
        //                    "Examples: " +
        //                    "1) 'Passport-size portrait of a woman (scanned)' => category=human_person, is_photograph=true. " +
        //                    "2) 'Owl sitting on a branch' => category=animal, is_photograph=false. " +
        //                    "3) 'PAN card scan' => category=document, is_photograph=false. " +
        //                    "4) 'Living room interior, no people' => category=object_scene, is_photograph=false. " +
        //                    "5) 'Screenshot of a website' => category=screenshot, is_photograph=false. " +

        //                    // Be strict
        //                    "Be strict: if unsure whether a HUMAN is visible, do NOT use human_person."
        //                }
        //               }
        //            },
        //            new {
        //                role = "user",
        //                content = new object[] {
        //                    new { type = "text", text = "Is this a real-world photograph (not a document/screenshot)?" },
        //                    new { type = "image_url", image_url = new { url = dataUrl } }
        //                }
        //            }
        //        }
        //    };

        //    var req = new HttpRequestMessage(HttpMethod.Post, "/v1/chat/completions");
        //    req.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApiKey);
        //    req.Content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

        //    var http = MvcApplication.OpenAiHttp;
        //    HttpResponseMessage res;
        //    string json;

        //    try
        //    {
        //        res = await http.SendAsync(req);
        //        json = await res.Content.ReadAsStringAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Verdict { IsPhotograph = false, Confidence = 0, Reason = "Vision call failed: " + ex.Message };
        //    }

        //    if (!res.IsSuccessStatusCode)
        //        return new Verdict { IsPhotograph = false, Confidence = 0, Reason = "Vision check failed: " + res.StatusCode };

        //    try
        //    {
        //        // Chat completions -> choices[0].message.content (string JSON)
        //        var root = JObject.Parse(json);
        //        var content = (string)root["choices"]?[0]?["message"]?["content"] ?? "{}";
        //        var parsed = JObject.Parse(content);

        //        return new Verdict
        //        {
        //            IsPhotograph = (bool?)parsed["is_photograph"] ?? false,
        //            Confidence = (double?)parsed["confidence"] ?? 0,
        //            Reason = (string)parsed["reason"] ?? "No reason"
        //        };
        //    }
        //    catch
        //    {
        //        return new Verdict { IsPhotograph = false, Confidence = 0, Reason = "Unparseable response from vision check" };
        //    }
        //}


        public static async Task<Verdict> ClassifyDocumentAsync(byte[] fileBytes, string mime, string expectedDocName)
        {
            var b64 = Convert.ToBase64String(fileBytes);
            var dataUrl = $"data:{mime};base64,{b64}";

            var payload = new
            {
                model = "gpt-4o-mini",
                temperature = 0,
                response_format = new { type = "json_object" },
                messages = new object[]{
            new {
                role = "system",
                content = new object[] {
                    new { type = "text", text =
                        "You are a document classifier. Return ONLY JSON: " +
                        "{\"is_match\":true|false,\"confidence\":0..1,\"detected_type\":\"...\",\"reason\":\"...\"}. " +

                        "Your goal: determine if the uploaded image or PDF matches the expected document type. " +
                        "Expected type: '" + expectedDocName + "'. " +

                        "Common document types include: PAN Card, Aadhaar Card, Passport, Driving Licence, Rent Agreement, Photograph, etc. " +

                        "Look for keywords, titles, government logos, layout, text structure, and visual indicators. " +
                        "If the file clearly matches the expected type, set is_match=true. " +
                        "If it’s a different type, unclear, or contains unrelated information, set is_match=false. " +
                        "If unsure, prefer false. " +

                        "Example outputs: " +
                        "1) PAN card photo uploaded for expectedDocName='PAN Card' => is_match=true, detected_type='PAN Card'. " +
                        "2) Aadhaar card uploaded for expectedDocName='PAN Card' => is_match=false, detected_type='Aadhaar Card'. " +
                        "3) Rent agreement uploaded for expectedDocName='Rent Agreement' => is_match=true, detected_type='Rent Agreement'. " +
                        "4) Passport uploaded for expectedDocName='Photograph' => is_match=false, detected_type='Passport'."
                    }
                }
            },
                //new {
                //    role = "system",
                //    content = new object[] {
                //        new { type = "text", text =
                //            "You are a document classifier. Return ONLY JSON: " +
                //            "{\"is_match\":true|false,\"confidence\":0..1,\"detected_type\":\"...\",\"reason\":\"...\"}. " +

                //            "Your job: determine ONLY the high-level document category: " +
                //            "PAN Card, Aadhaar Card, Passport, Driving Licence, Rent Agreement, Photograph, etc. " +

                //            // IMPORTANT FIX – do NOT check individual/company PAN differences
                //            "Do NOT check document subtypes such as: Individual PAN vs Company PAN, old vs new formats, address differences, gender, date of birth, issuing authority, etc. " +
                //            "You only classify the TYPE of document, not the HOLDER TYPE. " +

                //            "If the uploaded file is any valid PAN Card (individual, company, HUF, firm, trust), " +
                //            "and the expected type contains the words 'PAN Card', consider it a MATCH. " +

                //            "Rules: " +
                //            "• Match if the document visually matches the expected CATEGORY. " +
                //            "• Ignore whether the PAN belongs to a male/female/company/HUF/etc. " +
                //            "• If the document clearly belongs to another category, set is_match=false. " +
                //            "• If unsure, prefer false. " +

                //            "Examples: " +
                //            "1) Expected='PAN Card (Individual)' and uploaded PAN Card of a company => is_match=true, detected_type='PAN Card'. " +
                //            "2) Expected='PAN Card' and uploaded Aadhaar => is_match=false, detected_type='Aadhaar Card'. " +
                //            "3) Expected='Rent Agreement' and uploaded rent agreement scan => is_match=true. " +
                //            "4) Expected='Photograph' and uploaded passport => is_match=false."
                //        }
                //    }
                //},

                new {
                    role = "user",
                    content = new object[] {
                        new { type = "text", text = $"Check if this uploaded file is a {expectedDocName}." },
                        new { type = "image_url", image_url = new { url = dataUrl } }
                    }
                }
                    }
        };

            var req = new HttpRequestMessage(HttpMethod.Post, "/v1/chat/completions");
            req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
            req.Content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            var http = MvcApplication.OpenAiHttp;
            HttpResponseMessage res;
            string json;

            try
            {
                res = await http.SendAsync(req);
                json = await res.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return new Verdict { IsMatch = false, Confidence = 0, Reason = "OpenAI API call failed: " + ex.Message };
            }

            if (!res.IsSuccessStatusCode)
                return new Verdict { IsMatch = false, Confidence = 0, Reason = "Document check failed: " + res.StatusCode };

            try
            {
                var root = JObject.Parse(json);
                var content = (string)root["choices"]?[0]?["message"]?["content"] ?? "{}";
                var parsed = JObject.Parse(content);

                bool isMatch = (bool?)parsed["is_match"] ?? false;
                double confidence = (double?)parsed["confidence"] ?? 0.0;
                string reason = (string)parsed["reason"] ?? "No reason";
                string detectedType = (string)parsed["detected_type"] ?? "unknown";

                return new Verdict
                {
                    IsMatch = isMatch,
                    Confidence = confidence,
                    Reason = $"Detected: {detectedType}. {reason}"
                };
            }
            catch (Exception ex)
            {
                return new Verdict { IsMatch = false, Confidence = 0, Reason = "Unparseable response: " + ex.Message };
            }
        }


    }
}