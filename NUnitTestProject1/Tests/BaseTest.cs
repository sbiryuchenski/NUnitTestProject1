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

namespace NUnitTestProject1
{
    /// <summary>
    /// Базовый класс тест кейса
    /// </summary>
    public abstract class BaseTest
    {
        protected Context Context { get; }

        BaseTest(Context contex)
        {
            Context = contex;
        }
    }
}