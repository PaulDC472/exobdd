﻿using System.Diagnostics;

namespace CrossCutting
{
    public static class Telemetry
    {
        //...

        // Name it after the service name for your app.
        // It can come from a config file, constants file, etc.
        public static readonly ActivitySource MyActivitySource = new("MonAppliWeb");

        //...
    }

}