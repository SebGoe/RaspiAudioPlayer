using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer
{
    class Player
    {
        private int CurrentPlayList = -1;
        private int PlayList => CurrentPlayList > -1 ? CurrentPlayList : (CurrentPlayList = 1);

        public void Init()
        {    
            "mpc clear".Bash();
        }

        public void Play()
        {
            if (IsPlaying) return;
            PlayAnyWay("");
        }

        private void PlayAnyWay(string song)
        {
            Console.WriteLine($"Playlist {PlayList} ");
            IsPlaying = true;

            "mpc stop".Bash();
            "mpc clear".Bash();
            $"mpc search filename {PlayList} | mpc add".Bash();            

            $"mpc play {song}".Bash();
            Console.WriteLine($"PlayAnyWay");            
        }

        private bool IsPlaying { get; set; }

        public void Next()
        {
            Console.WriteLine($"Next");            
            "mpc next".Bash();
        }

        public void Previous()
        {
            Console.WriteLine($"Previous");            
            "mpc prev".Bash();
        }

        public void Pause()
        {
            if(!IsPlaying) return;
            "mpc pause".Bash();
        }

        public void SelectList(int playlist)
        {
            CurrentPlayList = playlist;
            Console.WriteLine($"SelectList {playlist}");            
            
            PlayAnyWay("1");
        }
    }
}
