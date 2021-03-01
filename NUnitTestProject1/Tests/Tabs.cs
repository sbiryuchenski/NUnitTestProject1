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
    [TestFixture, Description("Здесь проверяются по очереди вкладки и всплывающие пункты меню при наведении")]
    public class Tabs:BaseTest
    {
        [Test, Order(1), Description("Проверка пункта BOOKS")]
        public void CheckBooks()
        {
            SetTab("Books");
            Check("/books");
        }
        [Test, Order(2), Description("Проверка пункта COMPUTERS")]
        public void CheckComputers()
        {
            SetTab("Computers");
            Check("/computers");
        }
        [Test, Order(3), Description("Проверка пункта ELECTRONICS")]
        public void CheckElectronics()
        {
            SetTab("Electronics");
            Check("/electronics");
        }
        [Test, Order(4), Description("Проверка пункта APPAREL & SHOES")]
        public void CheckApparelnShoes()
        {
            SetTab("Apparel & Shoes");
            Check("/apparel-shoes");
        }
        [Test, Order(5), Description("Проверка пункта DOWNLOADS")]
        public void CheckDigitalDownloads()
        {
            SetTab("Digital downloads");
            Check("/digital-downloads");
        }
        [Test, Order(6), Description("Проверка пункта JEWELRY")]
        public void CheckJewelry()
        {
            SetTab("Jewelry");
            Check("/jewelry");
        }
        [Test, Order(7), Description("Проверка пункта  GIFT CARDS")]
        public void CheckGiftCards()
        {
            SetTab("Gift Cards");
            Check("/gift-cards");
        }
        [Test, Order(8), Description("Проверка подпункта Desktops")]
        virtual public void CheckSubDesktops()
        {
            MoveOnTab("Computers");
            SetTab("Desktops");
            Check("/desktops");
        }
        [Test, Order(9), Description("Проверка подпункта Notebooks")]
        virtual public void CheckSubNotebooks()
        {
            MoveOnTab("Computers");
            SetTab("Notebooks");
            Check("/notebooks");
        }
        [Test, Order(10), Description("Проверка подпункта Accessories")]
        virtual public void CheckcSubAccessories()
        {
            MoveOnTab("Computers");
            SetTab("Accessories");
            Check("/accessories");
        }
        [Test, Order(11), Description("Проверка подпункта Camera, photo")]
        virtual public void CheckSubCameraPhoto()
        {
            MoveOnTab("Electronics");
            SetTab("Camera, photo");
            Check("/camera-photo");
        }
        [Test, Order(12), Description("Проверка подпункта Cell phones")]
        virtual public void CheckSubCellPhones()
        {
            MoveOnTab("Electronics");
            SetTab("Cell phones");
            Check("/cell-phones");
        }

    }
}
