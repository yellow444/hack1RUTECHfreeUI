using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace hack1RUTECHfreeUI.Web
{
    public class api
    {
        public class Users
        {
            [JsonProperty("login")]
            public string Login { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }

            [JsonProperty("F")]
            public string F { get; set; }

            [JsonProperty("I")]
            public string I { get; set; }

            [JsonProperty("O")]
            public string O { get; set; }
            [JsonProperty("country")]
            public string Country { get; set; }
            [JsonProperty("registered")]
            public string Registered { get; set; }

            [JsonProperty("error")]
            public string Error { get; set; }

            [JsonProperty("authorized")]
            public string Authorized { get; set; }

            [JsonProperty("loaded")]
            public string Loaded { get; set; }

            [JsonProperty("changed")]
            public string Changed { get; set; }

            [JsonProperty("phone")]
            public string Phone { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("position")]
            public string Position { get; set; }

            [JsonProperty("org")]
            public string Org { get; set; }
        }
        public partial class ActivatedTickets
        {
            [JsonProperty("uid_ticket")]
            public Guid UidTicket { get; set; }

            [JsonProperty("activated")]
            public bool Activated { get; set; }

            [JsonProperty("event")]
            public string Event { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("add")]
            public string Add { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }
        }

        public class Inwike2020
        {
            public string name;
            public string surnam;
            private string patronymic;
            public string email;
            public string password;
            private string domain;
            public string uid_ticket;
            public Inwike2020(string _name, string _surnam, string _patronymic, string _email, string _password, string _domain = "http://9eb1d4ffde20.ngrok.io/Inwike2020/hs/Inwike/ID/")
            {
                name = _name == null ? "max" : _name;
                surnam = _surnam == null ? "sim" : _patronymic;
                patronymic = _patronymic == null ? "val" : _patronymic;
                email = _email;
                password = _password;
                domain = _domain;
            }

            private static string BuildQueryData(Dictionary<string, string> param)
            {
                if (param == null)
                {
                    return "";
                }

                StringBuilder b = new StringBuilder();
                foreach (KeyValuePair<string, string> item in param)
                {
                    b.Append(string.Format("&{0}={1}", item.Key, WebUtility.UrlEncode(item.Value)));
                }

                try { return b.ToString().Substring(1); }
                catch (Exception) { return ""; }
            }

            private static string BuildJSON(Dictionary<string, string> param)
            {
                if (param == null)
                {
                    return "";
                }

                List<string> entries = new List<string>();
                foreach (KeyValuePair<string, string> item in param)
                {
                    entries.Add(string.Format("\"{0}\":\"{1}\"", item.Key, item.Value));
                }

                return "{" + string.Join(",", entries) + "}";
            }

            private string Query(string method, string function, Dictionary<string, string> param = null, bool auth = false, bool json = false)
            {
                string paramData = BuildJSON(param);// json ? BuildJSON(param) : BuildQueryData(param);
                string url = function + ((method == "GET" && !string.IsNullOrEmpty(paramData)) ? "?" + paramData : "");
                string postData = (method != "GET") ? paramData : "";

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(domain + url);
                webRequest.Method = method;

                try
                {
                    if (!string.IsNullOrEmpty(postData))
                    {
                        webRequest.ContentType = json ? "application/json" : "application/x-www-form-urlencoded";
                        byte[] data = Encoding.UTF8.GetBytes(postData);
                        using (Stream stream = webRequest.GetRequestStream())
                        {
                            stream.Write(data, 0, data.Length);
                        }
                    }

                    using (WebResponse webResponse = webRequest.GetResponse())
                    using (Stream str = webResponse.GetResponseStream())
                    using (StreamReader sr = new StreamReader(str))
                    {
                        return sr.ReadToEnd();
                    }
                }
                catch (WebException wex)
                {
                    using (HttpWebResponse response = (HttpWebResponse)wex.Response)
                    {
                        if (response == null)
                        {
                            throw;
                        }

                        using (Stream str = response.GetResponseStream())
                        {
                            using (StreamReader sr = new StreamReader(str))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }

            public string reg()
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param["login"] = email;
                param["password"] = password;
                param["F"] = patronymic;
                param["I"] = name;
                param["O"] = surnam;
                return Query("POST", "reg", param, true);
            }

            public string aut()
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param["login"] = email;
                param["password"] = password;
                return Query("POST", "aut", param, true);
            }

            public string get_photo()
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param["login"] = email;
                return Query("POST", "get_photo", param, true);
            }

            public string upload_photo(string file)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param["login"] = email;
                param["password"] = password;
                param["file"] = file;
                return Query("POST", "upload_photo", param, true);
            }

            public string change_user_data(string organization, string position, string country)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param["login"] = email;
                param["organization"] = organization;
                param["position"] = position;
                param["country"] = country;
                return Query("POST", "change_user_data", param, true);
            }

            public string add_ticket(string _uid_ticket)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param["login"] = email;
                param["uid_ticket"] = _uid_ticket;
                uid_ticket = _uid_ticket;
                return Query("GET", "add_ticket", param, true);
            }
            public string act_ticket(string uid_ticket)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param["login"] = email;
                param["uid_ticket"] = uid_ticket;
                return Query("GET", "act_ticket", param, true);
            }
            public string get_tickets()
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param["login"] = email;
                return Query("GET", "get_tickets", param, true);
            }
            public string get_rooms()
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param["login"] = email;
                return Query("GET", "get_tickets", param, true);
            }
            public string get_user_data()
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param["login"] = email;
                return Query("GET", "get_user_data", param, true);
            }
        }
    }
}