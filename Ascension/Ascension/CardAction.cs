﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public abstract class CardAction
    {

        public CardAction()
        { }
        
        abstract public void doAction();
        abstract public String printAction();
    }
}
