using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;
using System.Timers;


public class CountDown
{
    private static Timer countDown;

    public static void timer()
    {
        countDown = new System.Timers.Timer();
        countDown.Interval = 1000;

        countDown.Enabled = true;
    }

}