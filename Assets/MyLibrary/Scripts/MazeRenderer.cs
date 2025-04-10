using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour 
{

    [SerializeField] MazeGenerator MazeGenerator;
    [SerializeField] GameObject MazeCellPrefab;

    //This is the physical size of our maze cells. Getting this wrong will result 
    // in overlapping or visible gaps between each cell.
    public float CellSize = 1f;

    private void Start() {
        // Get our MazeGenerator script to generate a maze
        MazeCell[,] maze = MazeGenerator.GetMaze();


        // Loop through every cell in the maze
        for (int x = 0; x < MazeGenerator.mazeWidth; x++) 
        {
            for (int y = 0; y < MazeGenerator.mazeHeight; y++) 
            {

                // Instantiate a new maze cell prefab as a child of the MazeRenderer Object.
                GameObject newCell = Instantiate(MazeCellPrefab, new Vector3((float)x * CellSize, 0f, (float)y * CellSize), Quaternion.identity, transform);
            
                //Get a reference to the cell's MazeCellPrefab Script
                MazeCellObject MazeCell = newCell.GetComponent<MazeCellObject>();

                //Determine which walls need to be active.
                bool top = maze[x, y].topWall;
                bool left = maze[x, y].leftWall;

                //Bottom and right walls are deactivated by default unless we are at
                // the bottom or right edge of the maze.
                bool right = false;
                bool bottom = false;

                if (x == MazeGenerator.mazeWidth -1) right = true;
                if (y == 0) bottom = true;

                MazeCell.Init(top, bottom, right, left);

            }


        }
}

}

// Credit for code goes to https://www.youtube.com/watch?v=TMOEYdV4Ot4&ab_channel=b3agz


