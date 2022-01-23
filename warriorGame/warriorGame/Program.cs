using warriorGame;

Game g = new Game();
while (! g.isGameOver)
{
    g.EachPathStep();
    Console.ReadKey();
}

