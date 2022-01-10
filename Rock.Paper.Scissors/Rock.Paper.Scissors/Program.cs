using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock__Paper__Scissor
{
	static class Vars
	{
		static public string plyChoice;
		static public string aiChoice;
		static public string User = "";
		static public string Pass, userPass;
		static public string rockStr = "0", scissorStr = "0", paperStr = "0";
		static public int rockInt, paperInt, scissorInt, totalInt;
		static public string wins = "0", losses = "0", ties = "0";
		static public int winsInt, lossesInt, tiesInt;
		static public bool existing;
	}
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to Rock, Paper, Scissors!"); //Start
			signIn();
			mainMenu();
		}
		static void signIn()
		{
			// Main Menu Options
			Console.WriteLine("Choose a Option(type in 1, 2, or 3)");
			Console.WriteLine("1. Create an account");
			Console.WriteLine("2. Login to account");
			Console.WriteLine("3. Delete an account");

			string startMenu = Console.ReadLine();
			if (startMenu == "1") //Sign in
			{
				Console.WriteLine("Enter a username"); //Creates account
				Vars.User = Console.ReadLine();
				Console.WriteLine("Enter a password");
				Vars.Pass = Console.ReadLine();
				Vars.existing = File.Exists(Vars.User + "R.txt");
				if (Vars.existing == true) //Whether User Exists
				{
					Console.WriteLine("This User already exists");
					signIn();
				}
				else
				{
					Console.WriteLine("You have created a new account!");

					//Make Player Files
					File.WriteAllText(Vars.User + "R.txt", Vars.rockStr);
					File.WriteAllText(Vars.User + "P.txt", Vars.paperStr);
					File.WriteAllText(Vars.User + "S.txt", Vars.scissorStr);
					File.WriteAllText(Vars.User + "pass.txt", Vars.Pass);
					File.WriteAllText(Vars.User + "win.txt", Vars.wins);
					File.WriteAllText(Vars.User + "loss.txt", Vars.losses);
					File.WriteAllText(Vars.User + "tie.txt", Vars.ties);
				}
			}
			else if (startMenu == "2") //Log in
			{
				Console.WriteLine("Enter a username"); //Logs you in
				Vars.User = Console.ReadLine();
				Console.WriteLine("Enter a password");
				Vars.Pass = Console.ReadLine();
				Vars.existing = File.Exists(Vars.User + "R.txt");
				Vars.userPass = File.ReadAllText(Vars.User + "pass.txt");
				if (Vars.existing == true && Vars.Pass == Vars.userPass) //Whether User Exists + password
				{
					Console.WriteLine("Welcome Back!");

					//Reassign varibles based on file
					Vars.rockStr = File.ReadAllText(Vars.User + "R.txt");
					Vars.paperStr = File.ReadAllText(Vars.User + "P.txt");
					Vars.scissorStr = File.ReadAllText(Vars.User + "S.txt");
					Vars.wins = File.ReadAllText(Vars.User + "win.txt");
					Vars.losses = File.ReadAllText(Vars.User + "loss.txt");
					Vars.ties = File.ReadAllText(Vars.User + "tie.txt");


					//Makes files a int      
					Vars.rockInt = Convert.ToInt32(File.ReadAllText(Vars.User + "R.txt"));
					Vars.paperInt = Convert.ToInt32(File.ReadAllText(Vars.User + "P.txt"));
					Vars.scissorInt = Convert.ToInt32(File.ReadAllText(Vars.User + "S.txt"));
					Vars.winsInt = Convert.ToInt32(File.ReadAllText(Vars.User + "win.txt"));
					Vars.lossesInt = Convert.ToInt32(File.ReadAllText(Vars.User + "loss.txt"));
					Vars.tiesInt = Convert.ToInt32(File.ReadAllText(Vars.User + "tie.txt"));

				}
				else
				{
					Console.WriteLine("Ethier your username or your password is incorrect");
					signIn();
				}
			}
			else if (startMenu == "3") // Delete Account)
			{
				Console.WriteLine("Type in the username and pass word of the account you wish to delete");
				Console.WriteLine("Enter a username"); // Takes infomation on which account they are going to delete
				Vars.User = Console.ReadLine();
				Console.WriteLine("Enter a password");
				Vars.Pass = Console.ReadLine();
				Vars.existing = File.Exists(Vars.User + "R.txt");
				Vars.userPass = File.ReadAllText(Vars.User + "pass.txt");
				if (Vars.existing == true && Vars.Pass == Vars.userPass)
                {
					Console.WriteLine("The account has been deleted");
					File.Delete(Vars.User + "R.txt"); // Deletes Files                                                                                                                                                                                                                                                                          
					File.Delete(Vars.User + "P.txt");
					File.Delete(Vars.User + "S.txt");
					File.Delete(Vars.User + "pass.txt");
					File.Delete(Vars.User + "win.txt");
					File.Delete(Vars.User + "loss.txt");
					File.Delete(Vars.User + "tie.txt");
					signIn();
				}
				else
                {
					Console.WriteLine("That account doesn't exist");
					signIn(); 
				}
			}
			else // Not A Opiton
			{
				Console.WriteLine("That is not a option");
				signIn();
			}
		}
		static void mainMenu()
        {
			Console.WriteLine("");
			Console.WriteLine("MAIN MENU"); // Main Menu
			Console.WriteLine("1. Play Rock, Paper, Scissors!");
			Console.WriteLine("2. Look At You Account Stats");
			Console.WriteLine("3. Quit");
			string mainOpition = Console.ReadLine();
			if (mainOpition == "1")
            {
				play();
			}
			else if (mainOpition == "2") 
			{
				stats();
            } 
			else
            {
				Console.WriteLine("Bye! Come back soon!");
            }

		}
		static void stats()
        {
			Console.WriteLine("Here are your Stats!");
			Console.WriteLine("");
			Console.WriteLine("Times you've Chosen Rock: " + Vars.rockInt);
			Console.WriteLine("Times you've Chosen Paper: " + Vars.paperInt);
			Console.WriteLine("Times you've Chosen Scissors: " + Vars.scissorInt);
			Console.WriteLine("Total Times Played: " + Vars.totalInt);
			Console.WriteLine("");
			Console.WriteLine("Wins: " + Vars.winsInt);
			Console.WriteLine("Losses: " + Vars.lossesInt);
			Console.WriteLine("Ties: " + Vars.tiesInt);
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Press enter key to return to the Main Menu");
			Console.ReadLine();
			mainMenu();
		}
		static void play()
        {
			Vars.totalInt = Vars.rockInt + Vars.paperInt + Vars.scissorInt;
			computron();
			Console.WriteLine("To choose, type in rock, paper, or scissors");
			Vars.plyChoice = Console.ReadLine();
			Console.WriteLine("Rock... Paper... Scissors!");
			Console.WriteLine("");
			Console.WriteLine("Your Choice: " + Vars.plyChoice + "  AI's Choice: " + Vars.aiChoice);
			winLose();
			Console.WriteLine("");
			Console.WriteLine("1. Play again?");
			Console.WriteLine("2. Main Menu");
			string again = Console.ReadLine();
			if (again == "1")
            {
				Console.WriteLine("");
				play();
            }
			else
            {
				Console.WriteLine("");
				mainMenu();
            }
		}
		static void computron() //Chooses Computers Choice
		{
			Random rand = new Random();
			double randNum;
			randNum = rand.NextDouble() * (100 - 1) + 1;
			if (Vars.totalInt < 10)
			{
				if (randNum <= 33.33)
				{
					Vars.aiChoice = "rock";
				}
				else if (randNum <= 66.66 && randNum > 33.33)
				{
					Vars.aiChoice = "paper";
				}
				else
				{
					Vars.aiChoice = "scissors";
				}
			}
			else
			{
				double plibs = Vars.rockInt * 100 / Vars.totalInt;
				double plubs = Vars.paperInt * 100 / Vars.totalInt;
				if (randNum <= plibs)
				{
					Vars.aiChoice = "paper";
				}
				else if (randNum <= plibs + plubs)
				{
					Vars.aiChoice = "scissors";
				}
				else
				{
					Vars.aiChoice = "paper";
				}
			}
		}
		static void winLose() // Tell play if they won or loss, also updates stats
        {
			if (Vars.aiChoice == "paper")
			{
				if (Vars.plyChoice == "rock")
				{
					Console.WriteLine("YOU LOSE");
					Vars.lossesInt += 1;
					Vars.rockInt += 1;
				}
				else if (Vars.plyChoice == "scissors")
				{
					Console.WriteLine("YOU WIN");
					Vars.winsInt += 1;
					Vars.scissorInt += 1;
				}
				else if (Vars.plyChoice == "paper")
				{
					Console.WriteLine("Tied");
					Vars.tiesInt += 1;
					Vars.paperInt += 1;
				}
				else
				{
					Console.WriteLine("This is not a correct choice. Please type either rock, paper, or scissors ");
				}
			}
			else if (Vars.aiChoice == "rock")
			{
				if (Vars.plyChoice == "scissors")
				{
					Console.WriteLine("YOU LOSE");
					Vars.lossesInt += 1;
					Vars.scissorInt += 1;
				}
				else if (Vars.plyChoice == "paper")
				{
					Console.WriteLine("YOU WIN");
					Vars.winsInt += 1;
					Vars.paperInt += 1;
				}
				else if (Vars.plyChoice == "rock")
				{
					Console.WriteLine("Tied");
					Vars.tiesInt += 1;
					Vars.rockInt += 1;
				}
				else
				{
					Console.WriteLine("This is not a correct choice. Please type either rock, paper, or scissors ");
				}
			}
			else
			{
				if (Vars.plyChoice == "paper")
				{
					Console.WriteLine("");
					Console.WriteLine("YOU LOSE");
					Vars.lossesInt += 1;
					Vars.paperInt += 1;
				}
				else if (Vars.plyChoice == "rock")
				{
					Console.WriteLine("");
					Console.WriteLine("YOU WIN");
					Vars.winsInt += 1;
					Vars.rockInt += 1;
				}
				else if (Vars.plyChoice == "scissors")
				{
					Console.WriteLine("Tied");
					Vars.tiesInt += 1;
					Vars.scissorInt += 1;
				}
				else
				{
					Console.WriteLine("This is not a correct choice. Please type either rock, paper, or scissors ");
				}
			}
			assignVar();
		}
		static void assignVar() // Assign Files again after Play
        {
			// Asigns strs based on ints
			Vars.rockStr = Convert.ToString(Vars.rockInt);
			Vars.paperStr = Convert.ToString(Vars.paperInt);
			Vars.scissorStr = Convert.ToString(Vars.scissorInt);
			Vars.wins = Convert.ToString(Vars.winsInt);
			Vars.losses = Convert.ToString(Vars.lossesInt);
			Vars.ties = Convert.ToString(Vars.tiesInt);

			File.WriteAllText(Vars.User + "R.txt", Vars.rockStr);
			File.WriteAllText(Vars.User + "P.txt", Vars.paperStr);
			File.WriteAllText(Vars.User + "S.txt", Vars.scissorStr);
			File.WriteAllText(Vars.User + "win.txt", Vars.wins);
			File.WriteAllText(Vars.User + "loss.txt", Vars.losses);
			File.WriteAllText(Vars.User + "tie.txt", Vars.ties);
		}
	}
}