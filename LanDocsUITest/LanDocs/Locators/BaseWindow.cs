using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LanDocsUITest.LanDocs.Exceptions;

namespace LanDocsUITest.LanDocs.Locators
{
    /// <summary>
    /// TODO Summary description 
    /// </summary>
    abstract class BaseWindow
    {
        protected String WindowName;
        const int Timeout = 2*1000*60; //2 минуты
        const int WaitTime = 25*1000; //таймаут TryFind по умолчанию

        protected BaseWindow(String name)
        {
            WindowName = name;
        }

        /// <summary>
        /// TODO Summary description 
        /// </summary>
        protected void Wait()
        {

            
            int count = 0;

            while (true)
            {
                if (IsPresent())
                {
                    return;
                }

                if (count * WaitTime > Timeout)
                {
                    throw new ObjectNotFoundException(WindowName + " не открыто");
                }


               count++;
            }
        }

        /// <summary>
        /// TODO Summary description 
        /// </summary>
        protected abstract Boolean IsPresent();
    }
}
