#include <iostream>
#include <conio.h>
#include <windows.h>
using namespace std;


bool gameOver;
const int width = 20;                                // Map width
const int height = 20;                               // Map height
int x,y;                                             // Snake x and y cords
int fruitX, fruitY;                                  // Fruit X and Y cords
int score;
enum eDirection { STOP = 0, LEFT, RIGHT, UP, DOWN};  // Possible Directions
eDirection dir;                                      // Holds the direction 
int tailX[100];
int tailY[100];                                      // Keeping track of the snake tail
int nTail;


void setup() 
{
    gameOver = false;
    dir = STOP;                                      // So the guy doesn't fling off the screen
    x = width / 2;
    y = height / 2;               
    // Setting the fruit location
    fruitX = rand() % width;
    fruitY = rand() % height;

    score 0;
}

void draw() 
{
    system("cls");
    // Drawing the boarder
    for (int i = 0; i < width + 2; ++i)              // Top wall
    {
        std::cout << '$';
    }
    std::cout << endl;

    for (int i = 0; i < height; ++i)                 // Side walls
    {
        for (int j = 0; j < width; ++j) 
        {
            if (j == 0) 
            {
                std::cout << '$';                    // Left Wall
            }
            // Drawing the snake head
            if (i == y && j == x) 
            {
                std::cout << '~';
            }
            // Drawing the fruit
            else if (i == fruitY && j == fruitX)
            {
                std::cout << '&';
            }

            else 
            {
                bool print = false;
                for (int k = 0; k < nTail; ++k)
                {
                    if (tailX[k] == j && tailY[k] == i)
                    {
                        std::cout << 'S';
                        print = true;
                    }
                }
                if (!print)
                {
                    cout << ' ';
                }
            }

            else 
            {
                std::cout << ' ';
            }

            if (j == width - 1)     
            {
                std::cout << '$';                         // Right Wall
            }
        }
        std::cout << endl;
    }

    for (int i = 0; i < width + 2; ++i)                   // Bottom Wall
    {
        std::cout << '&';
    }
    std::cout << endl;
    // Outputting the score
    std::cout << "Fun time apple picking score or apple picking: " << score << endl;
}

void input() 
{
    if(_kbhit())                                          // kbhit gets the keystroke for c++
    {
        switch (_getch())                                 // getch gets the char you fucking moron, why did you comment this?
        {
            case 'a' :
            dir = LEFT;
            break;

            case 'd' :
            dir = RIGHT;
            break;

            case 'w' :
            dir = UP;
            break;

            case 's' :
            dir = DOWN
            break;

            case 'x' :
            gameOver = true;
            break;
        }
    }
}

void logic() 
{
    // Getting the location of the snake
    int prevX = tailX[0];
    int prevY = tailY[0];

    int prev2X, prev2Y;
    tailX[0] = x;
    tailY[0] = y;

    for (int i = 1; i < nTail; ++i)
    {
        prev2X = tailX[i];
        prev2Y = tailY[i];

        tailX[i] = prevX;
        tailY[i] = prevY;

        prevX = prev2X;
        prevY = prev2Y;

    }

    switch (dir)
    {
        case LEFT :
            --x;
            break;

        case RIGHT :
            ++x;
            break;
        
        case UP :
            --y;
            break;

        case DOWN :
            ++Y;
            break;

        default:
            break;
    }

    // Collision detection
    if (x >= width) 
    {
        x = 0;
    }
    else if (x < 0 )
    {
        x = width - 1;
    }

    if ( y >= width) 
    {
        y = 0;
    }
    else if (y < 0)
    {
        height - 1;
    }

    // Fruit Detection
    if (x == fruitX && y == fruitY)
    {
        score += rand() % 14;
        fruitX = rand() % width;
        fruitY = rand() % height;
        // Growing the snake
        ++nTail;
    }

    for (int i = 0; i < nTail; ++i)
    {
        if (tailX[i] == x && tailY[i] == y) {
            gameOver = true;
        }
    }

}

int main() 
{
    setup();
    while (gameOver != false) 
    {
        draw();
        input();
        logic();
        Sleep(100);
    }

    return 0;
}