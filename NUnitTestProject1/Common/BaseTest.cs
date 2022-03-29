using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.IO;
using OpenQA.Selenium.Interactions;
using System;
using Shop.Test;

namespace NUnitTestProject1.Common
{
    /// <summary>
    /// Базовый класс тест кейса
    /// </summary>
    public abstract partial class BaseTest
    {
        public Context Context;

        //public BaseTest(Context contex)
        //{
        //    Context = contex;
        //}
    }
}