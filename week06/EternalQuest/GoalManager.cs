using System;
using System.Collections.Generic;
using System.IO;

// Manages all goals and user interaction
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _streak;
    private string _lastRecordedDate;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _streak = 0;
        _lastRecordedDate = "";
    }

    public void Start()
    {
        string choice = "";
        
        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Level: {GetLevel()}");
        
        if (_streak > 0)
        {
            Console.WriteLine($"Current Streak: {_streak} days 🔥");
        }
    }

    // CREATIVITY FEATURE: Level system
    private string GetLevel()
    {
        if (_score < 100) return "Beginner";
        else if (_score < 500) return "Apprentice";
        else if (_score < 1000) return "Champion";
        else if (_score < 2000) return "Master";
        else return "Legend 🏆";
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (bad habit tracker)");
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == "1")
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (goalType == "2")
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (goalType == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            
            ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(goal);
        }
        else if (goalType == "4")
        {
            // CREATIVITY FEATURE: Negative goal
            NegativeGoal goal = new NegativeGoal(name, description, points);
            _goals.Add(goal);
            Console.WriteLine("Created negative goal - you'll LOSE points when you record this!");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int pointsEarned = _goals[goalIndex].RecordEvent();
            _score += pointsEarned;
            
            if (pointsEarned > 0)
            {
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                
                // CREATIVITY FEATURE: Update streak
                UpdateStreak();
            }
            else if (pointsEarned < 0)
            {
                Console.WriteLine($"You lost {-pointsEarned} points for this bad habit. Stay strong!");
            }
            else
            {
                Console.WriteLine("This goal is already complete!");
            }
            
            Console.WriteLine($"You now have {_score} points.");
        }
    }

    // CREATIVITY FEATURE: Streak counter
    private void UpdateStreak()
    {
        string today = DateTime.Now.ToString("yyyy-MM-dd");
        
        if (_lastRecordedDate == today)
        {
            return; // Already recorded today
        }
        else if (_lastRecordedDate == GetYesterday())
        {
            _streak++; // Consecutive day
            Console.WriteLine($"🔥 Streak: {_streak} days!");
            
            // Bonus for milestones
            if (_streak == 7)
            {
                _score += 100;
                Console.WriteLine("🎉 7-day streak bonus! +100 points!");
            }
            else if (_streak == 14)
            {
                _score += 250;
                Console.WriteLine("🎉 14-day streak bonus! +250 points!");
            }
            else if (_streak == 30)
            {
                _score += 500;
                Console.WriteLine("🎉 30-day streak bonus! +500 points!");
            }
        }
        else
        {
            _streak = 1; // Start new streak
        }
        
        _lastRecordedDate = today;
    }

    private string GetYesterday()
    {
        return DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // First line: score, streak, last date
            outputFile.WriteLine($"{_score},{_streak},{_lastRecordedDate}");
            
            // Each goal on its own line
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            
            // Clear current goals
            _goals.Clear();
            
            // First line: score, streak, last date
            string[] scoreParts = lines[0].Split(',');
            _score = int.Parse(scoreParts[0]);
            _streak = int.Parse(scoreParts[1]);
            _lastRecordedDate = scoreParts[2];
            
            // Rest of lines: goals
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string goalType = parts[0];
                string[] goalParts = parts[1].Split(',');
                
                if (goalType == "SimpleGoal")
                {
                    string name = goalParts[0];
                    string description = goalParts[1];
                    int points = int.Parse(goalParts[2]);
                    bool isComplete = bool.Parse(goalParts[3]);
                    
                    SimpleGoal goal = new SimpleGoal(name, description, points, isComplete);
                    _goals.Add(goal);
                }
                else if (goalType == "EternalGoal")
                {
                    string name = goalParts[0];
                    string description = goalParts[1];
                    int points = int.Parse(goalParts[2]);
                    
                    EternalGoal goal = new EternalGoal(name, description, points);
                    _goals.Add(goal);
                }
                else if (goalType == "ChecklistGoal")
                {
                    string name = goalParts[0];
                    string description = goalParts[1];
                    int points = int.Parse(goalParts[2]);
                    int target = int.Parse(goalParts[3]);
                    int bonus = int.Parse(goalParts[4]);
                    int amountCompleted = int.Parse(goalParts[5]);
                    
                    ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                    _goals.Add(goal);
                }
                else if (goalType == "NegativeGoal")
                {
                    string name = goalParts[0];
                    string description = goalParts[1];
                    int points = int.Parse(goalParts[2]);
                    
                    NegativeGoal goal = new NegativeGoal(name, description, points);
                    _goals.Add(goal);
                }
            }
            
            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}
