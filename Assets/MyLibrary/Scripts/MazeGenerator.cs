using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeGenerator : MonoBehaviour
{
    [Range(5, 500)]
    public int mazeWidth = 5, mazeHeight = 5;   //The dimensions of the maze.
    public int startX, startY;                  //The position the maze will start from.
    MazeCell[,] maze;                           //An array of maze cells representing the maze grid

    Vector2Int currentCell;                     //The maze cell we are currently looking at.

    public MazeCell [,] GetMaze() {
        maze = new MazeCell [mazeWidth, mazeHeight];

        for (int x = 0; x < mazeWidth; x++) {
            for (int y = 0; y < mazeHeight; y++) {

                maze[x, y] = new MazeCell(x, y);

            }
        }

        // Start carving our maze path
        CarvePath(startX, startY);

        return maze;
    }

    List<Direction> directions = new List<Direction> {
        Direction.Up, Direction.Down, Direction.Left, Direction.Right,
    };

    List<Direction> GetRandomDirections() {

        // Make a copy of our directions list that we can test and play with.
        List<Direction> dir = new List<Direction>(directions);

        //Make a directions list to put our randomized directions into.
        List<Direction> rndDir = new List<Direction>();

        while (dir.Count > 0) {                     // Loop until our rndDir list is empty

            int rnd = Random.Range(0, dir.Count);   // Get random index in List.
            rndDir.Add(dir[rnd]);                   // Add the random direction to our list
            dir.RemoveAt(rnd);                      // Remove that direction so we can't choose it again

        }

        // When we've got all four directions in a random order, return the queue.
        return rndDir;

    }

    bool IsCellValid (int x, int y) {
        // If the cell is outside of the map or has already been visited, we consider it not valid
        if (x < 0 || y < 0 || x > mazeWidth - 1 || y > mazeHeight -1 || maze[x, y].visited) return false;
        else return true;
    }

    Vector2Int CheckNeighbor () {

        List<Direction> rndDir = GetRandomDirections();

        for (int i = 0; i < rndDir.Count; i++) 
        {

        // Set Neighbor coordinates to current cell for now
        Vector2Int neighbor = currentCell;

        switch (rndDir[i]) {

            case Direction.Up:
                neighbor.y++;
                break;
            case Direction.Down:
                neighbor.y--;
                break;
            case Direction.Right:
                neighbor.x++;
                break;
            case Direction.Left:
                neighbor.x--;
                break;
        }

        // If the neighbor we just tried is valid, we can return that neighbor. If not, we go again.
        if (IsCellValid(neighbor.x, neighbor.y)) return neighbor;
        }

        //if we tried all directions and didn't find a valid neighbor, we return the currentCell values.
        return currentCell;


    }
    // Takes in two maze positions and sets the sells accordingly.
    void BreakWalls (Vector2Int primaryCell, Vector2Int secondaryCell) {

        // We can only go in one direction at a time so we can handle this uing if else statements.
        if (primaryCell.x > secondaryCell.x) {  // Primary Cell's Left Wall

            maze[primaryCell.x, primaryCell.y].leftWall = false;

        }
        else if (primaryCell.x < secondaryCell.x) { // Secondary Cell's Left Wall

            maze[secondaryCell.x, secondaryCell.y].leftWall = false;

        }
        else if (primaryCell.x < secondaryCell.x) { // Primary Cell's Top Wall

            maze[primaryCell.x, primaryCell.y].topWall = false;
        }

        else if (primaryCell.x < secondaryCell.x) { // Secondary Cell's Top Wall

            maze[secondaryCell.x, secondaryCell.y].topWall = false;
        }


    }
    // Starting at the x, y passed in, carves a path through the maze until it encounters a "dead end"
    // (a dead end is a cell with no valid neighbors)

    void CarvePath (int x, int y) {

        // Perform a quick check to make sure our start position is within the boundaries of the map,
        // if not, set them to a default (Using 0 in this case) and throw a little warning up.
        if (x < 0 || y < 0 || x > mazeWidth - 1 || y > mazeHeight -1) {

            x = y = 0;
            Debug.LogWarning("Starting position is out of bounds, defaulting to 0,0");
        }

        // Set current cell to the starting position we were passed.
        currentCell = new Vector2Int(x,y);

        // A list to keep track of our current path.
        List<Vector2Int> path = new List<Vector2Int>();

        // Loop until we encounter a dead end.
        bool deadEnd = false;
        while (!deadEnd) {

            // Get the next cell we're going to try.
            Vector2Int nextCell = CheckNeighbor();

            // If that cell has no valid neighbors, set deadEnd to true so we break out of the loop.
            if (nextCell == currentCell) {
                
                // If that cell has no valid neighbors, set deadEnd to true so we break out of the loop
                for (int i = path.Count -1; i >= 0; i--) {

                    currentCell = path[i];                              // Set currentCell to the next step back along our path
                    path.RemoveAt(i);                                   // Remove this step from the path
                    nextCell = CheckNeighbor();                         // Check that cell to see if any other neighbors are valid

                    // If we find a valid neighbor, break out of the loop
                    if (nextCell != currentCell) break;

                    
                }

                if (nextCell == currentCell)
                    deadEnd = true;


            }
            else {

                BreakWalls(currentCell, nextCell);                      // Set wall flags on these two cells.
                maze[currentCell.x, currentCell.y].visited = true;      // Set cell to visited before moving on.
                currentCell = nextCell;                                 // Set the current cell to the valid neighbor we found.
                path.Add(currentCell);                                  // Add this cell to our path

            }


        }

    }

}



public enum Direction {

    Up,
    Down,
    Left,
    Right

}

public class MazeCell 
{
    public bool visited;
    public int x,y;

    public bool topWall;
    public bool leftWall;

    //Return x and y as a vector2 int for convenience sake.
    public Vector2Int position {
        get {

            return new Vector2Int(x, y);

        }
    }

    public MazeCell (int x, int y) {

        //The coordinates of this sell in the maze grid.
        this.x = x;
        this.y = y;

        // Whether the algorithm has visited this cell or not - false to start
        visited = false;

        //All walls are present until the algorithm removes them.
        topWall = leftWall = true;

    }


}

//credit to code goes to https://www.youtube.com/watch?v=TMOEYdV4Ot4&ab_channel=b3agz

