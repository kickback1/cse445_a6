using System;
using System.Web.Services;

namespace Assignment5Web
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TextService : WebService
    {
        // this method takes a string and returns it reversed
        [WebMethod]
        public string ReverseText(string input)
        {
            // convert string to char array
            char[] chars = input.ToCharArray();

            // reverse the array
            Array.Reverse(chars);

            // turn it back into a string and return it
            return new string(chars);
        }
    }
}