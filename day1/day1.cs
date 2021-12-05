using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class day1{
    public static void Main(){
        List <int> data = new List <int>();
        StreamReader sr = new StreamReader("day1.txt");
        string oneline = "";
        while((oneline = sr.ReadLine()) != null){
            data.Add(int.Parse(oneline));
        }

        Console.WriteLine("Part 1: " + Part1(data));
        Console.WriteLine("Part 2: " + Part2(data));
    }
    public static int Part1(List<int> datas){
        int incrase = 0;

        for(int i=1;i<datas.Count;i++){
            if(datas[i-1] < datas[i]){
                incrase++;
            }
        }
        return incrase;
    }
    public static int Part2(List<int> datas){
        int incrasesum = 0; 
        List <int> sumwindow = new List<int>();
        
        for(int i=2;i<datas.Count;i++){
            sumwindow.Add(datas[i-2] + datas[i-1] + datas[i]);
        }
        
        for(int i=1;i<sumwindow.Count;i++){
            if(sumwindow[i-1] < sumwindow[i]){
                incrasesum++;
            }
        }
        return incrasesum;
    }

}