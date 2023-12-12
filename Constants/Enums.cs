using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldCupManagementSystem.Constants
{
   public enum Regions
    {
        Europe = 1,
        Asia = 2,
        Africa = 3,
        America = 4,
        Australia = 5,
        Antarctida = 6
    }

    public enum Mode
    {
        Edit,
        Insert,
        Readonly
    }
}