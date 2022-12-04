//Kelly Chen | kc4509@g.rit.edu
//Midterm Question 1: Skyscraper

//Model of behavior of skyscraper sways per second
//Time from 2:30pm to 4:46pm

using System;

namespace Skyscaper
{
    //store the displacement and acceleration data of each coordinate
    class Data
    {
        public double disp; // displacement of room for current time
        public double accel; // acceleration of room for current time
        public String toString() { return "[D: " + disp + ", A: " + accel + "]"; }
    }
    class Program
    {
        public static int TIME = 10; //max time
        public static int X = 4; // max X
        public static int Z = 4; // max Z
        public static int[] HEIGHT = { 4, 6, 8 }; //different heights
        public static int[,] top = new int[Z, X]; //holds the max height corresponding to x and z coords
        public static Data[,,,]? info; //4D array that holds Data to coordinates


        private static void Main(string[] args)
        {
            for (int time = 0; time < 6; time++)
            {
                printData(time, HEIGHT[2]);
            }
        }

        //Sets the max height to correspond with the x and z coordinates
        private static void setHeights()
        {
            for (int z = 0; z < Z; z++)
            {
                for (int x = 0; x < X; x++)
                {
                    if (x < 2 && z < 2)
                    {
                        top[z, x] = HEIGHT[0];
                    }
                    else if (x >= 2)
                    {
                        top[z, x] = HEIGHT[1];
                    }
                    else
                    {
                        top[z, x] = HEIGHT[2];
                    }

                }
            }
            
        }

        //Builds the skyscraper/4D array
        private static void createBuilding()
        {
            setHeights();
            info = new Data[TIME, X, HEIGHT[2], Z];
            //info = new double[2];
            for (int t = 0; t < TIME; t++)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        for (int y = 0; y < top[z, x]; y++)
                        {
                            Data i = new Data();
                            i.accel = 0.0;
                            i.disp = 0.0;
                            
                            info[t, x, y, z] = i;
                        }
                    }
                }
            }
        }

        //Prints the data to strings
        private static void printData(int time, int floor)
        {
            createBuilding();
            for (int x = 0; x < 4; x++)
            {
                for (int z = 0; z < 4; z++)
                {
                    if (top[z, x] == floor)
                    {
                        Console.WriteLine("(" + time + "," + x + "," + floor + "," + z + ") ->" + info[time, x, floor -1, z].toString());
                    }
                }
            }
        }
    }
}