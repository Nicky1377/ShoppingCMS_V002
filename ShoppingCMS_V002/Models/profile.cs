using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class profile
    {
        public string id_Admin { get; set; }
        public string ad_type_name { get; set; }
        public string ad_username { get; set; }
        public string ad_password { get; set; }
        public string ad_firstname { get; set; }
        public string ad_lastname { get; set; }
        public string ad_avatarprofile { get; set; }
        public string ad_email { get; set; }
        public string ad_phone { get; set; }
        public string ad_mobile { get; set; }
        public string ad_has2stepSecurity { get; set; }
        public string ad_isActive { get; set; }
        public string ad_isDelete { get; set; }
        public string ad_lastseen { get; set; }
        public string ad_lastlogin { get; set; }
        public string ad_loginIP { get; set; }
        public string ad_regdate { get; set; }
        public string ad_personalColorHexa { get; set; }
        public string AdminModeID { get; set; }
        public string ad_NickName { get; set; }
    }
}