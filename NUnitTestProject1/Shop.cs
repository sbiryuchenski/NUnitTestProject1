using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium.Interactions;


namespace NUnitTestProject1
{
    [TestFixture]
    public class Shop:BaseTest
    {
        
        [Test, Order(1)]
        public void CheckBooks()
        {
            SetTab("Books");
            Check("/books");
        }
        [Test, Order(2)]
        public void CheckComputers()
        {
            SetTab("Computers");
            Check("/computers");
        }
        [Test, Order(3)]
        public void CheckElectronics()
        {
            SetTab("Electronics");
            Check("/electronics");
        }
        [Test, Order(4)]
        public void CheckApparelnShoes()
        {
            SetTab("Apparel & Shoes");
            Check("/apparel-shoes");
        }
        [Test, Order(5)]
        public void CheckDigitalDownloads()
        {
            SetTab("Digital downloads");
            Check("/digital-downloads");
        }
        [Test, Order(6)]
        public void CheckJewelry()
        {
            SetTab("Jewelry");
            Check("/jewelry");
        }
        [Test, Order(7)]
        public void CheckGiftCards()
        {
            SetTab("Gift Cards");
            Check("/gift-cards");
        }
        [Test, Order(8)]
        public void CheckSubDesktops()
        {
            MoveOnTab("Computers");
            SetTab("Desktops");
            Check("/desktops");
        }
        [Test, Order(9)]
        public void CheckSubNotebooks()
        {
            MoveOnTab("Computers");
            SetTab("Notebooks");
            Check("/notebooks");
        }
        [Test, Order(10)]
        public void CheckcSubAccessories()
        {
            MoveOnTab("Computers");
            SetTab("Accessories");
            Check("/accessories");
        }
        [Test, Order(11)]
        public void CheckSubCameraPhoto()
        {
            MoveOnTab("Electronics");
            SetTab("Camera, photo");
            Check("/camera-photo");
        }
        [Test, Order(12)]
        public void CheckSubCellPhones()
        {
            MoveOnTab("Electronics");
            SetTab("Cell phones");
            Check("/cell-phones");
        }

    }
}
