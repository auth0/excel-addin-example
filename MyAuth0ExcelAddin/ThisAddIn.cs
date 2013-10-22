using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;
using Auth0.Windows;
using System.Threading.Tasks;

namespace MyAuth0ExcelAddin
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {

            var auth0 = new Auth0Client(
                "mdocs.auth0.com",
                "kgKQd16fCm2ZH5w5UeiRHvUY0O2Z0gbK",
                "rEwJ0hKCocy4fk7OXdrsuQJRQwiBPLqqMBONiwnIWN2BFnuztthdeGsPeXc2Bh8X");
     
            auth0.LoginAsync(null)
                 .ContinueWith(Authenticated, TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void Authenticated(Task<Auth0User> r) 
        { 
            MessageBox.Show("hello " + r.Result.Profile["email"] );

            //Call your HTTP API with a Header, "Authorization": "Bearer " + r.Result.IdToken
            
            /* 
                Use t.Result to do wonderful things, e.g.: 
                    - get user email => t.Result.Profile["email"].ToString()
                    - get facebook/google/twitter/etc access token => t.Result.Profile["identities"][0]["access_token"]
                    - get Windows Azure AD groups => t.Result.Profile["groups"]
                    - etc.
            */ 
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
