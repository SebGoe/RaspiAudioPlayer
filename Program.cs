using System;
using System.Threading;
using MusicPlayer;
using Unosquare.RaspberryIO;

namespace music_player
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            player.Init();

            var buttons = new[]
            {
                Button.Create(25, player.Play),
                Button.Create(24,player.Pause),
                Button.Create(2,player.Next), 
                Button.Create(28,player.Previous), 
                AddPlayListButton(player, 23, 0), 
                AddPlayListButton(player, 0, 1), 
                AddPlayListButton(player, 22, 2), 
                AddPlayListButton(player, 21, 3) 

            };

            Console.WriteLine("SetUp");
            
            while (true)
            {
            }

        }

        private static Button AddPlayListButton(Player player, int pinNumber, int playlistNumber)
        {
            return Button.Create(pinNumber, () => player.SelectList(playlistNumber));
        }
    }
}
