using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;

static class GameLogic
{

    

	public static void Main()
	{
		//Opens a new Graphics Window
		SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

		//Load Resources
		GameResources.LoadResources();
        Random random = new Random();
        int musicSelector = random.Next(1, 5);

        if (musicSelector == 1)
        {
            SwinGame.PlayMusic(GameResources.GameMusic("Background1"));

        }
        else if (musicSelector == 2)
        {
            SwinGame.PlayMusic(GameResources.GameMusic("Background2"));

        }
        else if (musicSelector == 3)
        {
            SwinGame.PlayMusic(GameResources.GameMusic("Background3"));

        }
        else if (musicSelector == 4)
        {
            SwinGame.PlayMusic(GameResources.GameMusic("Background4"));

        }


        //Game Loop
        do {
			GameController.HandleUserInput();
			GameController.DrawScreen();

            //Mute the game when key M is pressed

            if (SwinGame.KeyTyped(KeyCode.vk_m))
            {
                SwinGame.PauseMusic();
            }
            
            //Unmute the game when the key N is pressed
            if (SwinGame.KeyTyped(KeyCode.vk_n))
            {
                SwinGame.ResumeMusic();
            }
  

        } while (!(SwinGame.WindowCloseRequested() == true | GameController.CurrentState == GameState.Quitting));

		SwinGame.StopMusic();

		//Free Resources and Close Audio, to end the program.
		GameResources.FreeResources();
	}
}