using System;

class day2{
    public static void Main(){
        Datas[] data = new Datas[1000];
        StreamReader sr = new StreamReader("day2.txt");
        string line = "";
        string[] oneline = new string[2];
        int i=0;
        while(( line = sr.ReadLine()) != null){
            oneline = line.Split(" ");
            data[i].instruction = oneline[0];
            data[i].step = int.Parse(oneline[1]);
            i++;
        }
        
        Console.WriteLine("Part 1: " + Part1(data));
        Console.WriteLine("Part 2: " + Part2(data));
    }
    public static int Part1(Datas[] data){
        int horizontal = 0;
        int deep = 0;

        for(int i=0;i<data.Length;i++){
            switch(data[i].instruction){
                case "forward":
                    horizontal += data[i].step;
                    break;
                case "up":
                    deep -= data[i].step;
                    break;
                case "down":
                    deep += data[i].step;
                    break;

            }
        }

        return deep*horizontal;
    }
    public static int Part2(Datas[] data){
        int horizontal = 0;
        int deep = 0;
        int aim = 0;

        for(int i=0;i<data.Length;i++){
            switch(data[i].instruction){
                case "forward":
                    horizontal += data[i].step;
                    deep += data[i].step * aim;
                    break;
                case "up":
                    aim -= data[i].step;
                    break;
                case "down":
                    aim += data[i].step;
                    break;

            }
        }

        return horizontal * deep;
    }


    public struct Datas{
        public string instruction{get; set;}
        public int step{get; set;}
    }

}