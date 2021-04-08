using System;
using LanDocsUITest.LanDocs3Client.Exceptions;

namespace LanDocsUITest.LanDocs3Client.Locators
{
    /// <summary>
    /// Базовый класс для элементов управления системы. Описывает общий функционал.
    /// </summary>
    abstract class BaseControl
    {
        protected String ControlName;
        const int Timeout = 2*1000*60; //2 минуты
        const int WaitTime = 25*1000; //таймаут TryFind по умолчанию

        protected BaseControl(String name)
        {
            ControlName = name;
        }

        /// <summary>
        /// Метод циклично проверяет значение IsPresent в течение заданного TimeOut.
        /// </summary>
        /// <exception cref="ObjectNotFoundException">Исключение возвращается, 
        /// если IsPresent False в течение Timeot.</exception>
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
                    throw new ObjectNotFoundException(ControlName + " не открыто");
                }

               count++;
            }
        }

        /// <summary>
        /// Метод проверяет существование элемента. 
        /// </summary>
        protected abstract bool IsPresent();
    }
}
