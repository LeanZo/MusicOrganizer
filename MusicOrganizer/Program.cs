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

                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), artist));
                    string artistpath = Path.Combine(Directory.GetCurrentDirectory(), artist);
                    if (!System.IO.File.Exists(Path.Combine(artistpath, arquivo.Name)))
                    {
                        System.IO.File.Move(patharquivo, Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), artist), arquivo.Name));
                    }else
                    {

                        string arquivonome2 = arquivo.Name;
                        arquivonome2 = arquivonome2.Replace(".mp3", "+.mp3");
                        Console.WriteLine("Já existe um arquivo com este nome na pasta '{0}'",artist);
                        Console.WriteLine("Dejesa renomear o arquivo '{0}' para '{1}'? (S/N)", arquivo.Name, arquivonome2);
                        Console.Write(">");
                        string resp = Console.ReadLine().ToUpper();
                        Console.WriteLine();
                        if (resp == "S")
                        {
                            System.IO.File.Move(patharquivo, Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), artist), arquivonome2));
                        }
                    }

                }
               



           }





            }    
        }
    }