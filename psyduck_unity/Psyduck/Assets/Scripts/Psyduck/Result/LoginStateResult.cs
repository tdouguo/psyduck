﻿using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psyduck
{
    public class LoginStateResult : StateResult
    {
        public bool isRequest => state == "request";
        public bool isProcess => state == "process";
        public bool isScan => state == "scan";
        public bool isVerifyGet => state == "verify_get";
        public bool isVerifyGetHint => state == "verify_get_hint";
        public bool isVerifySet => state == "verify_set";
        public bool isVerifySetHint => state == "verify_set_hint";
        public bool isWaitForDone => state == "wait_for_done";
        public string qrUrl
        {
            get
            {
                if (isScan)
                {
                    return jsonResult.ToString();
                }
                return "";
            }
        }
        public string message => jsonResult != null ? jsonResult.ToString() : "";
    }
}
