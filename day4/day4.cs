using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("day4.txt");
            List<string> datas = new List<string>();
            int board = 0;
            int i = 0;
            
            while(!sr.EndOfStream){
                datas.Add( sr.ReadLine());
                if(datas[datas.Count-1] == ""){
                    board ++;
                };
            }

            //Console.WriteLine(board);
            
            int[,,] datas3D = new int[100,5,5]; // 100 db 5*5 ös tábla
            board = 0;
            

            //bingo számok mentése
            string[] firstline = datas[0].Split(",");
            List<int> bingos = new List<int>();

            for(i = 0; i < firstline.Length; i++){
                bingos.Add(int.Parse(firstline[i]));
            }
            //Console.WriteLine(bingos.Count);  //100

            //táblák felépítése
            int linesin3D = 0;
            for( i = 2; i < datas.Count; i++ ){ //soronként végig megy a datas listán 
                if((i % 6) == 1 && i > 5){  
                    board ++;
                    linesin3D = 0;
                    Console.WriteLine("\n---" + (board + 1) + ". board---");
                }else{

                //végigmegy 1 soron
                string[] linehelp = datas[i].Split(' ');
                List<string> line = new List<string>();

                for(int j = 0; j < linehelp.Length; j++){
                    if(linehelp[j] != ""){      //ha üres space van a tömbben, azt nem veszi figyelembe (egyjegyű számok!)
                        line.Add(linehelp[j]);
                    }
                }
                
                for(int j = 0; j < 5; j++){
                    datas3D[board , linesin3D, j] = int.Parse(line[j]);
                    Console.Write(datas3D[board , linesin3D, j] + " ");   //teszt kiiras
                }
                Console.WriteLine(); //soork megmaradjanak

                linesin3D ++;
                }                
                
            }
            
        }

        public static int Part1(){
            return 0;
        }
    }
}