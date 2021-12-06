using System;

public class day3{
    public static void Main(){
        List <string> data = new List <string>();
        StreamReader sr = new StreamReader("day3.txt");
        string oneline = "";

        while((oneline = sr.ReadLine()) != null){
            data.Add(oneline);
        }

        
        Console.WriteLine("Part1: " + Part1(data));
        Console.WriteLine("Part1: " + Part2(data));
    }

    public static int Part1(List<string> datas){
        int[,] BinaryArray = new int[datas.Count,((datas[0].ToCharArray()).Length)];
        for(int j = 0; j < datas.Count; j++){
            char[] line = datas[j].ToCharArray();
            for(int i = 0; i < line.Length; i++){
                BinaryArray[j,i] = line[i]-48;
                //Console.Write(BinaryArray[j,i]);
            }
            //Console.WriteLine();
        }

        int ones = 0;
        string gamma = "";
        string epsilon = "";

        
        for(int i = 0; i < 12; i++){
            for(int j = 0; j < 1000;j++){
                switch (BinaryArray[j,i]){
                    case 1:
                        ones ++;
                        break;
                }
                
            }
            if(ones > 500){
            gamma += "1"; epsilon +=  "0";
            }else{
            gamma += "0"; epsilon +=  "1";
            }
            ones = 0;
        }

        Console.WriteLine("gamma\t" + gamma);
        Console.WriteLine("epsilon\t" + epsilon);


        return GetDecimal(gamma) * GetDecimal(epsilon);
    }
    public static int Part2(List <string> datas){
       return 0;
    }

    public static int GetDecimal(string binaryNumber){
        return Convert.ToInt32(binaryNumber, 2);
    }
}