using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus on your breathing.")
    { }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        bool breatheIn = true;
        while (DateTime.Now < endTime)
        {
            if (breatheIn)
            {
                Console.Write("Breathe in...  ");
                ShowCountdown(4);
            }
            else
            {
                Console.Write("Breathe out... ");
                ShowCountdown(4);
            }
            breatheIn = !breatheIn;
        }

        DisplayEndingMessage();
    }
}
