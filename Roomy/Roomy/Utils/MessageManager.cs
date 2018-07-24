using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roomy.Utils
{
    public static class MessageManager
    {
        public static void DisplaySuccessMessage(TempDataDictionary tdd, string Message)
        {
            tdd["Message"] = Message;
            tdd["MessageType"] = "success";
        }

        public static void DisplayErrorMessage(TempDataDictionary tdd, string Message)
        {
            tdd["Message"] = Message;
            tdd["MessageType"] = "danger";
        }

        public static void DisplayWarningMessage(TempDataDictionary tdd, string Message)
        {
            tdd["Message"] = Message;
            tdd["MessageType"] = "warning";
        }

        public static void DisplayInfoMessage(TempDataDictionary tdd, string Message)
        {
            tdd["Message"] = Message;
            tdd["MessageType"] = "info";
        }
    }
}