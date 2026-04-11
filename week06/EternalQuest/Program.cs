using System;

/*
Creativity features exceeding core requirements:

1. Level System with Titles - As users earn points, they progress through levels:
   Beginner (0-99 pts), Apprentice (100-499), Champion (500-999), 
   Master (1000-1999), Legend (2000+). Displayed with player info to provide
   visual progress and motivation. Uses simple if-else logic to determine level.

2. Negative Goals - Created NegativeGoal class demonstrating polymorphism.
   Inherits from Goal base class but overrides RecordEvent() to return
   NEGATIVE points. Allows users to track bad habits they want to stop.
   When they record a slip-up, they LOSE points instead of gaining them.
   Example: "Don't eat junk food" - lose 50 points per occurrence.
   Helps users break negative patterns through gamification.

3. Streak Counter - Tracks consecutive days user has recorded any goal.
   Displays current streak with fire emoji. Awards bonus points for milestones:
   7 days = 100 bonus points, 14 days = 250 points, 30 days = 500 points.
   Encourages daily engagement and habit formation. Uses DateTime to track
   last recorded date and calculate streaks. Streak data is saved/loaded
   with goals so progress persists across sessions.

All features use polymorphism (NegativeGoal overrides methods), inheritance
(all goals derive from Goal base class), and encapsulation (private variables)
while adding practical value to enhance user experience and motivation.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}