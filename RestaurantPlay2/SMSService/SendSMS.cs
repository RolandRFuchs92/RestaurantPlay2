using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPlay2
{
    public partial class SendSMS
    {
        private string api{get;set; }
        private string to { get; set; }
        private string from { get; set; }
        private string delivery { get; set; }
        private string message { get; set; }
        private string response { get; set; }

        public void SMSAdmin(string Formfrom , string Formmessage)
        {
            //assigning Data
            api = "FukUwrKiTDmf9rxeRzIciQ==";
            to = "+27837074655";
            from = Formfrom;
            message = Formmessage;
            
            //creating a dictionary to store all the parameters that needs to be sent
            Dictionary<string, string> Params = new Dictionary<string, string>();

            //adding the parameters to the dictionary
            Params.Add("content", message);
            Params.Add("to", to);
            if (from != "") { Params.Add("from", from); }
            
            if (api != "")
            {
                response = Api.SendSMS(api, Params);
            }
            else
            {
              
            }
        }
    }
}
