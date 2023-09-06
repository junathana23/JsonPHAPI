class GuessingGame {
int tries = 5;
Random rand = new Random();
int number = rand.Next(0,100);
Console.WriteLine(" Shall we Play a game? Guess a number between 1 and 100");
int attempt = convert.toint32(Console.ReadLine());
if (attempt == rand)
{
    Console.Write("Well done! you guessed correctly press any key to conclude");
}
else if (attempt != rand)
{
  for (int i = 0; i < 6; i ++)
  {
   tries - 1;
   Console.WriteLine("incorrect, you have " + tries + " tries left");
  }
}
else 
{
    console.WriteLine("you have run out of tries, press any Key to exit");
}


}