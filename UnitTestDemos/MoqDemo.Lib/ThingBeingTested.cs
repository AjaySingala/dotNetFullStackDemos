﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqDemo.Lib
{
    public class ThingBeingTested
    {
        private readonly IThingDependency _thingDependency;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ThingBeingTested(IThingDependency thingDependency)
        {
            _thingDependency = thingDependency;
        }

        public string X()
        {
            var fullName = _thingDependency.JoinUpper(FirstName, LastName);

            return $"{fullName} = {_thingDependency.Meaning}";
        }

        public bool ChargeTheCard(int amt, Card crd)
        {
            return _thingDependency.Charge(amt, crd);
        }
    }
}
