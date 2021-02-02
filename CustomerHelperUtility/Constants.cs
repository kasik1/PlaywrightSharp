using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerHelperUtility
{
    public class Constants
    {
        static ConfigReader config = new ConfigReader();
        public static int ElementLookupTimeOut
        {
            get
            {
                return int.Parse(config.ElementLookupTimeOut);
            }
            set { }
        }

        public static int PageLoadTimeOut
        {
            get
            {
                return int.Parse(config.PageLoadTimeOut);
            }
            set { }
        }

        public static int MaxTimeOut
        {
            get
            {
                return int.Parse(config.MaxTimeOut);
            }
            set { }
        }

        public static int MinTimeOut
        {
            get
            {
                return int.Parse(config.MinTimeOut);
            }
            set { }
        }

        public static int BOTimeOut
        {
            get
            {
                return int.Parse(config.BOTimeOut);
            }
            set { }
        }

        public static int ClientCallTimeOut
        {
            get
            {
                return int.Parse(config.ClientCallTimeOut);
            }
            set { }
        }
    }
}
