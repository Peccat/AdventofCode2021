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
            #region beolvasás
            const string puzzleinput = "day4.txt";
            const string testpuzzle = "day4_test.txt";

            StreamReader sr = new StreamReader(testpuzzle);
            List<string> datas = new List<string>();
            int board = 0;
            int i = 0;
            
            #region filebeolvasas
            while(!sr.EndOfStream){
                datas.Add( sr.ReadLine());
            }
            #endregion
            
            //int[,,] datas3D = new int[100,5,5]; // 100 db 5*5 ös tábla
            int[,,] datas3D = new int[3,5,5]; // 3db 5*5 ös tábla a teszthez
            
            #region bingo szamok mentese
            string[] firstline = datas[0].Split(",");
            List<int> bingos = new List<int>();

            for(i = 0; i < firstline.Length; i++){
                bingos.Add(int.Parse(firstline[i]));
            }
            #endregion

            #region tabla felepitese
            int linesin3D = 0;
            for( i = 2; i < datas.Count; i++ ){ //soronként végig megy a datas listán 
                if((i % 6) == 1 && i > 5){   //ha üres a sor, akkor a tábla számát növeli és a táblán belüli sorszámot nullázza
                    board ++;
                    linesin3D = 0;
                    //Console.WriteLine("\n---" + (board + 1) + ". board---");
                }else{

                //felvág 1 sort a spacek alapján
                string[] linehelp = datas[i].Split(' ');
                List<string> line = new List<string>();

                //string tömbbe átrakás, felesleges space-ek törlése
                for(int j = 0; j < linehelp.Length; j++){
                    if(linehelp[j] != ""){      //ha üres space van a tömbben, azt nem veszi figyelembe (egyjegyű számok!)
                        line.Add(linehelp[j]);
                    }
                }
                
                //int tömbbe konvertálás a későbbi ellenőrzésekhez
                for(int j = 0; j < 5; j++){
                    datas3D[board , linesin3D, j] = int.Parse(line[j]);
                    //Console.Write(datas3D[board , linesin3D, j] + " ");   //teszt kiiras
                }
                //Console.WriteLine(); //sorok megmaradjanak a kiiratáskor

                linesin3D ++; //táblán belüli sorok növelése
                }                
                
            }
            #endregion
            #endregion
            //Part 1
            Console.WriteLine("Part1: " + Part1(datas3D, bingos));
        }

        public static int Part1(int[,,] datas, List<int> bingos){
            //Console.WriteLine(datas.Length + " " + datas.GetLength(0) + " " + datas.GetLength(1) + " " + datas.GetLength(2));

            for(int i = 5; i < bingos.Count ; i++){                 //bingo számokon végigmegy
                for(int j = 0; j < datas.GetLength(0); j++){            //táblákon végigmegy
                    for(int k = 0; k < datas.GetLength(1); k++){            //sorokon megy végig 
                        for(int l = 0; l < datas.GetLength(2); l++){            // oszlopokon megy végig

                            if(datas[j,k,l] == bingos[i]){  //talált
                                byte ell = Ellenoriz(i, bingos, j, k, l, datas);
                                if(ell == 1){ //találat van
                                    int bingoUnmarkedSum = UnmarkedSum(datas,j,bingos,i); 
                                    Console.WriteLine("\n" + bingoUnmarkedSum + "*" + bingos[i] + "=" + bingoUnmarkedSum * bingos[i] );
                                    return bingoUnmarkedSum * bingos[i] ;  //vissza adja a bingo sorszáma és az el nem talált számok összegének szörzatát
                                }
                            }
                        }           
                    }
                }
            }
            return 0;
        }

        public static byte Ellenoriz(int bingosNumber, List<int> bingos, int tableCount, int Row, int Column, int[,,] datas){  //ellenőrzi az adott oszlopban, sorban a találatokat
                                //   bingo szama 0-tól számolva,bingo tmb, tábla száma 0-tól,sor, oszlop, adatok tmb
            int columnDetect = 0; //oszlopok találatának száma
            int rowDetect = 0;    //sorok találatának száma          

            for(int j= 0; j < 5; j++){  //pörgeti az oszlopokat,sorokat
                for(int k = 0; k != bingosNumber+1; k++){    //bingo számokat pörgeti
                    if(datas[tableCount, j, Column] == bingos[k]){ //ha van egyezés
                        columnDetect ++;    //oszlopot növeli
                        break;
                    }
                    if(datas[tableCount,Row, j] == bingos[k]){ //ha van egyezés
                        rowDetect ++;    //sorokat növeli
                        break;
                    }
                }                  
            } 
            if(rowDetect == 5 || columnDetect == 5){
                Console.WriteLine(rowDetect + " " + columnDetect);
                return 1;
            }  
            return 0;
        }

        public static int UnmarkedSum(int[,,] datas, int table, List<int> bingos, int bingosNumber){    //összeadja a nem húzott számokat
            int sum = 0;
            bool marked = false;
            
            Console.WriteLine("UnmarkedSumban");

            for(int i= 0; i < 5; i++){  //pörgeti a sorokat
                for(int j= 0; j < 5; j++){  //pörgeti az oszlopokat
                    for(int k = 0; k != bingosNumber+1; k++){    //bingo számokat pörgeti
                        if(datas[table, i, j] == bingos[k]){
                            marked = true;
                            break;
                        }
                    }
                    if(marked == true){     //ha van találat
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\t" + datas[table, i, j]);
                        marked = false;
                    }else{                  //ha nincs találat
                        sum += datas[table, i, j];
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\t" + datas[table, i, j]);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    
                }   
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tábla: " + (table + 1) + "; bingok sorszama: " + (bingosNumber + 1));
            for(int i = 0; i != bingosNumber+1; i++){
                Console.Write(bingos[i] + ",");
            }
            return sum;
        }
    }
}