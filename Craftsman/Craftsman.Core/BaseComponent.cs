﻿using Craftsman.Core.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core
{
    public class BaseComponent : IComponent
    {
        protected IWebDriver _driver;
        protected By _by;

        public BaseComponent(IWebDriver driver, By by)
        {
            this._driver = driver;
            this._by = by;
        }
        public IWebElement OriginalElement
        {
            get
            {
                if (this._driver != null)
                {
                    return this._driver.FindElement(this._by);
                }
                throw new Exception("Can not get WebElement!");
            }
        }

        public List<IWebElement> OriginalElements
        {
            get
            {
                if (this._driver != null)
                {
                    return this._driver.FindElements(this._by).ToList();
                }
                throw new Exception("Can not get WebElement!");
            }
        }
        public bool IsClickable()
        {
            throw new NotImplementedException();
        }

        public bool IsExist()
        {
            throw new NotImplementedException();
        }

        public bool IsVisible()
        {
            throw new NotImplementedException();
        }

        
        public void Waiting(For type, TimeSpan timeout)
        {
            switch (type)
            {
                case For.Exist:
                    WaitSelector.WaitingFor_ElementExists(this._driver, this._by, timeout);
                    break;
                case For.Visible:
                    WaitSelector.WaitingFor_ElementIsVisible(this._driver, this._by, timeout);
                    break;
                case For.Clickable:
                    WaitSelector.WaitingFor_ElementToBeClickable(this._driver, this._by, timeout);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void Waiting(For type)
        {
            Waiting(type, TimeSpan.FromSeconds(30));
        }
    }
}