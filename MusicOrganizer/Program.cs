using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using TagLib;

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

               patharquivo = Path.Combine(Directory.GetCurrentDirectory(), arquivo.Name);

                if (rgx.IsMatch(arquivo.Name))
                {
                    Console.WriteLine("Musica atual: {0}", arquivo);

                    TagLib.File tagFile = TagLib.File.Create(patharquivo);

                    string artist = tagFile.Tag.FirstAlbumArtist;
                    Console.WriteLine("Artista: {0}", artist);

                    string album = tagFile.Tag.Album;
                    Console.WriteLine("Album: {0}", album);

                    string title = tagFile.Tag.Title;
                    Console.WriteLine("Titulo: {0}", title);

                    Console.WriteLine();
                }




           }





            }    
        }
    }