using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace LanDocsUITest.LanDocs.Locators
{
    /// <summary>
    /// TODO Summary description 
    /// </summary>
    class LanDocsApplication
    {

        /// <summary>
        /// TODO Summary description 
        /// </summary>
        public static LoginWindow Start()
        {
            ApplicationUnderTest.Launch(@"C:\Program Files (x86)\LanDocs\Client3\LanDocs3.exe");
            return new LoginWindow();
        }
    }
}
