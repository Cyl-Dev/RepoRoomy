using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Roomy.Utils
{
    public static class Extensions
    {
        public static string HashMD5(this string value)
        {

            byte[] textBytes = System.Text.Encoding.Default.GetBytes(value);
            try
            {
                MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();
                byte[] hash = crypto.ComputeHash(textBytes);

                string result = "";
                foreach (byte b in hash)
                {
                    if (b < 16)
                        result += "0" + b.ToString("x");
                    else
                        result += b.ToString("x");
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        public static void DisplaySuccessMessage(this Controller controller, string Message)
        {
            controller.TempData["Message"] = Message;
            controller.TempData["MessageType"] = "success";
        }

        public static void DisplayErrorMessage(this Controller controller, string Message)
        {
            controller.TempData["Message"] = Message;
            controller.TempData["MessageType"] = "error";
        }

        public static void DisplayWarningMessage(this Controller controller, string Message)
        {
            controller.TempData["Message"] = Message;
            controller.TempData["MessageType"] = "warning";
        }

        public static void DisplayInfoMessage(this Controller controller, string Message)
        {
            controller.TempData["Message"] = Message;
            controller.TempData["MessageType"] = "info";
        }

    }
}