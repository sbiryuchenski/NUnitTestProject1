﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium.Interactions;
using System;

namespace NUnitTestProject1
{
    class CheckBox:AbstractElement
    {
        public CheckBox(IWebDriver setdriver) { driver = setdriver; }
    }
}
