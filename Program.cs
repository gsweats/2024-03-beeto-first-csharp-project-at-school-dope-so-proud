using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace Project__1
{
    //Set up Program class (Was done when we started project)
    internal class Program
    {
        //Declare class variables (Avalible to entire class)

        //Create a class Array of Rooms (Objects)
        static Room[] allRooms;

        //Create a list to serve as the player's inventory....
        static List <Item> playerInvenory = new List <Item> ();



        // The index of the current room
        static int currentRoom = 0;

        //Rest of our class variables....
        static string playerName = "Defualt";
        static int playerHealth = 10;
        static int playerBaseAttack = 1; //Base Atk PWR
        static int playerAttack = playerBaseAttack + 0;
        static bool gameOver = false;
        static int playerGold = 0;

        //Create a refrence to the rng
        static Random rng = new Random();



        static void Main(string[] args)
        {
            //Our first line of executable code is here....

            //Set up rooms (set all navigaion and description for each room)
            setUpRooms();







            //Ask the player for there name
            Console.WriteLine("Please Enter Your Name");

            //Assign the player's name based on their input
            playerName = Console.ReadLine();

            // Welcome the player to the game... and indicate their starting health
            Console.WriteLine("Hello " + playerName + "");
            Console.WriteLine("Your Health " + playerHealth);
            Console.WriteLine("Press [ENTER]");
            Console.ReadLine();


            // Show title screen....
            showTitleScreen();






            //Show first room description...
            Console.WriteLine(allRooms[0].roomDescription);


            // Show master game loop...
            while (!gameOver)
            {
                //Clear
                Console.Clear();

                //Show room description
                Console.WriteLine(allRooms[currentRoom].roomDescription);

                //Reveal any items.....
                if (allRooms[currentRoom].roomItem != null)
                {
                    Console.WriteLine("There is an item here");
                }
                else
                {
                    Console.WriteLine("No item in room");
                }

                //Check for monster encounter....
                checkForEncounter();

                //Handle user input....
                HandleUserCommand();



            }





            //Hold program open... so we can see results...
            Console.ReadLine();





            int monsterAttack = 2;

            playerHealth = playerHealth - monsterAttack;


        }




        static void checkForEncounter()
        {
            //Randomly determine if the player encounters a monster in this room....

            //Step 1: Create a random number between 1 and 10

            int encounterChance = rng.Next(1, 11);

            //Step 2: Check the random number, if the number is 2 or lower, monster attacks

            if (encounterChance <= 1)
            {
                Console.WriteLine("Encounter " + encounterChance);
                //Create a monster
                //Enter combat...etc....
                handleCombat();
            }
            else
            {


            }
            //Step 3: If there is a monster, start combat....(What kind of monster???)

            Monster newMonster = new Monster(Monster.MonsterType.Skeleton);

            //Step 4: Resolve combat....
            //Step 5: IF no monster, continue to new room....etc....

        }

        static void showTitleScreen()
        {
            // This is a comment.... use double slash
            // this function displays the intro screen to the game...
            Console.WriteLine("You wake up in a small dark cave that is lit by a small hole of light.");
            Console.WriteLine("You decide to move some rocks where the light is coming from and crawl through it.");
            Console.WriteLine("You find yourself in a giant cave filled with shining ores and two paths you can take.");
            Console.WriteLine("One a dark and gloomy room and the other filled with ores and gems.  \r\n");

            Console.WriteLine("Proceed");
            Console.WriteLine("Press Enter ");
            Console.ReadLine();
        }





        static void setUpRooms()
        {
            allRooms = new Room[10];

            //Arrays always start with at index 0, so 10 rooms = 0-9
            allRooms[0] = new Room();
            allRooms[1] = new Room();
            allRooms[2] = new Room();
            allRooms[3] = new Room();
            allRooms[4] = new Room();
            allRooms[5] = new Room();
            allRooms[6] = new Room();
            allRooms[7] = new Room();
            allRooms[8] = new Room();
            allRooms[9] = new Room();
            //...........


            //Set up our rooms using class instances...


            //Nav matrix.... for room0
            allRooms[0].roomToEast = 1;


            //Room description for room 0
            allRooms[0].roomDescription = ("You wake up in a small unlit cave with no memory of how you got there, to your east is a slight glow coming from a gap in between some rocks");

            //Item





            //Nav matrix.... for room 1
            allRooms[1].roomToNorth = 7;
            allRooms[1].roomToEast = 2;



            allRooms[1].roomDescription = ("You go deeper into the cave, to your EAST is a hole you can fit through to your NORTH is a small hole with a glowing light coming from it. You also notice something shiny in the corner");

            //Item
            allRooms[1].roomItem = new Item(ItemType.RustedShield);

            //Nav matrix.... for room 2
            allRooms[2].roomToEast = 3;
            allRooms[2].roomToSouth = 4;
            allRooms[2].roomToWest = 1;


            allRooms[2].roomDescription = ("You stumble into a abanded library that has been filled with rocks and dirt. To your EAST is a dug up path that leads deeper into the cave. To your SOUTH is a big wooden door");



            //Nav matrix.... for room 3
            allRooms[3].roomToSouth = 5;


            allRooms[3].roomDescription = ("Rocks crumble behind you leaving you trapped in a pitch black cave, to your SOUTH there is hole you can jump down with light a small light coming from it");


            //Nav matrix....for room 4
            allRooms[4].roomToEast = 5;

            allRooms[4].roomDescription = ("You walk through the door to find more of the library, infront of you is a wooden chest on a old desk and to your EAST is a whole in the wall that leads back into the cave. Do you open the chest or travel East?");

            //Item
            allRooms[4].roomItem = new Item(ItemType.IronDagger);

            //Nav matrix.... for room 5
            allRooms[5].roomToSouth = 6;

            allRooms[5].roomDescription = ("You explore deeper into the cave. The room is slightly lit by what looks to be natural liht which gives you hope of finding a way out. To your SOUTH is a lit up path");


            //Nav matrix.... for room 6
            allRooms[6].roomToEast = 9;

            allRooms[6].roomDescription = ("You follow the lit path which leads you to a pile of rocks you can climb to your EAST. Light is beaming above the pile of rocks giving you even more hope of getting out of the cave");


            //Nav matrix.... for room 7
            allRooms[7].roomToEast = 8;


            allRooms[7].roomDescription = ("You crawl through the small hole and find your self in a small hot cavern with a glowing path coming from your EAST,There is a sword stuck in the ground");

            allRooms[7].roomItem = new Item(ItemType.IronSword);

            //Nav matric.... for room 8
            allRooms[8].roomToSouth = 2;


            allRooms[8].roomDescription = ("You go through the glowing path and into a giant hot spring filled with blue glowing water. In the middle is a stone pillar that has a silver key in it, to your SOUTH is a small hole you can jump through");

            allRooms[8].roomItem = new Item(ItemType.SilverKey);


            //Nav matrix.... for room 9
            allRooms[9].roomToWest = 6;

            allRooms[9].roomDescription = ("You finally make it to the end of the cave, infront of you is a stell door with bars blocking you from leaving, the door has a small keyhole");

        }






        static void handleCombat()
        {








            //Handle the combat process....

            //We need a monster to fight with....so generate / spawn a monster

            //Spawn a monster based on encounter chance
            //Gen a random number... if the number is x than an imp///else orc. else....
            //newMonster = NewMonster(Monster type.....);

            int d100Roll = rng.Next(1, 101);
            Monster newMonster;//Null Monster....

            if (d100Roll <= 50)
            {
                newMonster = new Monster(Monster.MonsterType.Bat);
            }
            else if (d100Roll <= 65)
            {
                newMonster = new Monster(Monster.MonsterType.Goblin);
            }
            else if (d100Roll <= 75)
            {
                newMonster = new Monster(Monster.MonsterType.Skeleton);
            }
            else if (d100Roll <= 92)
            {
                newMonster = new Monster(Monster.MonsterType.Troll);
            }
            else
            {
                newMonster = new Monster(Monster.MonsterType.Dragon);
            }
            //Error Check
            if(newMonster == null)
            {
                Console.WriteLine("Ligma Balls");
            }

            //Inform the player whats happening....

            Console.WriteLine("Monster Encounter");


            Console.WriteLine("There is a " + newMonster.monsterName);
            Console.WriteLine("Health: " + newMonster.monsterHealth);

            Console.WriteLine("Press ENTER");
            Console.ReadLine();























            //Start a comat loop that ends, when eiher the monster or the player has died
            //While Loop????

            bool InCombat = true;

            while (InCombat)
            {
                //Show Monster Health And Attack


                Console.WriteLine("The " + newMonster.monsterName +
                    "Strikes You For " +
                    newMonster.monsterAttackPwr + "Damage");

                int totalDef = 0;

                foreach (Item Defitem in playerInvenory)
                {
                    totalDef += Defitem.itemDef;
                }
                int modifiedMonsterDamage = newMonster.monsterAttackPwr - totalDef;

                if (modifiedMonsterDamage > 0)
                {
                    //Monster Hits
                    Console.WriteLine("The Monster Damages You For " + modifiedMonsterDamage);
                }
                else
                {
                    //Armour Protects
                    Console.WriteLine("Your Armour Has Absorbed All Damage");
                    modifiedMonsterDamage = 0;
                }


                int modifiedPlayerHealth =
                    playerHealth - newMonster.monsterAttackPwr;



                if (modifiedPlayerHealth <= 0)
                {
                    // Player dead....
                    Console.WriteLine(" You have been killed by the " +
                        newMonster.monsterName);

                    Console.WriteLine("Press ENTER");
                    Console.ReadLine();

                    //End the game, player lost
                    GameOver(false);
                }
                else
                {
                    // Player is still alive....
                    playerHealth = modifiedPlayerHealth;

                    Console.WriteLine(" You have " + playerHealth + " health remaining...");

                    Console.WriteLine("Press ENTER");
                    Console.ReadLine();
                }

                // Player hits monster....
                foreach (Item thisItem in playerInvenory)
                {
                    playerAttack = (playerBaseAttack + thisItem.itemDamage);
                }



                Console.WriteLine("You strike back for " + playerBaseAttack + "!!");

                int modifiedMonsterHealth =
                    newMonster.monsterHealth - playerBaseAttack;

                Console.WriteLine("PRESS ENTER TO CONTINUE...");
                Console.ReadLine();

                // Apply the damage to the monster
                newMonster.monsterHealth = modifiedMonsterHealth;

                if (newMonster.monsterHealth <= 0)
                {
                    // Dead monster
                    Console.WriteLine("You have slain the evil " +
                        newMonster.monsterName + "!!!");

                    Console.WriteLine("After searching the pulverized remains... you have gained " +
                        newMonster.monsterLoot + " gold!");
                    //Give Player The Loot
                    playerGold += newMonster.monsterLoot;

                    Console.WriteLine("PRESS ENTER TO RESUME YOUR ADVENTURE...");
                    Console.ReadLine();

                    InCombat = false;

                    // Clear the screen
                    Console.Clear();


                    // Show room description
                    Console.WriteLine(allRooms[currentRoom].roomDescription);
                }
                else
                {
                    // Alive monster

                    Console.WriteLine("The " + newMonster.monsterName + " has been wounded!");
                    Console.WriteLine("It's remaining health is " + newMonster.monsterHealth + "...");
                }
            }











































        }


        static void GameOver(bool playerWon)
        {
            //Called when the game should end....

            Console.Clear();

            int playerScore = 0;

            playerScore = playerGold * 10;

           foreach (Item thisItem in playerInvenory)
            {
                playerScore += thisItem.itemValue;
            }



            if(playerWon)
            {
                //Bonus Score For Winning
                playerScore += 1000;

                //victory screen
                Console.WriteLine("You walk through the door and finally make your way out of the cave and into a field near your house");
                Console.WriteLine("Press ENTER To Exit");

            }
            else
            {
                //Defeat screen....

                Console.WriteLine("Your Bad Get Good");

                Console.WriteLine("Press ENTER To Exit");
            }

            Console.WriteLine("Your Score Is " + playerScore);

            Console.ReadLine();

            //Stop the application/game/program
            Environment.Exit(0);
        }








        static void HandleUserCommand()
        {
            // Ask the player what they want to do....

            if(currentRoom == 9)
            {
                //Player is in final room
                foreach(Item thisItem in playerInvenory)
                {
                    if(thisItem.itemName == "Silver Key")
                    {
                        //Player Wins
                        Console.WriteLine("You Press The Silver Key Into The Key Hole");

                        Console.WriteLine("You Have Escaped The Dungeuon");

                        Console.WriteLine("Press ENTER");
                        Console.ReadLine();

                        GameOver(true);
                    }


                }
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[GO NORTH/SOUTH/EAST/WEST][INVENTORY]");
            Console.WriteLine("----------------------------------------");

            string playerCommand = Console.ReadLine();

            if (playerCommand == "GO NORTH")
            {
                // Handle player trying to move north
                if (allRooms[currentRoom].roomToNorth == -1)
                {
                    // Found -1, so cannot move that way....
                    Console.WriteLine("You cannot go north...");
                    Console.WriteLine("PRESS ENTER TO CONTINUE...");
                    Console.ReadLine();
                }
                else
                {
                    // Room number is not -1 (0 or greater)
                    // Change the current room to the new room
                    // Found in the direction property....

                    currentRoom = allRooms[currentRoom].roomToNorth;

                    Console.WriteLine("You travel northward...");
                    Console.WriteLine("PRESS ENTER TO CONTINUE...");
                    Console.ReadLine();
                }
            }
            else if (playerCommand == "GO SOUTH")
            {
                if (allRooms[currentRoom].roomToSouth == -1)
                {
                    Console.WriteLine("You cannot go south...");
                    Console.WriteLine("PRESS ENTER TO CONTINUE...");
                    Console.ReadLine();
                }
                else
                {
                    currentRoom = allRooms[currentRoom].roomToSouth;

                    Console.WriteLine("You travel southward...");
                    Console.WriteLine("PRESS ENTER TO CONTINUE...");
                    Console.ReadLine();
                }
            }
            else if (playerCommand == "GO EAST")
            {
                if (allRooms[currentRoom].roomToEast == -1)
                {
                    Console.WriteLine("You cannot go east...");
                    Console.WriteLine("PRESS ENTER TO CONTINUE...");
                    Console.ReadLine();
                }
                else
                {
                    currentRoom = allRooms[currentRoom].roomToEast;

                    Console.WriteLine("You travel eastward...");
                    Console.WriteLine("PRESS ENTER TO CONTINUE...");
                    Console.ReadLine();
                }
            }
            else if (playerCommand == "GO WEST")
            {
                if (allRooms[currentRoom].roomToWest == -1)
                {
                    Console.WriteLine("You cannot go west...");
                    Console.WriteLine("PRESS ENTER TO CONTINUE...");
                    Console.ReadLine();
                }
                else
                {
                    currentRoom = allRooms[currentRoom].roomToWest;

                    Console.WriteLine("You travel westward...");
                    Console.WriteLine("PRESS ENTER TO CONTINUE...");
                    Console.ReadLine();
                }
            }
            else if (playerCommand == "INVENTORY")
            {
                Console.WriteLine("You glance at your inventory...");
                Console.WriteLine(" +++++++++++++++++++++++++++++++++++++++ ");
                Console.WriteLine(" Your health is " + playerHealth);
                Console.WriteLine(" Your gold is " + playerGold);
                Console.WriteLine(" +++++++++++++++++++++++++++++++++++++++ ");

                foreach(Item thisItem in playerInvenory)
                {
                    Console.WriteLine(thisItem.itemName);
                }


                Console.WriteLine("PRESS ENTER TO CONTINUE...");
                Console.ReadLine();

            }
            else if (playerCommand == "SEARCH")
            {
                Console.WriteLine("You Search The Room");
                Console.WriteLine("Press ENTER");
                Console.ReadLine();

                //Reveal any items....
                if (allRooms[currentRoom].roomItem != null)
                {
                    Console.WriteLine("After Searching You Find A " +
                        allRooms[currentRoom].roomItem.itemName);

                    //Add item to inventory
                    playerInvenory.Add(allRooms[currentRoom].roomItem);

                    //Remove the item from the room
                    allRooms[currentRoom].roomItem = null;
                }




                else
                {
                    Console.WriteLine("Not a valid command.. please try again...");
                    Console.WriteLine("PRESS ENTER TO CONTINUE...");
                    Console.ReadLine();
                }



            }
        }
    }
}


