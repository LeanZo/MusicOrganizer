using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Id3;

namespace MusicOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {



            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            Console.WriteLine();
            Regex rgx = new Regex(".mp3$");
            string patharquivo = "undefined";


            foreach (var arquivo in dir.GetFiles())
            {

               // patharquivo = Path.Combine(Directory.GetCurrentDirectory(), arquivo.Name);

                if (rgx.IsMatch(arquivo.Name))
                {
                    Console.WriteLine(arquivo);
                    
                        using (var mp3 = new Mp3File(arquivo.Name))
                        {
                            Id3Tag tag = mp3.GetTag(Id3TagFamily.FileStartTag);
                        
                            Console.WriteLine("Bitch Hate: {0}", tag.BeatsPerMinute.Value);
                            if (!String.IsNullOrEmpty(tag.Title.Value))
                            Console.WriteLine("Title: {0}", tag.Title.Value);
                            if (!String.IsNullOrEmpty(tag.Artists.Value))
                            Console.WriteLine("Artist: {0}", tag.Artists.Value);
                            if (!String.IsNullOrEmpty(tag.Album.Value))
                            Console.WriteLine("Album: {0}", tag.Album.Value);
                    }
                    }




                }





            }    
        }
    }