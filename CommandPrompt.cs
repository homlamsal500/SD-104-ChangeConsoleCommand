using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleAppCommandClass
{
    class CommandPrompt
    {

        ConsoleColor backgroundColor;
        ConsoleColor foregroundColor;
        int height;
        int columns;
        string[] screenText;

        //Constructor
        public CommandPrompt(int height, int columns)
        {
            //set the default backgroundcolor


            backgroundColor = ConsoleColor.Red;
           foregroundColor = ConsoleColor.Black;
            backgroundColor = ConsoleColor.Green;
            foregroundColor = ConsoleColor.Blue;

            //set the default foregroundcolor

            //create screen to hold the rows height

            screenText = new string[height];

            Console.SetWindowSize(columns, height + 7);

            //lets set the screen text to emty
            for (int i = 0; i < screenText.Length; i++)
            {
                screenText[i] = "";

            }
        }

        public void Display()
        {
            //set the foregroundcolor and background color

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;





            Console.Clear();
            Console.WriteLine("******************** SCREEN TEXT DISPLAYED ****************");

            //print the screen text arry text
            for (int i = 0; i < screenText.Length; i++)
            {
                Console.WriteLine(screenText[i]);
            }
        }
        public void SetScreenText(int lineNumber,String lineOfText)
        {
            screenText[lineNumber] = lineOfText;
        }

        public void SetBackgroundColor(string color)
        {
            backgroundColor = ConvertColor(color);
        }   // end of SetBackgroundColor

        public void SetForegroundColor(string color)
        {
            foregroundColor = ConvertColor(color);
        }   // end of SetForegroundColor

        public static ConsoleColor ConvertColor(string strColor)
        {
            ConsoleColor color;
            switch (strColor.ToLower())
            {
                case "black": color = ConsoleColor.Black; break;
                case "red": color = ConsoleColor.Red; break;

                default: color = ConsoleColor.DarkGray; break;
            }
            return color;
        }   // end of ConvertColor method
        public void ClearScreen()
        {
            for (int i = 0; i < screenText.Length; i++)
            {
                screenText[i] = "";

            }
        }

        public void SaveScreen(string fileName)
        {
            FileStream stream;
            StreamWriter textOut = null;
            try

                //version 1 //
            {
                fileName = "C://temp/" + fileName;
                stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                textOut = new StreamWriter(stream);
                textOut.WriteLine("my Name");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Creating file: ");
                Console.WriteLine(ex.ToString());
                return;
            }
            finally
            {
                if (textOut != null)
                    textOut.Close();
            }
        }   // of of SaveScreen method
    }
}