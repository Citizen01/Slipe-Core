﻿using MultiTheftAuto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTASharedWrapper
{
    public class SharedPlayer: Element
    {
        public SharedPlayer(MTAElement mtaElement) : base(mtaElement)
        {
        }

        public virtual string Name
        {
            get
            {
                return Shared.GetPlayerName(element);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public static SharedPlayer GetFromName(string name)
        {
            return (SharedPlayer) ElementManager.Instance.GetElement(Shared.GetPlayerFromName(name));
        }
    }
}
