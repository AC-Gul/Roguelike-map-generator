/*
Alex Gulewich
Aug, 21, 2021
Map generator
Generates a random roguelike ascii map
*/

import java.util.*;

//Compiler version JDK 11.0.2

class Dcoder
{  
  public static void main(String args[])
  {
      //Declarations
      int mapSize = 60;
      char map[][] = new char[mapSize][mapSize];
      
      Random rnd = new Random();
      
      int maxRooms = 30;
      int maxRoomSize = 7;
      int minRoomSize = 4;
      
      char wall = '#';
      char floor = ' ';

      
      //Fill map with walls
      for (int y = 0; y < mapSize; y++) {
          for (int x = 0; x < mapSize; x++) {
              map[x][y] = wall;
          }
      }
      //Finished filling map with walls
      
      
      //Build rooms
      int validate = 0, oldX = mapSize/2, oldY = mapSize/2;
      for (int iteration = 0; iteration < (maxRooms * 4); iteration++) {
          
          //check to see if maxRooms is reached
          if (validate == maxRooms) {
            System.out.println("Max rooms reached");
            break;
          }
          
          //Declarations
          int width = rnd.nextInt(maxRoomSize - minRoomSize) + minRoomSize;
          int height= rnd.nextInt(maxRoomSize - minRoomSize) + minRoomSize;
          
          int X = rnd.nextInt(mapSize - width - 2) + 1;
          int Y = rnd.nextInt(mapSize - height - 2) + 1;
          
          boolean worked = true;
          
          
          //Validate room placement
          for (int y = -1; y < height + 1; y++) {
              for (int x = -1; x < width + 1; x++) {
                  if (map[X + x][Y + y] == floor) {
                      worked = false;
                      break;
                  }
              }
          }  //Validation finished
          
          
          //Place room
          if (worked) {
            validate++;
            for (int y = 0; y < height; y++) {
                 for (int x = 0; x < width; x++) {
                     map[X + x][Y + y] = floor;
                }
            }
          }
          //Placement finished
          
          
          //Build hallways
           
          
          while (Y != oldY) { //Build the Y axis
              map[X][Y] = floor;
              //Decide whether to move up or down
              if (Y < oldY) {
                  Y++;
              }
              else if (Y > oldY) {
                  Y--;
              }
          }
          while (X != oldX) { //Build the X axis
              map[X][Y] = floor;
              //Decide whether to move up or down
              if (X < oldX) {
                  X++;
              }
              else if (X > oldX) {
                  X--;
              }
          }
          //Halways finished
          System.out.println(validate);

          
          oldX = X;
          oldY = Y;
      }
      //Map finished Generating
      
      for (int y = 0; y < mapSize; y++) {
          for (int x = 0; x < mapSize; x++) {
              System.out.print(map[x][y] + " ");
          }
          System.out.print("\n");
      }
  }
    
}
