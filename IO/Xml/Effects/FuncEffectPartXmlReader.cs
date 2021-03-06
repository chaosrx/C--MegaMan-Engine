﻿using System;
using System.Xml.Linq;
using System.Linq;
using MegaMan.Common.Entities.Effects;
using MegaMan.Common;

namespace MegaMan.IO.Xml.Effects
{
    internal class FuncEffectPartXmlReader : IEffectPartXmlReader
    {
        public string NodeName
        {
            get
            {
                return "Func";
            }
        }

        public IEffectPartInfo Load(XElement partNode)
        {
            return new FuncEffectPartInfo() {
                Statements = partNode.Value.Split(';').Where(st => !string.IsNullOrEmpty(st.Trim()))
            };
        }
    }
}
