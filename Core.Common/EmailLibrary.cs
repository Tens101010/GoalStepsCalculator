using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class EmailLibrary
    {
        public void SendEmail(string emailAddress, string hereIsYourReceipt)
        {
            //If a valid email address is provided, send an email
            try
            {
                // Send email
            }
            catch (InvalidOperationException)
            {
                // log
                throw;
            }
        }
    }
}
